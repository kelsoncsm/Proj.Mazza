using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Proj.Mazza.Application.Commands;
using Proj.Mazza.Application.Contracts;
using Proj.Mazza.Domain.Common.ValueObjects;
using MediatR;
using Proj.Mazza.Domain.Aggregations.Products.Repositories;
using Proj.Mazza.Domain.Aggregations.Products;
using Proj.Mazza.Domain.Aggregations.Products.Exceptions;

namespace Proj.Mazza.Application.CommandHandlers
{
    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        public UpdateProductCommandHandler(IProductRepository productRepository,  IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
   
        }

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
      

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           
            var product = await _productRepository.FindAsync(h => h.Id == request.Id);

            if (product is null)
                throw new EntityNotFoundException($"Product {request.Id} not found");

            if (string.IsNullOrEmpty(request.Name))
                throw new EntityNotFoundException($"Name  not found");

            if (!request.Category.HasValue)
                throw new EntityNotFoundException($"Category  not found");


            if (!request.Price.HasValue)
                throw new EntityNotFoundException($"Price  not found");


            product.SetName(request.Name);
            product.SetCategory(request.Category.Value);
            product.SetPrice(request.Price.Value);

            await _productRepository.UpdateAsync(product);
            await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

          
            return await Task.FromResult(true);
        }

       
    }


}
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


            var model = await _productRepository.FindAsync(x => x.Name.Contains(request.Name));
             

            if(model != null && model.Id != request.Id)
                throw new EntityNotFoundException($"Produto j� cadastrado!!!");


            var product = await _productRepository.FindAsync(h => h.Id == request.Id);


            if (product is null)
                throw new EntityNotFoundException($"Produto {request.Id} not found");

            if (string.IsNullOrEmpty(request.Name))
                throw new EntityNotFoundException($"Nome n�o pode ser nulo!!!");

            if (!request.Category.HasValue)
                throw new EntityNotFoundException($"Categoria n�o pode ser nulo!!!");


            if (!request.Price.HasValue)
                throw new EntityNotFoundException($"Pre�o n�o pode ser nulo!!!");

            product.SetName(request.Name);
            product.SetCategory(request.Category.Value);
            product.SetPrice(request.Price.Value);
            product.UpdatedAt = DateTime.Now;

            await _productRepository.UpdateAsync(product);
            await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

          
            return await Task.FromResult(true);
        }

       
    }


}
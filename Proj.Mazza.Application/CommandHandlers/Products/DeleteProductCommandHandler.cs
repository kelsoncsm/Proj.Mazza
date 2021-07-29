using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Proj.Mazza.Application.Commands;
using Proj.Mazza.Application.DTOs;
using Proj.Mazza.Domain.Aggregations.Products.Repositories;

using MediatR;
using System.Data.SqlClient;
using AutoMapper.Configuration;
using AutoMapper;

namespace Proj.Mazza.Application.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {

        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }


        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(request.Id);
            return await Task.FromResult(true);
        }
    }
}
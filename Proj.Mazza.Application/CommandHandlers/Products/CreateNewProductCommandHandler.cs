using AutoMapper;
using Proj.Mazza.Application.Commands;
using Proj.Mazza.Application.DTOs;
using MediatR;

using System.Threading;
using System.Threading.Tasks;
using Proj.Mazza.Domain.Aggregations.Products.Repositories;
using Proj.Mazza.Domain.Aggregations.Products;

namespace Proj.Mazza.Application.CommandHandlers
{
    public class CreateNewProductCommandHandler : IRequestHandler<CreateNewProductCommand, ProductDTO>
    {
        public CreateNewProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public async Task<ProductDTO> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {
            var newHolder = new Product(
                    name: request.Name,
                    category: request.Category.Value,
                    price: request.Price.Value

                );


            await _productRepository.CreateAsync(newHolder);

            await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return await Task.FromResult(_mapper.Map<ProductDTO>(newHolder));
        }
    }
}

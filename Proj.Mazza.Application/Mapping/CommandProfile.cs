using AutoMapper;
using Proj.Mazza.Application.Commands;
using Proj.Mazza.Application.DTOs;
using Proj.Mazza.Domain.Aggregations.Products;

namespace Proj.Mazza.Application.Mapping
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<CreateNewProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, ProductDTO>();
         
        }
    }
}
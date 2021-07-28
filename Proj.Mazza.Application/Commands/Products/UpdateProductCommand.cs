using System;
using MediatR;

namespace Proj.Mazza.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
       
        public int? Category { get; set; }
     
        public decimal? Price { get; set; }
    }
}
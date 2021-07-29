using Proj.Mazza.Application.DTOs;
using MediatR;
using System;

namespace Proj.Mazza.Application.Commands
{
    public class CreateNewProductCommand : IRequest<bool>
    {
     
        public string Name { get; set; }

        public int? Category { get; set; }

        public decimal? Price { get; set; }
    }
}

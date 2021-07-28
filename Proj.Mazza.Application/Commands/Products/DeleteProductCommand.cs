using System;
using MediatR;

namespace Proj.Mazza.Application.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
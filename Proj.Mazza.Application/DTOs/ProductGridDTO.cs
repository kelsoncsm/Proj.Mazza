using Proj.Mazza.Domain.Aggregations.Products;

using System;
using System.Collections.Generic;

namespace Proj.Mazza.Application.DTOs
{
    public class ProductGridDTO  
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
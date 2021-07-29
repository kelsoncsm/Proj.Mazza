using System;

namespace Proj.Mazza.Application.DTOs
{
    public class ProductDTO 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Category { get; set; }

        public decimal? Price { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
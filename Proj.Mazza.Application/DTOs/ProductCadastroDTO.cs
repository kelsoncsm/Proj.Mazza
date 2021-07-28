using System;
using System.Collections.Generic;

namespace Proj.Mazza.Application.DTOs
{
    public class ProductCadastroDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public decimal Price { get; set; }

        public int Category { get; set; }

    }
}
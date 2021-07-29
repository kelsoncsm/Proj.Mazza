using Proj.Mazza.Domain.Common;
using Proj.Mazza.Domain.Common.ValueObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj.Mazza.Domain.Aggregations.Products
{
    public class Product : Entity<Guid>, IAggregateRoot
    {
        protected Product() { }

        public Product(string name, int category, decimal price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' não pode ser nulo ou vazio", nameof(name));
            Id = Guid.NewGuid();
            Name = name;
            Category = category;
            Price = price;

        }


        public string Name { get; private set; }

        public int Category { get; private set; }


        public decimal Price { get; private set; }

        public void SetName(string name)
            => Name = name;


        public void SetCategory(int idCategory)
          => Category = idCategory;


        public void SetPrice(decimal price)
         => Price = price;


    }
}
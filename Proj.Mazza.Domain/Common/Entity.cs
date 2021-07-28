 
using Proj.Mazza.Domain.Common.Helpers;
using System;

namespace Proj.Mazza.Domain.Common
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTimeBrasil.Now();
        public DateTime? UpdatedAt { get; set; }

        public void Update()
        {
            UpdatedAt = DateTimeBrasil.Now();
        }
    }
}
using Proj.Mazza.Domain.Common;
using Proj.Mazza.Domain.Common.ValueObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj.Mazza.Domain.Aggregations.Users
{
    public class User : Entity<Guid>, IAggregateRoot 
    { 


       
        public string mail { get; private set; }
    
        public string Password { get; private set; }

 

    }
}
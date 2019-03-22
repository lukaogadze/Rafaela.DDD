using System;

namespace Rafaela.DDD.Test.Implementations
{
    public class Product : Entity<Guid>
    {
        public Product(Guid id) : base(id)
        {
        }
    }
    
    public class Product2 : Entity<string>
    {
        public Product2(string id) : base(id)
        {            
        }
    }
}
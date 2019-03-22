using System;
using System.Collections.Generic;

namespace Rafaela.DDD.Test.Implementations
{
    public class Address : ValueObject
    {
        public string Street { get; }
        public string City { get; }
        public string ZipCode { get; }

        public Address(string street, string city, string zipCode)
        {
            Street = street ?? throw new ArgumentNullException(nameof(street));
            City = city ?? throw new ArgumentNullException(nameof(city));
            ZipCode = zipCode ?? throw new ArgumentNullException(nameof(zipCode));
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street.ToUpper();
            yield return City.ToUpper();
            yield return ZipCode.ToUpper();
        }
    }
}
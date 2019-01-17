using DDD.NetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.NetCore.Domain
{
    public class Address : ValueObject<Address>
    {
        public Address() { }
        public Address(string province, string city, string county, string street)
        {
            this.Province = province;
            this.City = city;
            this.County = county;
            this.Street = street;
        }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string County { get; private set; }
        public string Street { get; private set; }


        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}

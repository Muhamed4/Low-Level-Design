using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public Address() { }
        public Address(string _street, string _city, string _state,  string _zipCode, string _country) {
            this.Street = _street;
            this.City = _city;
            this.State = _state;
            this.ZipCode = _zipCode;
            this.Country = _country;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Person
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public Person() { }
        public Person(string name, Address address, string email, string phone) {
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
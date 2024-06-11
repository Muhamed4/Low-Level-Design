using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class User
    {
        public string Name { get; private set; }
        public Vehicle vehicle{ get; private set; }
        public User(string name, string model, string color, Type type)
        {
            Name = name;
            vehicle = new Vehicle(model, color, type);
        }
        public void EnterData()
        {
            throw new NotImplementedException();
        }

    }
}
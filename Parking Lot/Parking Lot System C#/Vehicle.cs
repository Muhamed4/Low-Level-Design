using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Vehicle
    {
        public string Model { get; private set; }
        public string Color { get; private set; }
        public Type Type { get; private set; }
        public Vehicle(string model, string color, Type type)
        {
            this.Model = model;
            this.Color = color;
            this.Type = type;
        }
    }
}
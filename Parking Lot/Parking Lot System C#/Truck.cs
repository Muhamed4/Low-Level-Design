using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Truck : Vehicle
    {
        public Truck(string license, bool handiCappedLicensePlate) : base(license, handiCappedLicensePlate, VehicleType.TRUCK) { }
        public override VehicleType GetVehicleType() => VehicleType.TRUCK;
    }
}
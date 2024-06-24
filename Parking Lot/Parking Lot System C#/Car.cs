using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Car : Vehicle
    {
        public Car(string license, bool handiCappedLicensePlate) : base(license, handiCappedLicensePlate, VehicleType.CAR) {}
        public override VehicleType GetVehicleType() => VehicleType.CAR;
    }
}
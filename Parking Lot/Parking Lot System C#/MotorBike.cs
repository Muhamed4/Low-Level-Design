using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class MotorBike : Vehicle
    {
        public MotorBike(string license, bool handiCappedLicensePlate) : base(license, handiCappedLicensePlate, VehicleType.MOTORBIKE) { }
        public override VehicleType GetVehicleType() => VehicleType.MOTORBIKE;
    }
}
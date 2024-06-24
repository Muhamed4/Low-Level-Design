using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Van : Vehicle
    {
        public Van(string license, bool handiCappedLicensePlate) : base(license, handiCappedLicensePlate, VehicleType.VAN) { }
        public override VehicleType GetVehicleType() => VehicleType.VAN;
    }
}
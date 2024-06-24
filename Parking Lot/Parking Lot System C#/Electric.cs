using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Electric : Vehicle
    {
        public Electric(string license, bool handiCappedLicensePlate) : base(license, handiCappedLicensePlate, VehicleType.ELECTRIC) { }
        public override VehicleType GetVehicleType() => VehicleType.ELECTRIC;
    }
}
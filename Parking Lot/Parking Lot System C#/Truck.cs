using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Truck : Vehicle
    {
        public Truck(string license, bool handiCappedLicensePlate) : base(license, handiCappedLicensePlate, VehicleType.TRUCK) { }

        public override List<ParkingSpot> GetSuitableParkingSpots(ParkingFloor parkingFloor)
        {
            List<ParkingSpot> result = new List<ParkingSpot>(parkingFloor.largeSpots);
            return result;
        }

        public override int GetTotalParkingSpots(List<ParkingFloor> parkingFloors)
        {
            int TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Where(l => l.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED)
                                                .Count() > 0).Count();
            return TotalParkingSpot;
        }

        public override VehicleType GetVehicleType() => VehicleType.TRUCK;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Car : Vehicle
    {
        public Car(string license, bool handiCappedLicensePlate) : base(license, handiCappedLicensePlate, VehicleType.CAR) {}

        public override List<ParkingSpot> GetSuitableParkingSpots(ParkingFloor parkingFloor)
        {
            List<ParkingSpot> result = new List<ParkingSpot>(parkingFloor.compactSpots);
            return result;
        }

        public override int GetTotalParkingSpots(List<ParkingFloor> parkingFloors)
        {
            int TotalParkingSpot = parkingFloors.Where(p => p.compactSpots.Where(l => l.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED)
                                                .Count() > 0).Count();
            return TotalParkingSpot;
        }

        public override VehicleType GetVehicleType() => VehicleType.CAR;
    }
}
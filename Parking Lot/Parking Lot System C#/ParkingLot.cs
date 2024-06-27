using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ParkingLot
    {
        private string name;
        private Address address;
        private List<ParkingFloor> parkingFloors;
        private List<EntryPoint> entryPoints;
        private List<ExitPoint> exitPoints;

        public bool isFull(VehicleType vehicleType) {
            int TotalParkingSpot = 0;
            if(vehicleType == VehicleType.TRUCK || vehicleType == VehicleType.VAN)
                TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Count > 0).Count();
            if(vehicleType == VehicleType.MOTORBIKE)
                TotalParkingSpot = parkingFloors.Where(p => p.motorBikeSpots.Count > 0).Count();
            if(vehicleType == VehicleType.CAR)
                TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Count > 0 || p.compactSpots.Count > 0).Count();
            if(vehicleType == VehicleType.ELECTRIC)
                TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Count > 0 || p.compactSpots.Count > 0 || p.electricSpots.Count > 0).Count();
            return TotalParkingSpot == 0;
        }

        public bool isFull() {
            int TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Count > 0 || p.compactSpots.Count > 0 
                                                        || p.electricSpots.Count > 0 || p.motorBikeSpots.Count > 0).Count();
            return TotalParkingSpot == 0;
        }
    }
}
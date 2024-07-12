using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class LargeSpot : ParkingSpot
    {
        public LargeSpot(int parkingSpotId, ParkingSpotStatus parkingSpotStatus) 
            : base(parkingSpotId, ParkingSpotType.LARGE, parkingSpotStatus) { }

        public override bool AddParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var largeSpot = (LargeSpot)parkingSpot;
            parkingFloor.largeSpots.Add(largeSpot);
            return true;
        }

        public override int GetParkingSpotId() => ParkingSpotId;

        public override ParkingSpotStatus GetParkingSpotStatus() => ParkingSpotStatus;

        public override ParkingSpotType GetParkingSpotType() => ParkingSpotType;

        public override Vehicle GetVehicle() => Vehicle;

        public override bool ParkVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
            ParkingSpotStatus = ParkingSpotStatus.OCCUPIED;
            return true;
        }

        public override bool RemoveParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var largeSpot = (LargeSpot)parkingSpot;
            if(parkingFloor.largeSpots.Contains(largeSpot) == false)
                return false;
            parkingFloor.largeSpots.Remove(largeSpot);
            return true;
        }
    }
}
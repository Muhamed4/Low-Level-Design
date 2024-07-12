using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class HandiCappedSpot : ParkingSpot
    {
        public HandiCappedSpot(int parkingId, 
                            ParkingSpotStatus parkingSpotStatus)
                            : base(parkingId, ParkingSpotType.HANDICAPPED, parkingSpotStatus) { }

        public override bool AddParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var handiCappedSpot = (HandiCappedSpot)parkingSpot;
            parkingFloor.handiCappedSpots.Add(handiCappedSpot);
            return true;
        }

        public override int GetParkingSpotId() => ParkingSpotId;

        public override ParkingSpotStatus GetParkingSpotStatus() => ParkingSpotStatus;

        public override ParkingSpotType GetParkingSpotType() => ParkingSpotType;

        public override Vehicle GetVehicle() => Vehicle;

        public override bool ParkVehicle(Vehicle vehicle)
        {
            if(vehicle == null || vehicle.HandiCappedLicensePlate == false)
                return false;
            Vehicle = vehicle;
            ParkingSpotStatus = ParkingSpotStatus.OCCUPIED;
            return true;
        }

        public override bool RemoveParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var handiCappedSpot = (HandiCappedSpot)parkingSpot;
            if(parkingFloor.handiCappedSpots.Contains(handiCappedSpot) == false)
                return false;
            parkingFloor.handiCappedSpots.Remove(handiCappedSpot);
            return true;
        }
    }
}
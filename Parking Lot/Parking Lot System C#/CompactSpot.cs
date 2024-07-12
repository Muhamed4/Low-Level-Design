using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class CompactSpot : ParkingSpot
    {
        public CompactSpot(int parkingSpotId, ParkingSpotStatus parkingSpotStatus)
            : base(parkingSpotId, ParkingSpotType.COMPACT, parkingSpotStatus) { }

        public override bool AddParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var compactSpot = (CompactSpot)parkingSpot;
            parkingFloor.compactSpots.Add(compactSpot);
            return true;
        }

        public override int GetParkingSpotId() => ParkingSpotId;

        public override ParkingSpotStatus GetParkingSpotStatus() => ParkingSpotStatus;

        public override ParkingSpotType GetParkingSpotType() => ParkingSpotType;

        public override Vehicle GetVehicle() => Vehicle;

        public override bool ParkVehicle(Vehicle vehicle)
        {
            if(vehicle.VehicleType == VehicleType.VAN || vehicle.VehicleType == VehicleType.TRUCK)
                return false;
            Vehicle = vehicle;
            ParkingSpotStatus = ParkingSpotStatus.OCCUPIED;
            return true;
        }

        public override bool RemoveParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var compactSpot = (CompactSpot)parkingSpot;
            if(parkingFloor.compactSpots.Contains(compactSpot) == false)
                return false;
            parkingFloor.compactSpots.Remove(compactSpot);
            return true;
        }
    }
}
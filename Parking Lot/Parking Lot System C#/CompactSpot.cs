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
    }
}
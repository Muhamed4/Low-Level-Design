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
    }
}
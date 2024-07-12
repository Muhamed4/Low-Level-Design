using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class MotorBikeSpot : ParkingSpot
    {
        public MotorBikeSpot(int parkingSpotId, ParkingSpotStatus parkingSpotStatus)
            : base(parkingSpotId, ParkingSpotType.MOTORBIKE, parkingSpotStatus) { }

        public override bool AddParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var motorBikeSpot = (MotorBikeSpot)parkingSpot;
            parkingFloor.motorBikeSpots.Add(motorBikeSpot);
            return true;
        }

        public override int GetParkingSpotId() => ParkingSpotId;

        public override ParkingSpotStatus GetParkingSpotStatus() => ParkingSpotStatus;

        public override ParkingSpotType GetParkingSpotType() => ParkingSpotType;

        public override Vehicle GetVehicle() => Vehicle;

        public override bool ParkVehicle(Vehicle vehicle)
        {
            if(vehicle.VehicleType != VehicleType.MOTORBIKE)
                return false;
            Vehicle = vehicle;
            ParkingSpotStatus = ParkingSpotStatus.OCCUPIED;
            return true;
        }

        public override bool RemoveParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var motorBikeSpot = (MotorBikeSpot)parkingSpot;
            if(parkingFloor.motorBikeSpots.Contains(motorBikeSpot) == false)
                return false;
            parkingFloor.motorBikeSpots.Remove(motorBikeSpot);
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public abstract class ParkingSpot
    {
        protected int ParkingSpotId;
        protected ParkingSpotType ParkingSpotType;
        protected ParkingSpotStatus ParkingSpotStatus;
        protected Vehicle Vehicle;
        public ParkingSpot(int parkingId, ParkingSpotType parkingSpotType, ParkingSpotStatus parkingSpotStatus) {
            this.ParkingSpotId = parkingId;
            this.ParkingSpotType = parkingSpotType;
            this.ParkingSpotStatus = ParkingSpotStatus;
            // this.Vehicle = vehicle;
        }
        public abstract bool ParkVehicle(Vehicle vehicle);
        public abstract int GetParkingSpotId();
        public abstract ParkingSpotType GetParkingSpotType();
        public abstract ParkingSpotStatus GetParkingSpotStatus();
        public abstract Vehicle GetVehicle();
        public abstract bool AddParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor);
        public abstract bool RemoveParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor);
        public bool UnParkVehicle() {
            Vehicle = null;
            ParkingSpotStatus = ParkingSpotStatus.UNOCCUPIED;
            return true;
        }
    }
}
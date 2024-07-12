using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public abstract class Vehicle
    {
        public string License { get; private set; }
        public bool HandiCappedLicensePlate { get; private set; } 
        public VehicleType VehicleType { get; private set; }
        protected Vehicle(string license, bool handiCappedLicensePlate, VehicleType vehicleType) {
            this.License = license;
            this.HandiCappedLicensePlate = handiCappedLicensePlate;
            this.VehicleType = vehicleType;
        }
        public abstract VehicleType GetVehicleType();
        public abstract List<ParkingSpot> GetSuitableParkingSpots(ParkingFloor parkingFloor);
        public abstract int GetTotalParkingSpots(List<ParkingFloor> parkingFloors);
        public bool IsHandiCapped() => HandiCappedLicensePlate;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ElectricSpot : ParkingSpot
    {
        public ElectricPanel ElectricPanel { get; private set; }
        public ElectricSpot(int parkingId, 
                            ParkingSpotStatus parkingSpotStatus, CreditCardPayment creditCardPayment)
                            : base(parkingId, ParkingSpotType.ELECTRIC, parkingSpotStatus) { 
            ElectricPanel = new ElectricPanel(creditCardPayment);
        }
        public override int GetParkingSpotId() => ParkingSpotId;

        public override ParkingSpotStatus GetParkingSpotStatus() => ParkingSpotStatus;

        public override ParkingSpotType GetParkingSpotType() => ParkingSpotType;

        public override Vehicle GetVehicle() => Vehicle;

        public override bool ParkVehicle(Vehicle vehicle)
        {
            if(vehicle.VehicleType != VehicleType.ELECTRIC)
                return false;
            Vehicle = vehicle;
            ParkingSpotStatus = ParkingSpotStatus.OCCUPIED;
            return true;
        }

        public override bool AddParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var electricSpot = (ElectricSpot)parkingSpot;
            parkingFloor.electricSpots.Add(electricSpot);
            return true;
        }

        public override bool RemoveParkingSpot(ParkingSpot parkingSpot, ParkingFloor parkingFloor)
        {
            if(parkingSpot is null || parkingFloor is null)
                return false;
            var electricSpot = (ElectricSpot)parkingSpot;
            if(parkingFloor.electricSpots.Contains(electricSpot) == false)
                return false;
            parkingFloor.electricSpots.Remove(electricSpot);
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class EntryPoint
    {
        public string EntryId { get; private set; }
        public EntryPoint(string entyrId)
        {
            EntryId = entyrId;
        }
        public Ticket GenerateTicket(string floorTitle, ParkingSpot parkingSpot, Vehicle vehicle)
            => new(floorTitle, parkingSpot, vehicle);

        public ParkingSpot? GetFreeParkingSpot(VehicleType vehicleType, List<ParkingFloor> parkingFloors) {
            ParkingSpot? freeParkingSpot = null;
            foreach(var item in parkingFloors) {
                if(vehicleType == VehicleType.TRUCK || vehicleType == VehicleType.VAN) {
                    freeParkingSpot = item.largeSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                    if(freeParkingSpot is not null)
                        break;
                }
                if(vehicleType == VehicleType.CAR || vehicleType == VehicleType.ELECTRIC) {
                    freeParkingSpot = item.compactSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                    if(freeParkingSpot is not null)
                        break;
                }
                if(vehicleType == VehicleType.ELECTRIC) {
                    freeParkingSpot = item.electricSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                    if(freeParkingSpot is not null)
                        break;
                }
                if(vehicleType == VehicleType.MOTORBIKE) {
                    freeParkingSpot = item.motorBikeSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                    if(freeParkingSpot is not null)
                        break;
                }
            }
            return freeParkingSpot;
        }
    }
}
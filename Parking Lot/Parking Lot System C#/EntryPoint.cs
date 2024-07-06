using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class EntryPoint
    {
        public string EntryId { get; private set; }
        private readonly object _locker = new object();
        public EntryPoint(string entyrId)
        {
            EntryId = entyrId;
        }
        public Task<Ticket> GenerateTicket(string floorTitle, ParkingSpot parkingSpot, VehicleType vehicleType)
            => Task.Run(() => {
                return new Ticket(floorTitle, parkingSpot, vehicleType);
            });

        public ParkingSpot? GetFreeParkingSpot(Vehicle vehicle, VehicleType vehicleType, List<ParkingFloor> parkingFloors) {
            lock (_locker) {
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
                if (freeParkingSpot is not null) 
                    freeParkingSpot.ParkVehicle(vehicle);
                return freeParkingSpot;
            }
        }
    }
}
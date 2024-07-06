using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ParkingLot
    {
        private string name;
        private Address address;
        private List<ParkingFloor> parkingFloors;
        private EntryPoint entryPoint;
        private ExitPoint exitPoint;
        private List<Ticket> tickets;
        // private readonly object locker = new object();
        public async Task<bool> ParkingVehicle(Vehicle vehicle) {
            if (vehicle is null)
                return false;
                
            ParkingSpot? parkingSpot = null;
            bool isParked = true;
            await Task.Run(() => {
                parkingSpot = entryPoint.GetFreeParkingSpot(vehicle, vehicle.VehicleType, parkingFloors);
                if (parkingSpot is null)
                    isParked = false;
            });

            if(isParked == true) {
                Ticket ticket = await entryPoint.GenerateTicket(name, parkingSpot, vehicle.vehicleType); 
                tickets.Add(ticket);
            }
            return isParked;
        }

        public async Task<bool> FreeParkingSpot(Ticket ticket) {
            if(ticket is null)
                return false;
            return await exitPoint.FreeParkingSpot(ticket);
        } 
        
        public bool isFull(VehicleType vehicleType) {
            int TotalParkingSpot = 0;
            if(vehicleType == VehicleType.TRUCK || vehicleType == VehicleType.VAN)
                TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Count > 0).Count();
            if(vehicleType == VehicleType.MOTORBIKE)
                TotalParkingSpot = parkingFloors.Where(p => p.motorBikeSpots.Count > 0).Count();
            if(vehicleType == VehicleType.CAR)
                TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Count > 0 || p.compactSpots.Count > 0).Count();
            if(vehicleType == VehicleType.ELECTRIC)
                TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Count > 0 || p.compactSpots.Count > 0 || p.electricSpots.Count > 0).Count();
            return TotalParkingSpot == 0;
        }

        public bool isFull() {
            int TotalParkingSpot = parkingFloors.Where(p => p.largeSpots.Count > 0 || p.compactSpots.Count > 0 
                                                        || p.electricSpots.Count > 0 || p.motorBikeSpots.Count > 0).Count();
            return TotalParkingSpot == 0;
        }
    }
}
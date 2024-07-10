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
                Ticket ticket = await Ticket.GenerateTicket(name, parkingSpot, vehicle.VehicleType); 
                tickets.Add(ticket);
            }
            return isParked;
        }

        public async Task<bool> FreeParkingSpot(Ticket ticket) {
            if(ticket is null)
                return false;
            return await exitPoint.FreeParkingSpot(ticket);
        } 
        
        public bool isFull(VehicleType vehicleType) 
            => Full.isFull(vehicleType, parkingFloors);

        public bool isFull() 
            => Full.isFull(parkingFloors);
    }
}
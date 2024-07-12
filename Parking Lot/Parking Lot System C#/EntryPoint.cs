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
        public EntryPoint(string entryId)
        {
            EntryId = entryId;
        }
        
        public ParkingSpot? GetFreeParkingSpot(Vehicle vehicle, VehicleType vehicleType, List<ParkingFloor> parkingFloors) {
            lock (_locker) {
                ParkingSpot? freeParkingSpot = null;
                ParkingFloor parkingFloor = null;
                foreach(var item in parkingFloors) {
                    if(vehicleType == VehicleType.TRUCK || vehicleType == VehicleType.VAN) {
                        freeParkingSpot = item.largeSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                        if(freeParkingSpot is not null) {
                            parkingFloor = item;
                            break;
                        }
                    }
                    if(vehicleType == VehicleType.CAR || vehicleType == VehicleType.ELECTRIC) {
                        freeParkingSpot = item.compactSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                        if(freeParkingSpot is not null) {
                            parkingFloor = item;
                            break;
                        }
                    }
                    if(vehicleType == VehicleType.ELECTRIC) {
                        freeParkingSpot = item.electricSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                        if(freeParkingSpot is not null) {
                            parkingFloor = item;
                            break;
                        }
                    }
                    if(vehicleType == VehicleType.MOTORBIKE) {
                        freeParkingSpot = item.motorBikeSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                        if(freeParkingSpot is not null) {
                            parkingFloor = item;
                            break;
                        }
                    }
                }
                if (freeParkingSpot is not null && parkingFloor is not null) 
                    parkingFloor.AssignVehicle(vehicle, freeParkingSpot);
                return freeParkingSpot;
            }
        }

        // Applying Open / Closed Principle
        public ParkingSpot? GetFreeParkingSpotOCP(Vehicle vehicle, List<ParkingFloor> parkingFloors) {
            lock (_locker) {
                ParkingSpot? freeParkingSpot = null;
                ParkingFloor parkingFloor = null;
                foreach(var item in parkingFloors) {
                    List<ParkingSpot> parkingSpots = vehicle.GetSuitableParkingSpots(item);
                    freeParkingSpot = parkingSpots.Where(p => p.GetParkingSpotStatus() == ParkingSpotStatus.UNOCCUPIED).FirstOrDefault();
                    if(freeParkingSpot is not null) {
                        parkingFloor = item;
                        break;
                    }
                }
                if (freeParkingSpot is not null && parkingFloor is not null) 
                    parkingFloor.AssignVehicle(vehicle, freeParkingSpot);
                    
                return freeParkingSpot;
            }
        }
    }
}
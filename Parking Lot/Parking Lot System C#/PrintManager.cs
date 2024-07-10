using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class PrintManager
    {
        public static void PrintInformation(int TicketId, string FloorTitle, ParkingSpot parkingSpot, VehicleType vehicleType) {
            Console.WriteLine($"Ticket ID:\t {TicketId}");
            Console.WriteLine($"Floor Title:\t {FloorTitle}");
            Console.WriteLine($"Parking Spot ID:\t {parkingSpot.GetParkingSpotId()}");
            Console.WriteLine($"Parking Spot Type:\t {parkingSpot.GetParkingSpotType()}");
            // Console.WriteLine($"Vehicle License:\t {Vehicle.License}");
            Console.WriteLine($"Vehicle Type:\t {vehicleType}");
        }
    }
}
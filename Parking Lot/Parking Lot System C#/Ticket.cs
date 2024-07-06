using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Ticket
    {
        public int TicketId { get; private set; }
        public string FloorTitle { get; private set; }
        public ParkingSpot ParkingSpot { get; private set; }
        public DateTime EntryTime { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public Ticket(string floorTitle, ParkingSpot parkingSpot, VehicleType vehicleType) {
            // this.TicketId = ticketId;
            this.FloorTitle = floorTitle;
            this.ParkingSpot = parkingSpot;
            this.VehicleType = vehicleType;
            this.EntryTime = DateTime.Now;
            this.PaymentStatus = PaymentStatus.ACTIVE;
        }

        public void Paid() => PaymentStatus = PaymentStatus.PAID;
        
        public void PrintInformation() {
            Console.WriteLine($"Ticket ID:\t {TicketId}");
            Console.WriteLine($"Floor Title:\t {FloorTitle}");
            Console.WriteLine($"Parking Spot ID:\t {ParkingSpot.GetParkingSpotId()}");
            Console.WriteLine($"Parking Spot Type:\t {ParkingSpot.GetParkingSpotType()}");
            // Console.WriteLine($"Vehicle License:\t {Vehicle.License}");
            Console.WriteLine($"Vehicle Type:\t {VehicleType}");
        }
    }
}
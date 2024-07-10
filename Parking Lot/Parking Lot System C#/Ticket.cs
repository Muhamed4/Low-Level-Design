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
        
        public static Task<Ticket> GenerateTicket(string floorTitle, ParkingSpot parkingSpot, VehicleType vehicleType)
            => Task.Run(() => {
                return new Ticket(floorTitle, parkingSpot, vehicleType);
            });

        public void Paid() => PaymentStatus = PaymentStatus.PAID;
        
        public void PrintInformation() 
            => PrintManager.PrintInformation(TicketId, FloorTitle, ParkingSpot, VehicleType);
    }
}
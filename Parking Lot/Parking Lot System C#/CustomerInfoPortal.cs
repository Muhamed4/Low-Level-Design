using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class CustomerInfoPortal
    {
        private Ticket ticket;
        private const double PRICE_PAIR_HOUR_FOR_PARKING = 4.00;
        private const double PRICE_PAIR_HOUR_FOR_CHARGE = 5.00;
        public void getTicket(Ticket _ticket) => this.ticket = _ticket;
        public void TotalTimeForParking() {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = dateTime - ticket.EntryTime;
            int totalMinuets = (int)timeSpan.TotalMinutes;
            int hours = totalMinuets / 60;
            int minuets = totalMinuets % 60;
            Console.WriteLine($"You spent {hours} and {minuets} for parking");
        }

        public double TotalPrice() {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = dateTime - ticket.EntryTime;
            double totalMinuets = timeSpan.TotalMinutes;
            double amount = totalMinuets / 60.00 * PRICE_PAIR_HOUR_FOR_PARKING;
            if (ticket.VehicleType == VehicleType.ELECTRIC)
                amount = amount + totalMinuets / 60.00 * PRICE_PAIR_HOUR_FOR_CHARGE;
            return amount;
        }
    }
}
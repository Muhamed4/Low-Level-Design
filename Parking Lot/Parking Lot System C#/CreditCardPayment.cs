using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class CreditCardPayment : Payment
    {
        private const double PAYEMENTTAX = 0.85;
        public override double MakePayment(Ticket ticket)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = dateTime - ticket.EntryTime;
            double totalMinuets = timeSpan.TotalMinutes;
            amount = totalMinuets / 60.00 * PRICE_PAIR_HOUR_FOR_PARKING;
            // if (ticket.Vehicle.GetVehicleType() == VehicleType.ELECTRIC)
            //     amount = amount + numOfMinuetsForCharging / 60.00 * PRICE_PAIR_HOUR_FOR_CHARGE;
            amount += PAYEMENTTAX;
            ticket.Paid();
            return amount;
        }

        public double PayForCharge(double numOfMinuetsForCharging) 
            => numOfMinuetsForCharging / 60.00 * PRICE_PAIR_HOUR_FOR_CHARGE;
    }
}
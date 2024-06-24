using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public abstract class Payment
    {
        protected double amount;
        protected const double PRICE_PAIR_HOUR_FOR_PARKING = 4.00;
        protected const double PRICE_PAIR_HOUR_FOR_CHARGE = 5.00;
        public double GetAmount() => amount;
        public abstract double MakePayment(Ticket ticket);
    }
}
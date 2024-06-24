using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ElectricPanel
    {
        private CreditCardPayment CreditCardPayment;
        private DateTime StartCharging;
        private DateTime EndCharging;
        public ElectricPanel(CreditCardPayment creditCardPayment) {
            CreditCardPayment = creditCardPayment;
            StartCharging = DateTime.Now;
            EndCharging = DateTime.Now;
        } 
        public bool BeginCharge() {
            StartCharging = DateTime.Now;
            return true;
        }
        public bool EndCharge() {
            EndCharging = DateTime.Now;
            return true;
        }

        public double PayForCharge() {
            TimeSpan timeSpan = EndCharging - StartCharging;
            double numOfMinuetsForCharging = timeSpan.TotalMinutes;
            double totalAmountForCharging = CreditCardPayment.PayForCharge(numOfMinuetsForCharging);
            return totalAmountForCharging;
        }

    }
}
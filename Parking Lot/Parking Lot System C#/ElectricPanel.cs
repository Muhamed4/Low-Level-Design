using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ElectricPanel
    {
        private IPayCharge payCharge;
        private DateTime StartCharging;
        private DateTime EndCharging;
        public ElectricPanel(CreditCardPayment creditCardPayment) {
            payCharge = creditCardPayment;
            StartCharging = DateTime.Now;
            EndCharging = DateTime.Now;
        } 
        public void BeginCharge() => StartCharging = DateTime.Now;
        public void EndCharge() => EndCharging = DateTime.Now;
        public double PayForCharge() {
            double numOfMinuetsForCharging = TotalMinutes();
            double totalAmountForCharging = payCharge.PayForCharge(numOfMinuetsForCharging);
            return totalAmountForCharging;
        }

        private double TotalMinutes() {
            TimeSpan timeSpan = EndCharging - StartCharging;
            double numOfMinuetsForCharging = timeSpan.TotalMinutes;
            return numOfMinuetsForCharging;
        }

    }
}
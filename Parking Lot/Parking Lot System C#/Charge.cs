using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Charge
    {
        public static double TotalAmountForCharge(double numOfMinuetsForCharging, const double PRICE_PAIR_HOUR_FOR_CHARGE) {
            double totalAmountForCharging = numOfMinuetsForCharging / 60.00 * PRICE_PAIR_HOUR_FOR_CHARGE;
            return totalAmountForCharging;
        }
    }
}
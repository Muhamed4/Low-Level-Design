using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public interface IPayCharge
    {
        public double PayForCharge(double numOfMinuetsForCharging);
    }
}
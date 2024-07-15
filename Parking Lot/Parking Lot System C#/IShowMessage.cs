using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public interface IShowMessage
    {
        public void ShowMessage(int NHandiCapped, int NCompact, int NLarge, int NMotorBike, int NElectric);
    }
}
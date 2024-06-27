using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class DisplayBoard
    {
        private string floorTitle;
        public DisplayBoard(string _floorTitle, ref Action<int, int ,int ,int, int> _showMessage)
        {
            this.floorTitle = _floorTitle;
            _showMessage += ShowMessage;
        }
        public void ShowMessage(int NHandiCapped, int NCompact, int NLarge, int NMotorBike, int NElectric) {
            Console.WriteLine(floorTitle);
            if(NHandiCapped == 0 && NCompact == 0 && NLarge == 0 && NElectric == 0) {
                Console.WriteLine("The Parking Floor is Full");
                return;
            }

            if(NHandiCapped > 0)
                Console.WriteLine($"{NHandiCapped} Handicapped Spots are available");

            if(NCompact > 0)
                Console.WriteLine($"{NCompact} Compact Spots are available");

            if(NLarge > 0)
                Console.WriteLine($"{NLarge} Large Spots are available");

            if(NMotorBike > 0)
                Console.WriteLine($"{NMotorBike} MotorBike Spots are available");

            if(NElectric > 0)
                Console.WriteLine($"{NElectric} Electric Spots are available");
        }
    }
}
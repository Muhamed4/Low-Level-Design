using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class System
    {
        private ParkingLot parkingLot;
        public System()
        {
            parkingLot = new ParkingLot();
        }
        public void Run()
        {
            var user = getUserData();      

        }
        private User getUserData()
        {
            Console.WriteLine("Please Enter Your Data: ");
            Console.WriteLine("Enter Your Name: ");
            string _name = Console.ReadLine();
            Console.WriteLine("Enter Your Car Model: ");
            string _model = Console.ReadLine();
            Console.WriteLine("What is the color of your car ?");
            string _color = Console.ReadLine();
            Console.WriteLine("Choose one the two types that represent your car : ");
            Console.WriteLine("1- 2 Wheels");
            Console.WriteLine("2- 4 Wheels");
            int _choice = 0;
            string ch = Console.ReadLine();
            while(!int.TryParse(ch, out _choice) || (_choice <= 0 && _choice > 2))
            {
                Console.WriteLine("Invalid Input .... Try again!");
                ch = Console.ReadLine();
            }
            var _user = new User(_name, _model, _color, (_choice == 1) ? Type.TowWheel : Type.FourWheel);
            return _user;
        }

        private void FreeParkingSpot()
        {
            List<ParkingSpot> freeSpots = parkingLot.listAllFreeParkingSpots();
            if(freeSpots is null || freeSpots.Count == 0)
            {
                Console.WriteLine("There are not free parking spots.");
                Console.WriteLine("Do you want to be registered in the waiting list ?");
                Console.WriteLine("Please enter y for yes and n for No ....");
                string answer = Console.ReadLine();
                while(answer != "Y" || answer != "y" || answer != "n" || answer != "N")
                {
                    Console.WriteLine("Invalid Input .... Try again!");
                    answer = Console.ReadLine();
                }
                if(answer == "y" || answer == "Y")
                {
                    
                }
            }
        }
    }
}
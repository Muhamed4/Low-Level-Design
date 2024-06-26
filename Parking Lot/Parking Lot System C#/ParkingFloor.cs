using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ParkingFloor
    {
        private string title;
        private DisplayBoard displayBoard;
        private CustomerInfoPortal customerInfoPortal;
        private List<HandiCappedSpot> handiCappedSpots;
        private List<CompactSpot> compactSpots;
        private List<LargeSpot> largeSpots;
        private List<ElectricSpot> electricSpots;
        private List<MotorBikeSpot> motorBikeSpots;
        public ParkingFloor(string _title) {
            this.title = _title;
            displayBoard = new DisplayBoard(title);
            customerInfoPortal = new CustomerInfoPortal();
        }
        public void AddParkingSpot(ParkingSpot parkingSpot) {
            if(parkingSpot == null) {
                Console.WriteLine("Invalid Operation try again ....!");
                return;
            }
            switch (parkingSpot.GetParkingSpotType())
            {
                case ParkingSpotType.HANDICAPPED:
                    handiCappedSpots.Add((HandiCappedSpot)parkingSpot);
                    break;
                case ParkingSpotType.COMPACT:
                    compactSpots.Add((CompactSpot)parkingSpot);
                    break;
                case ParkingSpotType.LARGE:
                    largeSpots.Add((LargeSpot)parkingSpot);
                    break;
                case ParkingSpotType.ELECTRIC:
                    electricSpots.Add((ElectricSpot)parkingSpot);
                    break;
                case ParkingSpotType.MOTORBIKE:
                    motorBikeSpots.Add((MotorBikeSpot)parkingSpot);
                    break;
                default:
                    Console.WriteLine("Invalid Parking Spot Type");
                    break;
            }
        }

        public bool RemoveParkingSpot(ParkingSpot parkingSpot) {
            if(parkingSpot == null)
                return false;
            switch (parkingSpot.GetParkingSpotType())
            {
                case ParkingSpotType.HANDICAPPED:
                    handiCappedSpots.Remove((HandiCappedSpot)parkingSpot);
                    return true;
                case ParkingSpotType.COMPACT:
                    compactSpots.Remove((CompactSpot)parkingSpot);
                    return true;
                case ParkingSpotType.LARGE:
                    largeSpots.Remove((LargeSpot)parkingSpot);
                    return true;
                case ParkingSpotType.ELECTRIC:
                    electricSpots.Remove((ElectricSpot)parkingSpot);
                    return true;
                case ParkingSpotType.MOTORBIKE:
                    motorBikeSpots.Remove((MotorBikeSpot)parkingSpot);
                    return true;
                default:
                    return false;
            }
        }
    }
}
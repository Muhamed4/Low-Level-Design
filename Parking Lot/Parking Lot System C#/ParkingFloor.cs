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
        public List<HandiCappedSpot> handiCappedSpots { get; private set; }
        public List<CompactSpot> compactSpots  { get; private set; }
        public List<LargeSpot> largeSpots { get; private set; }
        public List<ElectricSpot> electricSpots { get; private set; }
        public List<MotorBikeSpot> motorBikeSpots { get; private set; }
        private event Action<int, int, int, int, int> _showMessage;
        public ParkingFloor(string _title) {
            this.title = _title;
            displayBoard = new DisplayBoard(title, ref _showMessage);
            customerInfoPortal = new CustomerInfoPortal();
        }

        private void Publish() {
            int NHandiCapped = handiCappedSpots.Count;
            int NCompactSpot = compactSpots.Count;
            int NLarge = largeSpots.Count;
            int NMotorBike = motorBikeSpots.Count;
            int NElectric = electricSpots.Count;
            if(_showMessage != null) {
                _showMessage?.Invoke(NHandiCapped, NCompactSpot, NLarge, NMotorBike, NElectric);
            }
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
            this.Publish();
        }

        public bool RemoveParkingSpot(ParkingSpot parkingSpot) {
            if(parkingSpot == null)
                return false;
            switch (parkingSpot.GetParkingSpotType())
            {
                case ParkingSpotType.HANDICAPPED:
                    handiCappedSpots.Remove((HandiCappedSpot)parkingSpot);
                    break;
                case ParkingSpotType.COMPACT:
                    compactSpots.Remove((CompactSpot)parkingSpot);
                    break;
                case ParkingSpotType.LARGE:
                    largeSpots.Remove((LargeSpot)parkingSpot);
                    break;
                case ParkingSpotType.ELECTRIC:
                    electricSpots.Remove((ElectricSpot)parkingSpot);
                    break;
                case ParkingSpotType.MOTORBIKE:
                    motorBikeSpots.Remove((MotorBikeSpot)parkingSpot);
                    break;
                default:
                    return false;
            }
            this.Publish();
            return true;
        }

        public bool AssignVehicle(Vehicle vehicle, ParkingSpot parkingSpot) {
            if(vehicle is null || parkingSpot is null)
                return false;
            parkingSpot.ParkVehicle(vehicle);
            this.Publish();
            return true;
        }

        public bool UnAssignVehicle(ParkingSpot parkingSpot) {
            if(parkingSpot == null)
                return false;
            parkingSpot.UnParkVehicle();
            this.Publish();
            return true;
        }
    }
}
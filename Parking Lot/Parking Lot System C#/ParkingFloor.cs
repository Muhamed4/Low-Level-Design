using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ParkingFloor
    {
        private string title;
        private IShowMessage displayBoard;
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
        // public bool AddParkingSpot(ParkingSpot parkingSpot) {
        //     if(parkingSpot == null) 
        //         return false;
        //     switch (parkingSpot.GetParkingSpotType())
        //     {
        //         case ParkingSpotType.HANDICAPPED:
        //             handiCappedSpots.Add((HandiCappedSpot)parkingSpot);
        //             break;
        //         case ParkingSpotType.COMPACT:
        //             compactSpots.Add((CompactSpot)parkingSpot);
        //             break;
        //         case ParkingSpotType.LARGE:
        //             largeSpots.Add((LargeSpot)parkingSpot);
        //             break;
        //         case ParkingSpotType.ELECTRIC:
        //             electricSpots.Add((ElectricSpot)parkingSpot);
        //             break;
        //         case ParkingSpotType.MOTORBIKE:
        //             motorBikeSpots.Add((MotorBikeSpot)parkingSpot);
        //             break;
        //         default:
        //             Console.WriteLine("Invalid Parking Spot Type");
        //             return false;
        //     }
        //     this.Publish();
        //     return true;
        // }


        // Applying Open / Closed Principle

        public bool AddParkingSpot(ParkingSpot parkingSpot) {
            if(parkingSpot == null) 
                return false;
            bool Ok = parkingSpot.AddParkingSpot(parkingSpot, this);
            if(Ok == false)
                return false;
            this.Publish();
            return true;
        }

        // public bool RemoveParkingSpot(ParkingSpot parkingSpot) {
        //     if(parkingSpot == null)
        //         return false;
        //     switch (parkingSpot.GetParkingSpotType())
        //     {
        //         case ParkingSpotType.HANDICAPPED:
        //             handiCappedSpots.Remove((HandiCappedSpot)parkingSpot);
        //             break;
        //         case ParkingSpotType.COMPACT:
        //             compactSpots.Remove((CompactSpot)parkingSpot);
        //             break;
        //         case ParkingSpotType.LARGE:
        //             largeSpots.Remove((LargeSpot)parkingSpot);
        //             break;
        //         case ParkingSpotType.ELECTRIC:
        //             electricSpots.Remove((ElectricSpot)parkingSpot);
        //             break;
        //         case ParkingSpotType.MOTORBIKE:
        //             motorBikeSpots.Remove((MotorBikeSpot)parkingSpot);
        //             break;
        //         default:
        //             return false;
        //     }
        //     this.Publish();
        //     return true;
        // }


        // Applying Open / Closed Principle

        public bool RemoveParkingSpot(ParkingSpot parkingSpot) {
            if(parkingSpot == null)
                return false;
            bool Ok = parkingSpot.RemoveParkingSpot(parkingSpot, this);
            if(Ok == false)
                return false;
            this.Publish();
            return true;
        }

        public bool AssignVehicle(Vehicle vehicle, ParkingSpot parkingSpot) {
            if(vehicle is null || parkingSpot is null)
                return false;
            bool Ok = parkingSpot.ParkVehicle(vehicle);
            if(Ok == false)
                return false;
            this.Publish();
            return true;
        }

        public bool UnAssignVehicle(ParkingSpot parkingSpot) {
            if(parkingSpot == null)
                return false;
            bool Ok = parkingSpot.UnParkVehicle();
            if(Ok == false)
                return false;
            this.Publish();
            return true;
        }
    }
}
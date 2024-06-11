using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ParkingLot
    {
        public List<ParkingSpot> parkingSpots { get; private set; }
        public ParkingLot()
        {
            parkingSpots = new List<ParkingSpot>() 
            {
                new ParkingSpot() { SpotNum = 1, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 2, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 3, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 4, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 5, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 6, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 7, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 8, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 9, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 10, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 11, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 12, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 13, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 14, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 15, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 16, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 17, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 18, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 19, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 19, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 20, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 20, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 22, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 22, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 23, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 24, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 25, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 26, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 27, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 27, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 28, SpotType = Type.FourWheel, Price = 0.50M, isFree = false },
                new ParkingSpot() { SpotNum = 29, SpotType = Type.TowWheel, Price = 0.30M, isFree = false },
                new ParkingSpot() { SpotNum = 30, SpotType = Type.FourWheel, Price = 0.50M, isFree = false }
            };
        }

        public List<ParkingSpot> listAllFreeParkingSpots()
            => parkingSpots.Where(sp => sp.isFree == false).ToList();
        
    }
}
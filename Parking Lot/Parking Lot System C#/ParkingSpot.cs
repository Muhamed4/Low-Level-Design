using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ParkingSpot
    {
        public int SpotNum { get; set; }
        public Type SpotType { get; set; }
        public decimal Price { get; set; }
        public bool isFree { get; set; }
        public ParkingSpot() { }
        public ParkingSpot(int spotNum, Type spotType, decimal price, bool _isFree)
        {
            this.SpotNum = spotNum;
            this.SpotType = spotType;
            this.Price = price;
            this.isFree = _isFree;
        }
        public int getSpotNum() => SpotNum;
        public Type getSpotType() => SpotType;
        public decimal getPrice() => Price;
        public bool isFreeSpot() => isFree;
    }
}
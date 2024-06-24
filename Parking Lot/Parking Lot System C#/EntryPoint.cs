using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class EntryPoint
    {
        public Ticket GenerateTicket(string floorTitle, ParkingSpot parkingSpot, Vehicle vehicle)
            => new(floorTitle, parkingSpot, vehicle);
    }
}
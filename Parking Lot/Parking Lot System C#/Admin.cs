using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class Admin : Account
    {
        public Admin(string userName, string password, Person person)
        {
            UserName = userName;
            Password = password;
            Person = person;
            AccountStatus = AccountStatus.ACTIVE;
        }
        public bool AddEntryPoint(EntryPoint entryPoint) => throw new NotImplementedException();
        public bool AddExitPoint(ExitPoint exitPoint) => throw new NotImplementedException();
        public bool AddParkingFloor(string floorTitle) => throw new NotImplementedException();
        public bool AddParkingSpot(string floorTitle, ParkingSpot parkingSpot) => throw new NotImplementedException();
        public bool AddDisplayBoard(string floorTitle, DisplayBoard displayBoard) => throw new NotImplementedException();
        public bool AddCustomerInfoPortal(string floorTitle, CustomerInfoPortal customerInfoPortal) => throw new NotImplementedException();
        public bool AddParkingAttendant(ParkingAttendant parkingAttendant) => throw new NotImplementedException();
    }
}
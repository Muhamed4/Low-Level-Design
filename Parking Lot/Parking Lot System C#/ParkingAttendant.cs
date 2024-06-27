using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ParkingAttendant : Account
    {
        private CashPayment cashPayment;
        public ParkingAttendant(string userName, string password, Person person, CashPayment _cashPayment)
        {
            UserName = userName;
            Password = password;
            Person = person;
            AccountStatus = AccountStatus.ACTIVE;
            cashPayment = _cashPayment;
        }

        public double CalculateAmount(Ticket ticket) => cashPayment.MakePayment(ticket);
        public void Paid(Ticket ticket) => cashPayment.Paid(ticket);
    }
}
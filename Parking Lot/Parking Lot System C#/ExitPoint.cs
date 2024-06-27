using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public class ExitPoint
    {
        public string ExitId { get; private set; }
        public ExitPoint(string exitId)
        {
            ExitId = exitId;
        }
        private CreditCardPayment creditCardPayment;
        public ExitPoint(CreditCardPayment _creditCardPayment) {
            this.creditCardPayment = _creditCardPayment;
        }
        public bool ScanTicket(Ticket ticket) {
            if(ticket == null || ticket.PaymentStatus == PaymentStatus.ACTIVE)
                return false;
            return true;
        }

        public double PayTicket(Ticket ticket) 
            => this.creditCardPayment.MakePayment(ticket);

        public bool FreeParkingSpot(Ticket ticket) => ticket.ParkingSpot.UnParkVehicle();
    }
}
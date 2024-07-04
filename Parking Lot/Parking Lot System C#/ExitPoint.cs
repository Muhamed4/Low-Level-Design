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
        public async Task<bool> ScanTicket(Ticket ticket) {
            return await Task.Run(() => {
                if(ticket == null || ticket.PaymentStatus == PaymentStatus.ACTIVE)
                    return false;
                return true;
            });
        }

        public async Task<double> PayTicket(Ticket ticket) 
            => await Task.Run(() => creditCardPayment.MakePayment(ticket));

        public Task<bool> FreeParkingSpot(Ticket ticket) => 
            Task.Run(() => ticket.ParkingSpot.UnParkVehicle());
    }
}
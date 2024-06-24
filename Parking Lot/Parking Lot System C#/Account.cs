using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public abstract class Account
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public AccountStatus AccountStatus { get; private set; }
        public Person Person { get; private set; }
    }
}
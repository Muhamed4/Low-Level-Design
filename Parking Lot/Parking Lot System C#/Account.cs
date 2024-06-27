using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_System_C_
{
    public abstract class Account
    {
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public AccountStatus AccountStatus { get; protected set; }
        public Person Person { get; protected set; }
    }
}
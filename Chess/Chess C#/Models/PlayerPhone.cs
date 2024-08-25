using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess_C_.Models
{
    public class PlayerPhone
    {
        public Guid PlayerId { get; set; }
        public string Phone { get; set; } = null!;
        public Player Player { get; set; } = null!;
    }
}
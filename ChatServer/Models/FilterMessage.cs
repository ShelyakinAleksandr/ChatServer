using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    public class FilterMessage
    {
        public bool Filter { get; set; }
        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
    }
}

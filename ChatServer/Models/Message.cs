using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    public class Message
    {
        public DateTime DateTimeMessege { get; set; }
        public string NameUser { get; set; }
        public string Messeges { get; set; }
    }
}

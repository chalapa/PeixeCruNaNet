using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Shokudo.Entities
{
    class Request
    {
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public int ClientID { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public float Value { get; set; }
        public string Comments { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Shokudo.Entities
{
    class Client
    {
        public int ClientID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Adress { get; set; }
        public int Cell { get; set; }

    }
}

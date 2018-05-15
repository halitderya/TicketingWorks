using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.DAL
{
    public class ListTicket
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public string customerSurname { get; set; }
        public string customerCompanyName { get; set; }
        public string customerCompanyAdress { get; set; }
        public string customerCompanyPhone { get; set; }
        public string customerPhone { get; set; }
        public int ticketID { get; set; }
        public int statusID { get; set; }
        public string tripFrom { get; set; }
        public string tripTo { get; set; }
        public Nullable<short> asDirected { get; set; }
        public Nullable<System.DateTime> pickTime { get; set; }
        public Nullable<bool> payment { get; set; }
        public string statusName { get; set; }
        public Nullable<System.DateTime> statusDate { get; set; }
        public string assignedTo { get; set; }
        public Nullable <bool> isBusiness { get; set; }
    }
}

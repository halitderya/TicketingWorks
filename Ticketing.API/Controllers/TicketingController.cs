using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticketing.DAL;

namespace Ticketing.API.Controllers
{
    public class TicketingController : ApiController
    {
        TicketingDAL ticketing = new TicketingDAL();
        public IEnumerable<ListTicket> GetOpenTickets()
        {

            
            return ticketing.GetOpenTickets();
        }

        public IEnumerable<ListTicket> GetAllTickets()
        {


            return ticketing.GetAllTickets();
        }
        public Ticket Get(int id)
        {

            return ticketing.GetTicketByID(id);
        }


        public Ticket Post(Ticket ticket)
        {
            return ticketing.CreateNewTicket(ticket);
        }


        [HttpPut]
        public Ticket PutStatus (int id, string status)
        {

            return ticketing.ChangeStatus(id, status);
        }

        public Ticket Put(int id, Ticket ticket)
        {

            return ticketing.UpdateTicket(id, ticket);
        }
        public void Delete(int id)
        {

            ticketing.DeleteTicket(id);


        }
    }
}

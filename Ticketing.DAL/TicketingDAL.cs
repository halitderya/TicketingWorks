using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.DAL
{
    public class TicketingDAL
    {
        TicketingAPIEntities db = new TicketingAPIEntities();
        Ticket Ticket = new Ticket();
        public IEnumerable<ListTicket> GetAllTickets()
        {


            var result = from s in db.Status
                         where s.statusDate ==
                             (from s2 in db.Status
                              where s2.ticketID == s.ticketID
                              select new
                              {
                                  s2.statusDate
                              }).Max(p => p.statusDate)
                         select new ListTicket
                         {

                             assignedTo = s.assignedTo,
                             statusID = s.statusID,
                             statusDate = s.statusDate,
                             ticketID = s.ticketID,
                             tripFrom = s.Ticket.tripFrom,
                             tripTo = s.Ticket.tripTo,
                             statusName = s.statusName,
                             customerName = s.Ticket.Customer.customerName,
                             customerSurname = s.Ticket.Customer.customerSurname,
                             asDirected = s.Ticket.asDirected,
                             customerCompanyAdress = s.Ticket.Customer.customerCompanyAdress,
                             customerCompanyName = s.Ticket.Customer.customerCompanyName,

                             customerCompanyPhone = s.Ticket.Customer.customerCompanyPhone,
                             customerID = s.Ticket.Customer.customerID,
                             customerPhone = s.Ticket.Customer.customerPhone,
                             payment = s.Ticket.payment,
                             pickTime =s.Ticket.pickTime


                         };




            return result;
        }
        public IEnumerable<ListTicket> GetOpenTickets()
        {

            var result  = from s in db.Status
                          where
                            s.statusDate ==
                              (from s2 in db.Status
                               where s2.ticketID == s.ticketID
                               select new
                               { s2.statusDate }).Max(p => p.statusDate) &&
                            (s.statusName == "New" ||
                            s.statusName == "Assigned")
                          select new ListTicket
                         {
                             statusID = s.statusID,
                             ticketID = s.ticketID,
                             statusName = s.statusName,
                             statusDate = s.statusDate,
                             assignedTo = s.assignedTo,
                             customerID = (int)s.Ticket.customerID,
                             tripFrom = s.Ticket.tripFrom,
                             tripTo = s.Ticket.tripTo,
                             asDirected = s.Ticket.asDirected,
                             pickTime = (DateTime?)s.Ticket.pickTime,
                             payment = (bool?)s.Ticket.payment,
                             customerName = s.Ticket.Customer.customerName,
                             customerSurname = s.Ticket.Customer.customerSurname,
                             customerCompanyName = s.Ticket.Customer.customerCompanyName,
                             customerCompanyAdress = s.Ticket.Customer.customerCompanyAdress,
                             customerCompanyPhone = s.Ticket.Customer.customerCompanyPhone,
                             customerPhone = s.Ticket.Customer.customerPhone,
                             isBusiness = (bool?)s.Ticket.Customer.isBusiness
                         };



            return result;
        }
        public Ticket GetTicketByID(int id)
        {
            db.Ticket.Find(id);
            return db.Ticket.Find(id);
        }
        public Ticket CreateNewTicket(Ticket ticket)
        {
            //Method adds new ticket to db. Also creates new correspond customer and status entries.


            db.Ticket.Add(ticket);
            db.SaveChanges();
            //Ticket.StatusID assigning manually, because status creates after ticket created.
            ticket.statusID = db.Status.First(c => c.ticketID == ticket.ticketID).statusID;
            
            db.SaveChanges();
            return ticket;
        }
        public Ticket UpdateTicket(int id, Ticket ticket)
        {
            db.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return ticket;

        }
        public Ticket ChangeStatus(int id,string status)
        {

            Status newstatus = new Status();
            newstatus.statusName = status;
            newstatus.ticketID = id;
            
            
            var willupdate = db.Ticket.Find(id);
            willupdate.Status.Add(newstatus);

            return willupdate;

        }
        public void DeleteTicket(int id)
        {
            
            db.Ticket.Remove(db.Ticket.Find(id));

        }
    }
}

using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class TicketProcessor
    {
        public static int CreateTicket(string title, string description = "",
            string type = "Bug", string resolver = "", string priority = "High")
        {
            TicketModel ticket = new TicketModel
            {
                Title = title,
                Description = description,
                Type = type,
                Resolver = resolver,
                Priority = priority,
                Status = "In Development",
                Submitter = "Anonymous",
                Timestamp = DateTime.Now.ToString(),
            };

            return FirestoreDataAccess.SaveData(ticket, "Tickets");
        }

        public static async Task<List<TicketModel>> LoadTickets()
        {
            return await FirestoreDataAccess.LoadData<TicketModel>("Tickets");
        }
    }
}

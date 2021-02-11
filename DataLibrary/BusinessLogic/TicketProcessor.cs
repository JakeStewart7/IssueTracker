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
        public static int CreateTicket(string title, string projectName, string description = "",
            string type = "Bug", string resolver = "", string priority = "High")
        {
            TicketModel ticket = new TicketModel
            {
                Title = title,
                ProjectName = projectName,
                Description = description,
                Type = type,
                Resolver = resolver,
                Priority = priority,
                Status = "In Development",
                Submitter = "Anonymous",
                Timestamp = DateTime.Now.ToString(),
            };

            return FirestoreDataAccess.SaveDataToCollection(ticket, "Tickets");
        }

        public static async Task<List<TicketModel>> LoadTickets()
        {
            return await FirestoreDataAccess.LoadCollection<TicketModel>("Tickets");
        }
    }
}

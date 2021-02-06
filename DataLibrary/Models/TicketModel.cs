using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class TicketModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Resolver { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Submitter { get; set; }
        public string Timestamp { get; set; }
    }
}

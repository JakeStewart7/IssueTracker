using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class TicketModel
    {
        [Required(ErrorMessage = "You need to enter a title for your ticket.")]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must assign this ticket to a project.")]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        

        [Required(ErrorMessage = "You need to select a ticket type.")]
        public string Type { get; set; }
        public string Resolver { get; set; }

        [Required(ErrorMessage = "You must enter a priority for your ticket.")]
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Submitter { get; set; }
        public string Timestamp { get; set; }
    }
}
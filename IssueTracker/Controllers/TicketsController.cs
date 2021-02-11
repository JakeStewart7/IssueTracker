using DataLibrary.BusinessLogic;
using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class TicketsController : Controller
    {
        public async Task<ActionResult> ViewTickets()
        {
            ViewBag.Message = "Ticket List";

            var data = await TicketProcessor.LoadTickets();
            List<TicketModel> tickets = new List<TicketModel>();

            foreach (var row in data)
            {
                tickets.Add(new TicketModel
                {
                    Title = row.Title,
                    ProjectName = row.ProjectName,
                    Description = row.Description,
                    Type = row.Type,
                    Resolver = row.Resolver,
                    Priority = row.Priority,
                    Status = row.Status,
                    Submitter = row.Submitter,
                    Timestamp = row.Timestamp
                });
            }

            return View(tickets);
        }

        public async Task<ActionResult> CreateTicket()
        {
            ViewBag.Message = "Create a Ticket";

            var data = await ProjectProcessor.LoadProjects();
            List<string> projectTitles = new List<string>();

            foreach (var row in data)
            {
                projectTitles.Add(row.Name);
            }
            ViewBag.ProjectTitles = projectTitles;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTicket(TicketModel model)
        {
            if (ModelState.IsValid)
            {
                TicketProcessor.CreateTicket(model.Title,
                    model.ProjectName,
                    model.Description,
                    model.Type,
                    model.Resolver,
                    model.Priority);
                return RedirectToAction("ViewTickets");
            }

            return View();
        }
    }
}

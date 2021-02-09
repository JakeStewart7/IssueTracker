using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.BusinessLogic;
using System.Threading.Tasks;

namespace IssueTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult CreateTicket()
        {
            ViewBag.Message = "Create a Ticket";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTicket(TicketModel model)
        {
            if (ModelState.IsValid)
            {
                TicketProcessor.CreateTicket(model.Title,
                    model.Description,
                    model.Type,
                    model.Resolver,
                    model.Priority);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
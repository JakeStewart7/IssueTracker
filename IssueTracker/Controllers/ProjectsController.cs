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
    public class ProjectsController : Controller
    {
        public async Task<ActionResult> ViewProjects()
        {
            ViewBag.Message = "Project List";

            var data = await ProjectProcessor.LoadProjects();
            List<ProjectModel> projects = new List<ProjectModel>();

            foreach (var row in data)
            {
                projects.Add(new ProjectModel
                {
                    Name = row.Name,
                    Description = row.Description,
                });
            }

            return View(projects);
        }

        public ActionResult CreateProject()
        {
            ViewBag.Message = "Create a Project";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectProcessor.CreateProject(model.Name, model.Description);
                return RedirectToAction("ViewProjects");
            }

            return View();
        }
    }
}
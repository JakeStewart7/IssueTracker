using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class ProjectProcessor
    {
        public static int CreateProject(string name, string description = "")
        {
            ProjectModel project = new ProjectModel
            {
                Name = name,
                Description = description
            };

            return FirestoreDataAccess.SaveData(project, "Projects");
        }

        public static async Task<List<ProjectModel>> LoadProjects()
        {
            return await FirestoreDataAccess.LoadData<ProjectModel>("Projects");
        }
    }
}

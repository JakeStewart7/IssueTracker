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
        public static async Task<int> CreateProject(string projectName, string description = "")
        {
            string collectionName = "Projects";

            // Ensure project name is unique before continuing
            bool isUniqueName = await IsUniqueProjectName(projectName, collectionName);
            if (isUniqueName == false)
            {
                throw new InvalidOperationException();
            }

            ProjectModel project = new ProjectModel
            {
                Name = projectName,
                Description = description
            };

            return FirestoreDataAccess.SaveDataToCollection(project, collectionName);
        }

        public static async Task<List<ProjectModel>> LoadProjects()
        {
            return await FirestoreDataAccess.LoadCollection<ProjectModel>("Projects");
        }

        public static async Task<bool> IsUniqueProjectName(string projectName, string collectionName)
        {
            bool docExists = await FirestoreDataAccess.DocumentExists("Name", projectName, collectionName);
            bool isUnique = !docExists;
            return isUnique;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class ProjectModel
    {
        [Required(ErrorMessage = "You must enter a project name.")]
        [StringLength(50, ErrorMessage = "Project name is too long.")]
        public string Name { get; set; }
        
        [StringLength(100, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }
    }
}
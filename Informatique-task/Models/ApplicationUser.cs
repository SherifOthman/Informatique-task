using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Informatique_task.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }


        public  ICollection<TaskItem> CreatedTasks { get; set; } = new List<TaskItem>();

        public ICollection<TaskItem> AssignedTasks { get; set; }
            = new List<TaskItem>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Informatique_task.Models
{
    using Informatique_task.Enums;
    using System;
    using System.Collections.Generic;

    namespace TaskManagementSystem.Models
    {
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public string FullName { get; set; }
            public UserRole Role { get; set; }
            public DateTime CreatedAt { get; set; }

            public virtual ICollection<TaskItem> CreatedTasks { get; set; }
            public virtual ICollection<TaskItem> AssignedTasks { get; set; }
        }
    }
}
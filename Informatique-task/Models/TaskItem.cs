using Informatique_task.Enums;
using Informatique_task.Models.TaskManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Informatique_task.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime AssignedDate { get; set; }
        public TaskStatus Status { get; set; }
        public string AttachmentPath { get; set; }
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public int AssignedToId { get; set; }
        public virtual User AssignedTo { get; set; }
    }
}
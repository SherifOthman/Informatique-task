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
        public string AttachmentPath { get; set; }
        public string CreatedById { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public string AssignedToId { get; set; }
        public virtual ApplicationUser AssignedTo { get; set; }
    }
}
using Informatique_task.Data;
using Informatique_task.Enums;
using System;
using System.Linq;

namespace Informatique_task.Pages.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public int newCount = 0;
        public int inProgressCount = 0;
        public int completedCount = 0;
        public int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                newCount = db.Tasks.Count(t => t.Status == TaskStatus.New);
                inProgressCount = db.Tasks.Count(t => t.Status == TaskStatus.InProgress);
                completedCount = db.Tasks.Count(t => t.Status == TaskStatus.Completed);
                totalCount = db.Tasks.Count();
            }
        }
    }
}

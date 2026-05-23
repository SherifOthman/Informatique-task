using Informatique_task.Data;
using Informatique_task.Enums;
using Informatique_task.Infrastructure;
using System;
using System.Linq;

namespace Informatique_task.Pages.Admin
{
    public partial class Dashboard : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                lblNewCount.Text = db.Tasks.Count(t => t.Status == TaskStatus.New).ToString();
                lblInProgressCount.Text = db.Tasks.Count(t => t.Status == TaskStatus.InProgress).ToString();
                lblCompletedCount.Text = db.Tasks.Count(t => t.Status == TaskStatus.Completed).ToString();
                lblTotalCount.Text = db.Tasks.Count().ToString();
            }
        }
    }
}

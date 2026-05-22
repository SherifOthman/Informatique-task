using Informatique_task.Data;
using Informatique_task.Enums;
using System;
using System.Linq;

namespace Informatique_task.Pages.Admin
{
    public partial class Dashboard : System.Web.UI.Page
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

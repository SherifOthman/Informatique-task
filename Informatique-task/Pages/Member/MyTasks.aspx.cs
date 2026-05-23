using Informatique_task.Data;
using Informatique_task.Infrastructure;
using Informatique_task.Pages.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatique_task.Pages.Member
{
    public partial class MyTasks : MemberBasePage
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTasks();
                LoadNotifications();
            }
        }

        private void LoadTasks()
        {
            int userId = (int)Session["UserId"];

            var tasks = db.Tasks
                .Where(t => t.AssignedToId == userId)
                .Select(t => new
                {
                    t.Id,
                    t.Title,
                    StatusText = t.Status,
                    AssignedDateText = t.AssignedDate
                })
                .ToList();

            gvTasks.DataSource = tasks;
            gvTasks.DataBind();
        }

        private void LoadNotifications()
        {
            int userId = (int)Session["UserId"];

            DateTime threeDaysAgo = DateTime.Now.AddDays(-3);

            var notifications = db.Tasks
                .Where(t =>
                    t.AssignedToId == userId &&
                    t.Status == Enums.TaskStatus.New &&
                    t.AssignedDate <= threeDaysAgo)
                .ToList();

            if (notifications.Any())
            {
                pnlNotifications.Visible = true;

                foreach(var task in notifications)
                {
                    blNotifications.Items.Add(
                        $"Task '{task.Title}' is still new after 3 days.");
                }
            }
        }
    }
}
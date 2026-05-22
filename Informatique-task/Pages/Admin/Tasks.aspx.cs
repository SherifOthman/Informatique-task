using Informatique_task.Data;
using Informatique_task.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatique_task.Pages.Admin
{
    public partial class Tasks : System.Web.UI.Page
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadStatuses();
                LoadTasks();
            }
        }

        private void LoadUsers()
        {
            var users = db.Users
                .Where(u => u.Role == Enums.UserRole.Member)
                .ToList();

            ddlUsers.DataSource = users;
            ddlUsers.DataTextField = "FullName";
            ddlUsers.DataValueField = "Id";
            ddlUsers.DataBind();

            ddlUsers.Items.Insert(0, "All");
        }

        private void LoadStatuses()
        {
            ddlStatus.Items.Add("All");
            ddlStatus.Items.Add("New");
            ddlStatus.Items.Add("InProgress");
            ddlStatus.Items.Add("Completed");
        }

        private void LoadTasks()
        {
            var query = db.Tasks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                query = query.Where(t => t.Title.Contains(txtSearch.Text));
            }

            if(ddlUsers.SelectedIndex> 0)
            {
                int userId = int.Parse(ddlUsers.SelectedValue);
                
                query = query.Where(t => t.AssignedToId == userId);
            }

            if(ddlStatus.SelectedIndex > 0)
            {
                TaskStatus status = (TaskStatus)Enum.Parse(typeof(TaskStatus), ddlStatus.SelectedValue);

                query = query.Where(t => t.Status == status);
            }

            var tasks = query
              .Select(t => new
              {
                  t.Id,
                  t.Title,
                  AssignedToName =t.AssignedTo.FullName,
                  StatusText = t.Status.ToString()
              })
              .ToList();

            gvTasks.DataSource = tasks;
            gvTasks.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }

    }
}
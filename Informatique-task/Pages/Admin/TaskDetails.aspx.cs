using Informatique_task.Data;
using Informatique_task.Enums;
using Informatique_task.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Informatique_task.Pages.Admin
{
    public partial class TaskDetails : System.Web.UI.Page
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private int taskId;
        private int previousAssignedToId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["id"], out taskId))
            {
                lblMessage.Text = "Invalid task ID.";
                pnlDetails.Visible = false;
                return;
            }

            if (!IsPostBack)
            {
                LoadUsers();
                LoadTask();
            }
        }

        private void LoadUsers()
        {
            var users = db.Users
                .Where(u => u.Role == UserRole.Member)
                .ToList();

            ddlUsers.DataSource = users;
            ddlUsers.DataTextField = "FullName";
            ddlUsers.DataValueField = "Id";
            ddlUsers.DataBind();
        }

        private void LoadTask()
        {
            var task = db.Tasks.Include(t => t.AssignedTo).FirstOrDefault(t => t.Id == taskId);

            if (task == null)
            {
                lblMessage.Text = "Task not found.";
                pnlDetails.Visible = false;
                return;
            }

            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            lblCreatedDate.Text = task.CreatedDate.ToString("yyyy-MM-dd hh:mm tt");
            lblAssignedDate.Text = task.AssignedDate.ToString("yyyy-MM-dd hh:mm tt");

            previousAssignedToId = task.AssignedToId;
            ddlUsers.SelectedValue = task.AssignedToId.ToString();

            ddlStatus.SelectedValue = task.Status.ToString();

            if (!string.IsNullOrEmpty(task.AttachmentPath))
            {
                lnkAttachment.NavigateUrl = task.AttachmentPath;
                lnkAttachment.Visible = true;
                lblNoAttachment.Visible = false;
            }
            else
            {
                lnkAttachment.Visible = false;
                lblNoAttachment.Visible = true;
            }

            bool isNew = task.Status == TaskStatus.New;
            txtTitle.Enabled = isNew;
            txtDescription.Enabled = isNew;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var task = db.Tasks.FirstOrDefault(t => t.Id == taskId);

            if (task == null)
            {
                lblMessage.Text = "Task not found.";
                return;
            }

            if (task.Status == TaskStatus.New)
            {
                task.Title = txtTitle.Text;
                task.Description = txtDescription.Text;
            }

            int newAssignedToId = int.Parse(ddlUsers.SelectedValue);
            if (newAssignedToId != task.AssignedToId)
            {
                task.AssignedToId = newAssignedToId;
                task.AssignedDate = DateTime.Now;
            }

            task.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), ddlStatus.SelectedValue);

            db.SaveChanges();
            lblMessage.CssClass = "success";
            lblMessage.Text = "Task updated successfully.";

            LoadTask();
        }
    }
}

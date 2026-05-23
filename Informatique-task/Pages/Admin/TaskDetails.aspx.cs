using Informatique_task.Data;
using Informatique_task.Enums;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Informatique_task.Pages.Admin
{
    public partial class TaskDetails : System.Web.UI.Page
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private int TaskId
        {
            get { return int.Parse(Request.QueryString["id"]); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUsers();
                LoadTask();
            }
        }

        private void LoadUsers()
        {
            var users = db.Users.Where(u => u.Role == UserRole.Member).ToList();
            ddlUsers.DataSource = users;
            ddlUsers.DataTextField = "FullName";
            ddlUsers.DataValueField = "Id";
            ddlUsers.DataBind();
        }

        private void LoadTask()
        {
            var task = db.Tasks.FirstOrDefault(t => t.Id == TaskId);

            if (task == null)
            {
                lblMessage.Text = "Task not found.";
                btnSave.Visible = false;
                return;
            }

            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            ddlUsers.SelectedValue = task.AssignedToId.ToString();

            ddlStatus.ClearSelection();
            foreach (ListItem item in ddlStatus.Items)
                item.Enabled = true;

            if (task.Status == TaskStatus.InProgress)
                ddlStatus.Items.FindByValue("New").Enabled = false;
            else if (task.Status == TaskStatus.Completed)
            {
                ddlStatus.Items.FindByValue("New").Enabled = false;
                ddlStatus.Items.FindByValue("InProgress").Enabled = false;
            }

            ddlStatus.SelectedValue = task.Status.ToString();


            lblCreatedDate.Text = task.CreatedDate.ToString("dd-MM-yyyy h:mm tt");
            lblAssignedDate.Text = task.AssignedDate.ToString("dd-MM-yyyy h:mm tt");

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
            bool isCompleted = task.Status == TaskStatus.Completed;

            txtTitle.Enabled = isNew;
            txtDescription.Enabled = isNew;
            rfvTitle.Enabled = isNew;
            rfvDescription.Enabled = isNew;
            ddlUsers.Enabled = !isCompleted;
            ddlStatus.Enabled = !isCompleted;
            btnSave.Visible = !isCompleted;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var task = db.Tasks.FirstOrDefault(t => t.Id == TaskId);

            if (task == null)
            {
                lblMessage.Text = "Task not found.";
                return;
            }

            if (task.Status == TaskStatus.Completed)
                return;

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

            //Response.Redirect("~/Pages/Admin/Tasks.aspx");

            LoadTask();
        }
    }
}

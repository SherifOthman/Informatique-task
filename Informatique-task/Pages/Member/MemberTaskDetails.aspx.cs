using Informatique_task.Data;
using Informatique_task.Enums;
using Informatique_task.Infrastructure;
using Informatique_task.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Informatique_task.Pages.Member
{
    public partial class MemberTaskDetails : MemberBasePage
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private int TaskId
        {
            get
            {
                int id;
                int.TryParse(Request.QueryString["id"], out id);
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadStatuses();
                LoadTask();
            }
        }

        private void LoadStatuses()
        {
            ddlStatus.DataSource = Enum.GetNames(typeof(TaskStatus));
            ddlStatus.DataBind();
        }

        private void LoadTask()
        {
            int userId = (int)Session["UserId"];

            var task = db.Tasks.FirstOrDefault(t =>
                 t.Id == TaskId &&
                 t.AssignedToId == userId);

            if (task == null)
            {
                Response.Redirect("~/Pages/Member/MyTasks.aspx");
                return;
            }

            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;

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
            btnSave.Visible = task.Status != TaskStatus.Completed;
            ddlStatus.Enabled = task.Status != TaskStatus.Completed;

            if (!string.IsNullOrEmpty(task.AttachmentPath))
            {
                lnkAttachment.NavigateUrl = task.AttachmentPath;
                lnkAttachment.Visible = true;
            }
            else
            {
                lnkAttachment.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserId"];
            var task = db.Tasks.FirstOrDefault(t =>
                 t.Id == TaskId &&
                 t.AssignedToId == userId);

            if (task == null)
                return;

            if (task.Status == TaskStatus.Completed)
                return;

            var newStatus = (TaskStatus)Enum.Parse(typeof(TaskStatus), ddlStatus.SelectedValue);

            if (task.Status == TaskStatus.InProgress && newStatus == TaskStatus.New)
            {
                lblMessage.Text = "Cannot change status from In Progress to New.";
                return;
            }

            task.Status = newStatus;
            db.SaveChanges();

            lblMessage.CssClass = "success";
            lblMessage.Text = "Status updated successfully";

            LoadTask();
        }
    }
}

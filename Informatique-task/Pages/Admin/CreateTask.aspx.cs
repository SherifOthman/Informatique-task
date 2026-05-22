using Informatique_task.Data;
using Informatique_task.Enums;
using Informatique_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatique_task.Pages.Admin
{
    public partial class CreateTask : System.Web.UI.Page
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUsers();
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

            ddlUsers.Items.Insert(0, "-- Select User --");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {


                int userId = int.Parse(ddlUsers.SelectedValue);

                if (userId == 0)
                {
                    lblMessage.Text = "Please select a user";
                    return;
                }

                string filePath = null;

                if (fileUpload.HasFile)
                {
                    string fileName = Guid.NewGuid() + "_" + fileUpload.FileName;
                    string path = Server.MapPath("~/Uploads/" + fileName);

                    fileUpload.SaveAs(path);

                    filePath = "/Uploads/" + fileName;
                }

                var task = new TaskItem
                {
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    AssignedToId = userId,
                    CreatedById = (int)Session["UserId"],

                    Status = TaskStatus.New,
                    CreatedDate = DateTime.Now,
                    AssignedDate = DateTime.Now,

                    AttachmentPath = filePath
                };

                db.Tasks.Add(task);
                db.SaveChanges();

                lblMessage.CssClass = "success";
                lblMessage.Text = "Task created successfully!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
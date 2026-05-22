using Informatique_task.Data;
using Informatique_task.Enums;
using Informatique_task.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatique_task.Pages.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdminFill_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "Admin@123";
            txtPassword.Attributes["value"] = "Admin@123";
        }

        protected void btnMemberFill_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "ahmed";
            txtPassword.Text = "123456";
            txtPassword.Attributes["value"] = "123456";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using(var db = new ApplicationDbContext())
            {
                var user = db.Users
                    .FirstOrDefault(x => x.Username == txtUsername.Text.Trim());

                if(user == null)
                {
                    lblError.Text = "Invalid username or password.";
                    return;
                }

                bool isValid = PasswordService.Verify(txtPassword.Text, user.PasswordHash);

                if (!isValid)
                {
                    lblError.Text = "Invalid username or password.";
                    return;
                }

                Session["UserId"] = user.Id;
                Session["Role"] = user.Role.ToString();
                Session["FullName"] = user.FullName;

                if(user.Role == UserRole.Admin)
                {
                    Response.Redirect("/Pages/Admin/Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("~/Pages/Member/MyTasks.aspx");
                }
            }
        }
    }
}
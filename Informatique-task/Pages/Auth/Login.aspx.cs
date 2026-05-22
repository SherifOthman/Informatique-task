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
                Session["Username"] = user.Id;
                Session["Role"] = user.Role.ToString();

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
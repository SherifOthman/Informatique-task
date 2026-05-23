using Informatique_task.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatique_task.Infrastructure
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("/Pages/Auth/Login.aspx");
                return;
            }

            base.OnLoad(e);
        }

        protected bool IsAdmin()
        {
            return Session["Role"] != null && (UserRole)Session["Role"] == UserRole.Admin;
        }

        protected bool IsMember()
        {
            return Session["Role"] != null && (UserRole)Session["Role"] == UserRole.Member;
        }
    }
}
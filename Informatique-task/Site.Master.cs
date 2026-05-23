using System;

namespace Informatique_task
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string p = Request.Url.AbsolutePath.ToLower();
            string activeClass = " sidebar-link active";

            if (p.Contains("dashboard"))
                lnkDashboard.CssClass += activeClass;
            else if (p.Contains("createtask"))
                lnkCreate.CssClass += activeClass;
            else if (p.Contains("tasks") && !p.Contains("mytasks"))
                lnkTasks.CssClass += activeClass;
            else if (lnkMyTasks != null && p.Contains("mytasks"))
                lnkMyTasks.CssClass += activeClass;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Pages/Auth/Login.aspx");
        }
    }
}

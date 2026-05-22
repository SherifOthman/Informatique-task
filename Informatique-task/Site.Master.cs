using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatique_task
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPage = Request.Url.AbsolutePath.ToLower();
            var nav = FindControl("sidebarNav") as Control;
            if (nav == null) return;

            foreach (Control ctrl in nav.Controls)
            {
                if (ctrl is HyperLink link)
                {
                    string linkUrl = ResolveUrl(link.NavigateUrl).ToLower();
                    if (currentPage == linkUrl || currentPage.StartsWith(linkUrl.TrimEnd('/')))
                        link.CssClass = (link.CssClass + " active").Trim();
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Pages/Auth/Login.aspx");
        }
    }
}

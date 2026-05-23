using Informatique_task.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Informatique_task.Infrastructure
{
    public partial class AdminBasePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsAdmin())
                Response.Redirect("/Pages/Auth/Login.aspx");
        }
    }
}
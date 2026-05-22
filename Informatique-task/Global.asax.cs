using Informatique_task.Seed;
using System;

namespace Informatique_task
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            DbSeeder.Seed();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RSVPsite
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long visitorsCount = 0;
            if (Application["Visitors"] != null)
            {
                visitorsCount = long.Parse(Application["Visitors"].ToString());
                VisitorLiteral.Text = "Number of visitors: " + visitorsCount.ToString();
            }
        }
    }
}
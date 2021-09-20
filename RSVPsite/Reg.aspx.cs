using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RSVPsite
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                GuestResponse newResponse = new GuestResponse(name.Text, email.Text, 
                    phone.Text, PresentYN.Checked);
                ResponseRepository.GetRepository().AddResponse(newResponse);

                if (newResponse.WillAttend.HasValue && newResponse.WillAttend.Value)
                {
                    Response.Redirect("seeyouthere.html");
                }
                else
                {
                    Response.Redirect("sorrynexttime.html");
                }
            }
        }
    }
}
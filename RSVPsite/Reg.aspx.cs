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
                if (PresentYN.Checked)
                {
                    Report report1 = new Report(TextBoxTitle.Text,
                   TextBoxTextAnnot.Text);
                    newResponse.Reports.Add(report1);
                }
                if (TextBoxTitle2.Text != "" || TextBoxTextAnnot2.Text != "")
                {
                    Report report2 = new Report(TextBoxTitle2.Text,
                   TextBoxTextAnnot2.Text);
                    newResponse.Reports.Add(report2);
                }

                try
                {
                    SampleContext context = new SampleContext();
                    context.GuestResponses.Add(newResponse);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error " + ex.Message);
                }

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
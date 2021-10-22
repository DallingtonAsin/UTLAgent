using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTLAgent.TransApi;

namespace UTLAgent.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UTLUsername"] == null && Session["UTLUserPassword"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                //do nothing

            }
            SetHomeStats();

        }


        protected void SetHomeStats()
        {
            Api api = new Api();
            object[] response = api.SystemOverview();
            if(response[0] != null)
            {
                registeredAgentsTxt.Text = Convert.ToString(number_format(Convert.ToInt32(response[0])));
                PendingReqTxt.Text = Convert.ToString(number_format(Convert.ToInt32(response[1])));
                ApprovedReqTxt.Text = Convert.ToString(number_format(Convert.ToInt32(response[2])));
                lowfloatedAgentsTxt.Text = Convert.ToString(number_format(Convert.ToInt32(response[3])));
            }
        }

        public static string number_format(int number)
        {
            string formated_number = string.Format("{0:n0}", number);
            return formated_number;
        }




    }
}
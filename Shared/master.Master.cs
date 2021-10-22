using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTLAgent.TransApi;

namespace UTLAgent.Shared
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UTLUsername"] == null && Session["UTLUserPassword"] == null)
            {
                Page.Response.Redirect("Default.aspx", true);
            }
            else
            {
                Api api = new Api();
                string username = Session["UTLUsername"].ToString();
                object[] obj = api.GetUserDetails(username);
                string names = obj[1].ToString() + " " + obj[2].ToString();
                loggedinUserTxt.Text = names;
                //LogoutNameTxt.Text = names;
            }
            if (!IsPostBack)
            {


            }

        }

        protected void Logout()
        {
            Session.Remove("UTLUsername");
            Session.Remove("UTLUserPassword");
            Response.Redirect("Default.aspx");
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
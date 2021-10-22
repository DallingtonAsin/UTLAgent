using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTLAgent.TransApi;

namespace UTLAgent.Pages
{
    public partial class agents: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UTLUsername"] == null && Session["UTLUserPassword"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                GetListOfAgents();
            }
            MultiViewAgents.ActiveViewIndex = 0;
            GetListOfAgents();

        }


        public void GetListOfAgents()
        {
           
            DataTable dt = null;
            try{
                Api api = new Api();
                dt = api.GetRegisteredAgents();

                AgentsGridView.DataSource = dt;
                AgentsGridView.DataBind();
                AgentsGridView.UseAccessibleHeader = true;
                AgentsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                
             

            }catch(Exception ex)
            {

                Console.WriteLine("Exception" + ex.ToString() + " has occurred ");
            }

        }



    }
}
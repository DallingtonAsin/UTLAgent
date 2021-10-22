using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using UTLAgent.TransApi;

namespace UTLAgent.Pages
{
    public partial class agentsWithLowFloat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorTxt.Text = "";
            if (Session["UTLUsername"] == null && Session["UTLUserPassword"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            MultiViewAgentsWithLowFloat.ActiveViewIndex = 0;
            AgentsRunningOutOfFloat();
            //if (!IsPostBack)
            //{

            //}
            if (!Page.IsPostBack)
            {


            }
        }

        protected double GetMinimumAgentCredit()
        {
            string credit = "10000"; // ConfigurationManager.AppSettings["MinimumAgentCredit"];
            return Convert.ToDouble(credit);
        }


        public void AgentsRunningOutOfFloat()
        {

            DataTable dt = null;
            try
            {

                Api api = new Api();
                string accountNo = "";
                dt = api.GetAgentsWithRunningOutFloat(accountNo, GetMinimumAgentCredit());
                PopulateGridView(dt);
               
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception" + ex.ToString() + " has occurred ");
            }

        }


        protected void PopulateGridView(DataTable datatable)
        {
            if (datatable.Rows.Count > 0)
            {
                AgentsRunningOutofFloatGridView.DataSource = datatable;
                AgentsRunningOutofFloatGridView.DataBind();
                AgentsRunningOutofFloatGridView.UseAccessibleHeader = true;
                AgentsRunningOutofFloatGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                ClearErrorMessage();
            }
            else
            {
                InfoTxt.Text = "Currently, there are no agents running out of float";
            }
        }

        protected void GetAgentswithSetMin_Click(object sender, EventArgs e)
        {
            Api api = new Api();
            string accountNo = "";
            DataTable dt;

            try
            {
                if (!string.IsNullOrEmpty(AccountNo.Text) && string.IsNullOrEmpty(minimumCredit.Text))
                {
                    ClearErrorMessage();
                    accountNo = AccountNo.Text.Trim().ToString();
                    dt = api.GetAgentsWithRunningOutFloat(accountNo, -1);
                    if (dt.Rows.Count > 0)
                    {
                        
                        PopulateGridView(dt);
                    }

                }
                else if (string.IsNullOrEmpty(AccountNo.Text) && !string.IsNullOrEmpty(minimumCredit.Text))
                {
                    
                    double MinCredit = Convert.ToDouble(minimumCredit.Text.Trim().ToString());
                    dt = api.GetAgentsWithRunningOutFloat(accountNo, MinCredit);
                    PopulateGridView(dt);

                }
                else if (!string.IsNullOrEmpty(AccountNo.Text) && !string.IsNullOrEmpty(minimumCredit.Text))
                {
                    
                    accountNo = AccountNo.Text.Trim().ToString();
                    double MinCredit = Convert.ToDouble(minimumCredit.Text.Trim().ToString());
                    dt = api.GetAgentsWithRunningOutFloat(accountNo, MinCredit);
                    PopulateGridView(dt);
                }
                else
                {
                  
                    string error = "Enter either account no or minimum credit to generate report";
                    ShowErrorMessage(error);
                    dt = api.GetAgentsWithRunningOutFloat(accountNo, GetMinimumAgentCredit());
                    PopulateGridView(dt);

                }
            }catch(Exception ex)
            {
                ShowErrorMessage(ex.ToString());
            }
        }


        protected void ShowErrorMessage(string message)
        {
            ErrorTxt.Text = message;
        }


        protected void ClearErrorMessage()
        {
            ErrorTxt.Text = "";
        }












    }
}
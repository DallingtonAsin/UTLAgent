using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTLAgent.Queues;
using UTLAgent.TransApi;

namespace UTLAgent.Pages
{
    public partial class credit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UTLUsername"] == null && Session["UTLUserPassword"] == null)
            {
                Page.Response.Redirect("Default.aspx", true);
                Context.ApplicationInstance.CompleteRequest();
            }
            MultiView.ActiveViewIndex = 0;
            if (!IsPostBack)
            {
                // do nothing
            }
           
           

        }



        protected void creditmoneyBtn_Click(object sender, EventArgs e)
        {

            CreditQueue queue = null;
            Api api = null;
            string creditedBy = "Admin";
            try
            {
                api = new Api();
                if (!string.IsNullOrEmpty(requestIdTxt.Text))
                {
                    if (!string.IsNullOrEmpty(AccountNoTxt.Text))
                    {
                        if (!string.IsNullOrEmpty(AmtTxt.Text))
                        {
                            string requestID = requestIdTxt.Text.Trim().ToString();
                            string account_no = AccountNoTxt.Text.Trim().ToString();
                            double money = Convert.ToDouble(AmtTxt.Text.Trim().ToString());
                            object[] validRes = api.isCreditRequestValid(requestID, account_no, money);

                            bool isReqValid = Convert.ToBoolean(validRes[0]);
                            if (isReqValid == true)
                            {

                               
                                string username = Session["UTLUsername"].ToString();
                                object[] obj = api.GetUserDetails(username);
                                
                                if (!string.IsNullOrEmpty(username))
                                {
                                     creditedBy = obj[1].ToString() + " " + obj[2].ToString();
                                }
                                else
                                {
                                    creditedBy = "Admin";
                                }
                                
                               

                                object[] paras = { requestID, account_no, money, creditedBy };
                                queue = new CreditQueue();
                                queue.Enqueue(paras);
                                requestIdTxt.Text = "";
                                AccountNoTxt.Text = "";
                                AmtTxt.Text = "";
                                failureTxt.Text = "";
                            }
                            else
                            {
                                string msgErr = validRes[1].ToString();
                                failureTxt.Text = msgErr;
                            }
                        }
                        else
                        {
                            failureTxt.Text = "Please enter amount of money to be credited";
                        }
                    }
                    else
                    {
                        failureTxt.Text = "Please enter agent account number to credit an agent";
                    }
                }
                else
                {
                    failureTxt.Text = "Please enter reference ID of the request";
                }

            }
            catch (Exception ex)
            {
                failureTxt.Text = ex.ToString();
            }



        }


    }
}
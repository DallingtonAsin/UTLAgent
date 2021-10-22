using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTLAgent.TransApi;
using UTLAgent.Queues;

namespace UTLAgent.Pages
{
    public partial class pendingCreditRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UTLUsername"] == null && Session["UTLUserPassword"] == null)
            {
                Page.Response.Redirect("Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            if (!Page.IsPostBack)
            {
                //do nothing

            }

            LoadPendingCreditRequests();
            failureTxt.Text = "";

        }

       
        protected void LoadPendingCreditRequests()
        {
            DataTable dt = null;
            try
            {
                Api api = new Api();
                dt = api.GetPendingCreditRequests();
                if (dt.Rows.Count > 0)
                {
                    PendingRequestsGridView.DataSource = dt;
                    PendingRequestsGridView.DataBind();
                    PendingRequestsGridView.UseAccessibleHeader = true;
                    PendingRequestsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        protected void CreditBtn_Click(object sender, EventArgs e)
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

        protected void PendingRequestsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = PendingRequestsGridView.SelectedRow;
            requestIdTxt.Text = row.Cells[1].Text;
            AccountNoTxt.Text = row.Cells[2].Text;
            AmtTxt.Text = row.Cells[3].Text;

        }

       
    }
}
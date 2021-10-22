using UTLAgent.TransApi;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTLAgent.Pages
{
    public partial class register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            MultiView.ActiveViewIndex = 0;

            if (Session["UTLUsername"] == null && Session["UTLUserPassword"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {

               
            }

           
        }


        protected void RegisterCustomer()
        {
    
            Api api = new Api();
            double balance;
            string first_name, last_name, tel_no;
            
            try
            {


                if (!string.IsNullOrEmpty(FirstNameTxt.Text)){
                    if (!string.IsNullOrEmpty(LastNameTxt.Text)){
                        if (!string.IsNullOrEmpty(TelNoTxt.Text)){

                            if (!string.IsNullOrEmpty(BalanceTxt.Text))
                            {
                                 balance = Convert.ToDouble(BalanceTxt.Text.Trim().ToString());
                            }
                            else
                            {
                                 balance = 0;
                            }
                             first_name = FirstNameTxt.Text.ToString();
                             last_name = LastNameTxt.Text.ToString();
                             tel_no = TelNoTxt.Text.ToString();

                                
                                object[] res = api.RegisterAgent(first_name, last_name, tel_no, balance);
                               bool isRegistrationSuccessful = Convert.ToBoolean(res[0]);
                            if (isRegistrationSuccessful == true)
                            {
                                FirstNameTxt.Text = "";
                                LastNameTxt.Text = "";
                                TelNoTxt.Text = "";
                                failureTxt.Text = "";
                                messageTxt.Text = res[1].ToString();

                            }
                            else
                            {
                                failureTxt.Text = res[1].ToString(); 

                            }
                            



                        }
                        else
                        {
                            failureTxt.Text = "Please enter telephone number";
                        }
                    }
                    else
                    {
                        failureTxt.Text = "Please enter last name";
                    }
                }
                else
                {
                    failureTxt.Text = "Please enter first name";
                }



             }
            catch(Exception ex)
            {
                failureTxt.Text = ex.ToString();

            }
            


        }

        protected void RegisterAgentBtn_Click(object sender, EventArgs e)
        {
            RegisterCustomer();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTLAgent.TransApi;

namespace UTLAgent.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void authenticateUser()
        {
            if (!string.IsNullOrEmpty(UsernameTxt.Text))
            {
                if (!string.IsNullOrEmpty(PasswordTxt.Text))
                {

                    try
                    {
                        String username = UsernameTxt.Text.Trim().ToString();
                        String password = PasswordTxt.Text.Trim().ToString();
                        Api api = new Api();
                        object[] response = api.AuthenticateUser(username, password);
                        bool hasValidCredentials = Convert.ToBoolean(response[0]);
                        bool isUserAccountActive = Convert.ToBoolean(response[1]);

                        if (hasValidCredentials == true && isUserAccountActive == true)
                        {
                            //string error = "User Credentials validated successfully";
                            //ShowErrorMessage(error);
                            Session["UTLUsername"] = username;
                            Session["UTLUserPassword"] = password;

                            Response.Redirect("home.aspx");

                        }
                        else if (hasValidCredentials == true && isUserAccountActive == false)
                        {
                            string error = "Your account is inactive, contact your Admin";
                            ShowErrorMessage(error);

                        }
                        else
                        {
                            string error = "Invalid login credentials, please try again!";
                            ShowErrorMessage(error);

                        }
                    }catch(Exception ex)
                    {
                        ShowErrorMessage(ex.ToString());
                    }

                }
                else
                {
                    string error = "Please enter your password";
                    ShowErrorMessage(error);

                }
            }
            else
            {
                string error = "Please enter your username or email";
                ShowErrorMessage(error);

            }

        }

            protected void LoginBtn_Clicked(object sender, EventArgs e)
            {
                  authenticateUser();

            }


          protected void ShowErrorMessage(string message)
        {
            ErrorTxt.Style.Add("class", "login-error");
            ErrorTxt.Text = message;
        }



    }
}
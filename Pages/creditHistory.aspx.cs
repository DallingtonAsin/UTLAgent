using UTLAgent.TransApi;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace UTLAgent.Pages
{
    public partial class creditHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UTLUsername"] == null && Session["UTLUserPassword"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            ApprovedRequestsMultiView.ActiveViewIndex = 0;
            
            if (!IsPostBack)
            {
           
;
            }

            LoadApprovedCreditRequests();
        }

        protected void LoadApprovedCreditRequests()
        {
            DataTable dt = null;
            try
            {
                Api api = new Api();
                dt = api.GetApprovedCreditRequests();
                if (dt.Rows.Count > 0)
                {
                    ApprovedRequestsGridView.DataSource = dt;
                    ApprovedRequestsGridView.DataBind();
                    ApprovedRequestsGridView.UseAccessibleHeader = true;
                    ApprovedRequestsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

      
    }
}
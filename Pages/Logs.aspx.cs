using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTLAgent.TransApi;


namespace UTLAgent.Pages
{
    public partial class transactionalLogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             MultiViewLogs.ActiveViewIndex = 0;
      

            if (!IsPostBack)
            {
                LoadLogs("success_logs");
            }


        }

        public void LoadLogs(string log_type)
        {
            DataTable dt = null;
            try
            {
                Api api = new Api();
                dt = api.ListofLogs(log_type);
                if (dt.Rows.Count > 0)
                {
                    LogsGridView.DataSource = dt;
                    LogsGridView.DataBind();
                    LogsGridView.UseAccessibleHeader = true;
                    LogsGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                    MsgFailureTxt.Text = "";
                    MsgSuccessTxt.Text = "";
                    MsgWarningTxt.Text = "";
                }
                else
                {
                    MsgWarningTxt.Text = "No logs found";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected void ViewCustomLogs_Click(object sender, EventArgs e)
        {
            string log_type = LogType.SelectedItem.Value.Trim();
            if (log_type.Equals("error"))
            {
                LoadLogs("error_logs");
            }else if (log_type.Equals("success"))
            {
                LoadLogs("success_logs");

            }
            else if (log_type.Equals("request"))
            {
                LoadLogs("request_logs");
            }
        }
    }
}
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Admin_ReportMasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_ID"] == null || Session["Login_ID"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
    }
    protected void lnk_btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
}

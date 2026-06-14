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
using System.Net.Mail;
using System.Net.NetworkInformation;
public partial class Admin_Registration : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ad = new SqlDataAdapter();
    SqlDataReader dr;
    string userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            DateTime regDate = DateTime.Now;
            string regDate1 = Convert.ToString(DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year);           
            txtdate.Text = regDate1.ToString();
            //if (Session["Login_ID"].ToString() == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}  
            AutoLoadData();
        }
    }
    void AutoLoadData()
    {
        ddlorganization_serving.Items.Clear();
        ddl_zone.Items.Clear();
        ddl_zone1.Items.Clear();
        ddl_zone2.Items.Clear();
        ddlarea_of_work.Items.Clear();
        ddlplace_of_work.Items.Clear();
        ddlvarsh_attended.Items.Clear();
        ddlspecialization.Items.Clear();
        ddlspecialization4.Items.Clear();
        ddloccupation.Items.Clear();
        ddlassign_work.Items.Clear();
        ddlrssdesignation.Items.Clear();
        ddl_organization1.Items.Clear();
        ddl_occasion.Items.Clear();
        ddl_sanghsiksha.Items.Clear();
         ddl_rsslevel.Items.Clear();
        ddlorganization_serving.Items.Add("--Select Organization--");       
        ddlarea_of_work.Items.Add("--Select Work Area--");
        ddlplace_of_work.Items.Add("--Select Work Place--");
        ddlvarsh_attended.Items.Add("--Select Varsh--");
        ddlspecialization.Items.Add("--Select Specialization--");
        ddlspecialization4.Items.Add("--Select Specialization--");
        ddloccupation.Items.Add("--Select Occupation--");
        ddlassign_work.Items.Add("--Select Assign Work--");
        ddlrssdesignation.Items.Add("-Select Designation-");
        ddl_organization1.Items.Add("--Select Organization--");
        ddl_occasion.Items.Add("--Select Occasion--");
        ddl_sanghsiksha.Items.Add("--Select Sangh Siksha--");
        ddl_rsslevel.Items.Add("--Select Level--");
        con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
        con.Open();
        cmd.CommandText = "Select Distinct SanghShiksha_Name from SanghShikshaMaster Order By SanghShiksha_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddl_sanghsiksha.Items.Add(dr[0].ToString());           
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Level_Name from RSSLevelMaster Order By Level_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddl_rsslevel.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Designation_Name from RSSDesignationMaster Order By Designation_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlrssdesignation.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Occasion_Name from OccasionMaster Order By Occasion_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddl_occasion.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct WorkArea_Name from WorkAreaMaster Order By WorkArea_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlarea_of_work.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct District from DistrictMaster Order By District";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {            
            ddlplace_of_work.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Varsh_Name, Sr_No from VarshMaster Order By Sr_No";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlvarsh_attended.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Specialization_Name from SpecializationMaster Order By Specialization_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlspecialization.Items.Add(dr[0].ToString());
            ddlspecialization4.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Organization_Name from OrganizationMaster Order By Organization_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlorganization_serving.Items.Add(dr[0].ToString());
            ddl_organization1.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct Occupation_Name from OccupationMaster Order By Occupation_Name";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddloccupation.Items.Add(dr[0].ToString());
        }
        dr.Close();
        cmd.CommandText = "Select Distinct WorkAssign from WorkAssignMaster Order By WorkAssign";
        cmd.Connection = con;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ddlassign_work.Items.Add(dr[0].ToString());
        }
        dr.Close();
        con.Close(); 
    }
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_state.Items.Clear();
        ddl_state.Items.Add("-Select State-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Distinct State_Name from StateMaster Where Country=@country Order By State_Name";
            cmd.Parameters.AddWithValue("@country", ddl_country.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_state.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_district.Items.Clear();
        ddl_district.Items.Add("-Select District-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct District from DistrictMaster Where Country='India' AND State_Name=@stateName Order By District";
            cmd.Parameters.AddWithValue("@stateName", ddl_state.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_district.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_city.Items.Clear();
        ddl_city.Items.Add("-Select Vidhansabha-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Vidhansabha from CityMaster Where Country='India' AND State_Name=@stateName AND District=@district Order By Vidhansabha";
            cmd.Parameters.AddWithValue("@stateName", ddl_state.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_city.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_country1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_state1.Items.Clear();
        ddl_state1.Items.Add("-Select State-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Distinct State_Name from StateMaster Where Country=@country1 Order By State_Name";
            cmd.Parameters.AddWithValue("@country1", ddl_country1.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_state1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_state1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_district1.Items.Clear();
        ddl_district1.Items.Add("-Select District-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct District from DistrictMaster Where Country='India' AND State_Name=@stateName1 Order By District";
            cmd.Parameters.AddWithValue("@stateName1", ddl_state1.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_district1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_district1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_city1.Items.Clear();
        ddl_city1.Items.Add("-Select Vidhansabha-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Vidhansabha from CityMaster Where Country='India' AND State_Name=@stateName1 AND District=@district1 Order By Vidhansabha";
            cmd.Parameters.AddWithValue("@stateName1", ddl_state1.Text);
            cmd.Parameters.AddWithValue("@district1", ddl_district1.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_city1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_country2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_state2.Items.Clear();
        ddl_state2.Items.Add("-Select State-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Distinct State_Name from StateMaster Where Country=@country2 Order By State_Name";
            cmd.Parameters.AddWithValue("@country2", ddl_country2.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_state2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_state2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_district2.Items.Clear();
        ddl_district2.Items.Add("-Select District-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct District from DistrictMaster Where Country='India' AND State_Name=@stateName2 Order By District";
            cmd.Parameters.AddWithValue("@stateName2", ddl_state2.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_district2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_district2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_city2.Items.Clear();
        ddl_city2.Items.Add("-Select Vidhansabha-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Vidhansabha from CityMaster Where Country='India' AND State_Name=@stateName2 AND District=@district2 Order By Vidhansabha";
            cmd.Parameters.AddWithValue("@stateName2", ddl_state2.Text);
            cmd.Parameters.AddWithValue("@district2", ddl_district2.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_city2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_city_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_zone.Items.Clear();
        ddl_zone.Items.Add("-Select Village-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Village from VillageMaster Where Country='India' AND State_Name=@stateName AND District=@district AND Vidhansabha=@city Order By Village";
            cmd.Parameters.AddWithValue("@stateName", ddl_state.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.Text);
            cmd.Parameters.AddWithValue("@city", ddl_city.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_zone.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_city1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_zone1.Items.Clear();
        ddl_zone1.Items.Add("-Select Village-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Village from VillageMaster Where Country='India' AND State_Name=@stateName1 AND District=@district1 AND Vidhansabha=@city1 Order By Village";
            cmd.Parameters.AddWithValue("@stateName1", ddl_state1.Text);
            cmd.Parameters.AddWithValue("@district1", ddl_district1.Text);
            cmd.Parameters.AddWithValue("@city1", ddl_city1.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_zone1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddl_city2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_zone2.Items.Clear();
        ddl_zone2.Items.Add("-Select Village-");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Village from VillageMaster Where Country='India' AND State_Name=@stateName2 AND District=@district2 AND Vidhansabha=@city2 Order By Village";
            cmd.Parameters.AddWithValue("@stateName2", ddl_state2.Text);
            cmd.Parameters.AddWithValue("@district2", ddl_district2.Text);
            cmd.Parameters.AddWithValue("@city2", ddl_city2.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddl_zone2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddlspecialization_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlspecialization1.Items.Clear();
        ddlspecialization1.Items.Add("--Select Sub Specl--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Sub_Specialization from SubSpeclMaster Where Specialization_Name=@specName Order By Sub_Specialization";
            cmd.Parameters.AddWithValue("@specName", ddlspecialization.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlspecialization1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddlspecialization1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlspelization2.Items.Clear();
        ddlspelization2.Items.Add("--Select Sub-Sub Specl--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Sub_Sub_Specialization from Sub_SubSpeclMaster Where Specialization_Name=@specName AND Sub_Specialization=@subSpecName Order By Sub_Sub_Specialization";
            cmd.Parameters.AddWithValue("@specName", ddlspecialization.Text);
            cmd.Parameters.AddWithValue("@subSpecName", ddlspecialization1.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlspelization2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddlspecialization4_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlspecialization5.Items.Clear();
        ddlspecialization5.Items.Add("--Select Sub Specl--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Sub_Specialization from SubSpeclMaster Where Specialization_Name=@specName4 Order By Sub_Specialization";
            cmd.Parameters.AddWithValue("@specName4", ddlspecialization4.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlspecialization5.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void ddlspecialization5_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlspecialization6.Items.Clear();
        ddlspecialization6.Items.Add("--Select Sub-Sub Specl--");
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Sub_Sub_Specialization from Sub_SubSpeclMaster Where Specialization_Name=@specName4 AND Sub_Specialization=@subSpecName5 Order By Sub_Sub_Specialization";
            cmd.Parameters.AddWithValue("@specName4", ddlspecialization4.Text);
            cmd.Parameters.AddWithValue("@subSpecName5", ddlspecialization5.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ddlspecialization6.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void btnfileupload_Click(object sender, EventArgs e)
    {       
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please select Reg ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }       
        string pat = "";
        string ext = "";
        string strFileNameWithPath = "";
        string strFileName = "";
        strFileNameWithPath = fileImage.PostedFile.FileName;
        strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
        ext = System.IO.Path.GetExtension(strFileNameWithPath);
        if (fileImage.HasFile)
        {
            System.IO.Stream fs = fileImage.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytesPhoto = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytesPhoto, 0, bytesPhoto.Length);
            Image3.ImageUrl = "data:image/png;base64," + base64String;
            Image3.Visible = true;
            try
            {
                string safeId = System.Text.RegularExpressions.Regex.Replace(txtreg_id.Text, @"[^a-zA-Z0-9_\-]", "");
                string safeExt = System.IO.Path.GetExtension(fileImage.FileName).ToLower();
                string[] allowedExts = { ".jpg", ".jpeg", ".png", ".gif" };
                if (!Array.Exists(allowedExts, e => e == safeExt))
                {
                    string jvErr = "<script>alert('Invalid file type. Only jpg, jpeg, png, gif are allowed.');</script>";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertExt", jvErr, false);
                }
                else
                {
                    fileImage.SaveAs(Server.MapPath("~/Img_Member/" + safeId + safeExt));
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void btnmemoupload_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please select Reg ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }
        string pat = "";
        string ext = "";
        string strFileNameWithPath = "";
        string strFileName = "";
        strFileNameWithPath = FileUpload1.PostedFile.FileName;
        strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
        ext = System.IO.Path.GetExtension(strFileNameWithPath);
        if (FileUpload1.HasFile)
        {
            System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytesPhoto = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytesPhoto, 0, bytesPhoto.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;
            Image1.Visible = true;
            try
            {
                pat = (txtreg_id.Text);
                FileUpload1.SaveAs(Server.MapPath("~/Memo_Photo/" + pat + ext));
            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Add(ddlorganization_serving.SelectedItem.ToString());
        ListBox10.Items.Add(ddlrssdesignation.SelectedItem.ToString());
        ListBox2.Items.Add(txtorg_date_from.Text);
        ListBox3.Items.Add(txtorg_date_to.Text);
        ListBox4.Items.Add(ddlarea_of_work.SelectedItem.ToString());
        ListBox5.Items.Add(ddlplace_of_work.SelectedItem.ToString());
        ListBox6.Items.Add(txtachievement_work.Text);
        ListBox7.Items.Add(txtadditional_remarks.Text);
        ListBox8.Items.Add(ddlvarsh_attended.SelectedItem.ToString());
        ListBox9.Items.Add(txtadditional_details.Text);
    }
    protected void btnbtnreset_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        ListBox2.Items.Clear();
        ListBox3.Items.Clear();
        ListBox4.Items.Clear();
        ListBox5.Items.Clear();
        ListBox6.Items.Clear();
        ListBox7.Items.Clear();
        ListBox8.Items.Clear();
        ListBox9.Items.Clear();
        ListBox10.Items.Clear();
    }
    protected void btnadd_p_Click(object sender, EventArgs e)
    {
        lb_p_org.Items.Add(ddl_organization1.SelectedItem.ToString());
        lb_p_membername.Items.Add(txtname_familymember.Text);
        lb_p_memberid.Items.Add(txtmember_rss.Text);      
    }
    protected void btnreset_p_Click(object sender, EventArgs e)
    {
        lb_p_org.Items.Clear();
        lb_p_membername.Items.Clear();
        lb_p_memberid.Items.Clear();      
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {       
        if (txtdate.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Date');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtdate.Focus();
            return;

        }
        if (txtage.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter Age');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtage.Focus();
            return;

        }
        if (ddlsex.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select Sex');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddlsex.Focus();
            return;
        }
        if (ddl_country.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select Country');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_country.Focus();
            return;
        }
        if (ddl_state.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select State');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_state.Focus();
            return;
        }
        if (ddl_district.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select District');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_district.Focus();
            return;
        }
        if (ddl_city.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select Vidhansabha');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_city.Focus();
            return;
        }
        if (ddl_zone.Text.Trim() == "")
        {
            string jv = "<script>alert('Please Select Zone');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_zone.Focus();
            return;
        }
        if (ddl_country.Text.Trim() == "-Select Country-")
        {
            string jv = "<script>alert('Please Select Country');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_country.Focus();
            return;
        }
        if (ddl_state.Text.Trim() == "-Select State-")
        {
            string jv = "<script>alert('Please Select State');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_state.Focus();
            return;
        }
        if (ddl_district.Text.Trim() == "-Select District-")
        {
            string jv = "<script>alert('Please Select District');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_district.Focus();
            return;
        }
        if (ddl_city.Text.Trim() == "-Select Vidhansabha-")
        {
            string jv = "<script>alert('Please Select Vidhansabha');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_city.Focus();
            return;
        }
        if (ddl_zone.Text.Trim() == "-Select Village-")
        {
            string jv = "<script>alert('Please Select Zone');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            ddl_zone.Focus();
            return;
        }
        string st_code = "";
        string vdh_code = "";
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.CommandText = "Select Distinct State_Code from StateMaster Where Country='India' AND State_Name=@stateName Order By State_Code";
            cmd.Parameters.AddWithValue("@stateName", ddl_state.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                st_code = dr[0].ToString();
            }
            dr.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = "Select Distinct Vidhansabha_Code from CityMaster Where Country='India' AND State_Name=@stateName AND District=@district AND Vidhansabha=@city Order By Vidhansabha_Code";
            cmd.Parameters.AddWithValue("@stateName", ddl_state.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.Text);
            cmd.Parameters.AddWithValue("@city", ddl_city.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                vdh_code = dr[0].ToString();
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
        DateTime RegDate = DateTime.Now;
        SqlTransaction transaction = null;
        int Increment;      
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();         
            SqlCommand cmd = new SqlCommand("GET_Upliner_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;            
            {                
                cmd.Parameters.Add(new SqlParameter("@ID", System.Data.SqlDbType.Int)).Direction = ParameterDirection.Output;
            }
            con.Open();
            transaction = con.BeginTransaction("BIT_SKNRSS");
            cmd.Connection = con;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            Increment =Convert.ToInt32(cmd.Parameters["@ID"].Value);
            int icr;
                string RecNo = "";               
                icr = Increment + 1;             
                if (Increment < 9)
                {
                    //RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "000000" + icr;
                    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "000000" + icr;
                }
                else if (Increment < 99)
                {
                    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "00000" + icr;
                }
                else if (Increment < 999)
                {
                    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "0000" + icr;
                }
                else if (Increment < 9999)
                {
                    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "000" + icr;
                }
                else if (Increment < 99999)
                {
                    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "00" + icr;
                }
                else if (Increment < 99999)
                {
                    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + "0" + icr;
                }
                else if (Increment < 99999)
                {
                    RecNo = "RSS/" + st_code + "/" + vdh_code + "/" + icr;
                }
                txtreg_id.Text = RecNo;
                if (txtreg_id.Text.Trim() == "")
                {
                    string jv = "<script>alert('Please enter User ID');</script>";
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
                    txtreg_id.Focus();
                    return;
                }
                if (txtmember_rss.Text.Trim() == "")
                {
                    txtmember_rss.Text = txtreg_id.Text;
                }            
            int i = 0;
            int j = 0;
            int isrno = 1;
            i = ListBox1.Items.Count;
            // Build shared parameters for both INSERT paths
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@regId", txtreg_id.Text);
            cmd.Parameters.AddWithValue("@regDate", RegDate);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@nickName", txtnickname.Text);
            cmd.Parameters.AddWithValue("@sex", ddlsex.Text);
            cmd.Parameters.AddWithValue("@dob", txtdob.Text);
            cmd.Parameters.AddWithValue("@age", txtage.Text);
            cmd.Parameters.AddWithValue("@nationality", ddlnationality.Text);
            cmd.Parameters.AddWithValue("@marriageDate", txtmarriage_date.Text);
            cmd.Parameters.AddWithValue("@occasion", ddl_occasion.Text);
            cmd.Parameters.AddWithValue("@familyMember", txtfamily_member.Text);
            cmd.Parameters.AddWithValue("@memberRss", txtmember_rss.Text);
            cmd.Parameters.AddWithValue("@permanentAddr", txtpermanent_addr.Text);
            cmd.Parameters.AddWithValue("@country", ddl_country.Text);
            cmd.Parameters.AddWithValue("@state", ddl_state.Text);
            cmd.Parameters.AddWithValue("@district", ddl_district.Text);
            cmd.Parameters.AddWithValue("@city", ddl_city.Text);
            cmd.Parameters.AddWithValue("@zone", ddl_zone.Text);
            cmd.Parameters.AddWithValue("@currAddr", txtcurr_addr.Text);
            cmd.Parameters.AddWithValue("@country1", ddl_country1.Text);
            cmd.Parameters.AddWithValue("@state1", ddl_state1.Text);
            cmd.Parameters.AddWithValue("@district1", ddl_district1.Text);
            cmd.Parameters.AddWithValue("@city1", ddl_city1.Text);
            cmd.Parameters.AddWithValue("@zone1", ddl_zone1.Text);
            cmd.Parameters.AddWithValue("@officeAddr", txtoffice_addr.Text);
            cmd.Parameters.AddWithValue("@country2", ddl_country2.Text);
            cmd.Parameters.AddWithValue("@state2", ddl_state2.Text);
            cmd.Parameters.AddWithValue("@district2", ddl_district2.Text);
            cmd.Parameters.AddWithValue("@city2", ddl_city2.Text);
            cmd.Parameters.AddWithValue("@zone2", ddl_zone2.Text);
            cmd.Parameters.AddWithValue("@emailId1", txtemail_id1.Text);
            cmd.Parameters.AddWithValue("@emailId2", txtemail_id2.Text);
            cmd.Parameters.AddWithValue("@contactNo1", txtcontact_no1.Text);
            cmd.Parameters.AddWithValue("@contactNo2", txtcontact_no2.Text);
            cmd.Parameters.AddWithValue("@contactNo3", txtcontact_no3.Text);
            cmd.Parameters.AddWithValue("@contactNo4", txtcontact_no4.Text);
            cmd.Parameters.AddWithValue("@qualification", ddl_qualification.Text);
            cmd.Parameters.AddWithValue("@qSpec", ddlspecialization.Text);
            cmd.Parameters.AddWithValue("@qSpec1", ddlspecialization1.Text);
            cmd.Parameters.AddWithValue("@qSpec2", ddlspelization2.Text);
            cmd.Parameters.AddWithValue("@course1", txtcourse1.Text);
            cmd.Parameters.AddWithValue("@occupation", ddloccupation.Text);
            cmd.Parameters.AddWithValue("@eSpec", ddlspecialization4.Text);
            cmd.Parameters.AddWithValue("@eSpec1", ddlspecialization5.Text);
            cmd.Parameters.AddWithValue("@eSpec2", ddlspecialization6.Text);
            cmd.Parameters.AddWithValue("@org1", txtorg1.Text);
            cmd.Parameters.AddWithValue("@org1From", txtorg1_fromdate.Text);
            cmd.Parameters.AddWithValue("@org1To", txtorg1_todate.Text);
            cmd.Parameters.AddWithValue("@org1Ach", txtorg1_achievement.Text);
            cmd.Parameters.AddWithValue("@org1Rem", txtorg1_remark.Text);
            cmd.Parameters.AddWithValue("@org2", txtorg2.Text);
            cmd.Parameters.AddWithValue("@org2From", txtorg2_fromdate.Text);
            cmd.Parameters.AddWithValue("@org2To", txtorg2_todate.Text);
            cmd.Parameters.AddWithValue("@org2Ach", txtorg2_achievement.Text);
            cmd.Parameters.AddWithValue("@org2Rem", txtorg2_remark.Text);
            cmd.Parameters.AddWithValue("@org3", txtorg3.Text);
            cmd.Parameters.AddWithValue("@org3From", txtorg3_fromdate.Text);
            cmd.Parameters.AddWithValue("@org3To", txtorg3_todate.Text);
            cmd.Parameters.AddWithValue("@org3Ach", txtorg3_achievement.Text);
            cmd.Parameters.AddWithValue("@org3Rem", txtorg3_remark.Text);
            cmd.Parameters.AddWithValue("@org4", txtorg4.Text);
            cmd.Parameters.AddWithValue("@org4From", txtorg4_fromdate.Text);
            cmd.Parameters.AddWithValue("@org4To", txtorg4_todate.Text);
            cmd.Parameters.AddWithValue("@org4Ach", txtorg4_achievement.Text);
            cmd.Parameters.AddWithValue("@org4Rem", txtorg4_remark.Text);
            cmd.Parameters.AddWithValue("@hobbies1", txthobbies1.Text);
            cmd.Parameters.AddWithValue("@extra1", txtextra_act1.Text);
            cmd.Parameters.AddWithValue("@hobbies2", txthobbies2.Text);
            cmd.Parameters.AddWithValue("@extra2", txtextra_act2.Text);
            cmd.Parameters.AddWithValue("@hobbies3", txthobbies3.Text);
            cmd.Parameters.AddWithValue("@extra3", txtextra_act3.Text);
            cmd.Parameters.AddWithValue("@hobbies4", txthobbies4.Text);
            cmd.Parameters.AddWithValue("@extra4", txtextra_act4.Text);
            cmd.Parameters.AddWithValue("@hobbies5", txthobbies5.Text);
            cmd.Parameters.AddWithValue("@extra5", txtextra_act5.Text);
            cmd.Parameters.AddWithValue("@achievements", txtachievements.Text);
            cmd.Parameters.AddWithValue("@behavior", txtbehavior_analysis.Text);
            cmd.Parameters.AddWithValue("@futureAmbition", txtfuture_ambition.Text);
            cmd.Parameters.AddWithValue("@meetingReason", txtmeeting_reason.Text);
            cmd.Parameters.AddWithValue("@meetingPlace", txtmeeting_place.Text);
            cmd.Parameters.AddWithValue("@meetingDate", txtmeeting_date.Text);
            cmd.Parameters.AddWithValue("@assignWork", ddlassign_work.Text);
            cmd.Parameters.AddWithValue("@purpose", txtany_purpose.Text);
            cmd.Parameters.AddWithValue("@memo", txtmemo.Text);

            if (j == i)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into RSS_Registration(Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Memo_Discription) values(@regId, @regDate, @name, @nickName, @sex, @dob, @age, @nationality, @marriageDate, @occasion, @familyMember, @memberRss, @permanentAddr, @country, @state, @district, @city, @zone, @currAddr, @country1, @state1, @district1, @city1, @zone1, @officeAddr, @country2, @state2, @district2, @city2, @zone2, @emailId1, @emailId2, @contactNo1, @contactNo2, @contactNo3, @contactNo4, @qualification, @qSpec, @qSpec1, @qSpec2, @course1, @occupation, @eSpec, @eSpec1, @eSpec2, '1', @org1, @org1From, @org1To, @org1Ach, @org1Rem, '2', @org2, @org2From, @org2To, @org2Ach, @org2Rem, '3', @org3, @org3From, @org3To, @org3Ach, @org3Rem, '4', @org4, @org4From, @org4To, @org4Ach, @org4Rem, '1', @hobbies1, @extra1, '2', @hobbies2, @extra2, '3', @hobbies3, @extra3, '4', @hobbies4, @extra4, '5', @hobbies5, @extra5, @achievements, @behavior, @futureAmbition, @meetingReason, @meetingPlace, @meetingDate, @assignWork, @purpose, '1', @memo)";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            while (j < i)
            {
                cmd.CommandType = CommandType.Text;
                // Remove loop-specific params before re-adding them
                if (cmd.Parameters.Contains("@isrno")) cmd.Parameters.RemoveAt("@isrno");
                if (cmd.Parameters.Contains("@lb1")) cmd.Parameters.RemoveAt("@lb1");
                if (cmd.Parameters.Contains("@lb10")) cmd.Parameters.RemoveAt("@lb10");
                if (cmd.Parameters.Contains("@lb2")) cmd.Parameters.RemoveAt("@lb2");
                if (cmd.Parameters.Contains("@lb3")) cmd.Parameters.RemoveAt("@lb3");
                if (cmd.Parameters.Contains("@lb4")) cmd.Parameters.RemoveAt("@lb4");
                if (cmd.Parameters.Contains("@lb5")) cmd.Parameters.RemoveAt("@lb5");
                if (cmd.Parameters.Contains("@lb6")) cmd.Parameters.RemoveAt("@lb6");
                if (cmd.Parameters.Contains("@lb7")) cmd.Parameters.RemoveAt("@lb7");
                if (cmd.Parameters.Contains("@lb8")) cmd.Parameters.RemoveAt("@lb8");
                if (cmd.Parameters.Contains("@lb9")) cmd.Parameters.RemoveAt("@lb9");
                cmd.Parameters.AddWithValue("@isrno", isrno);
                cmd.Parameters.AddWithValue("@lb1", ListBox1.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb10", ListBox10.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb2", ListBox2.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb3", ListBox3.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb4", ListBox4.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb5", ListBox5.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb6", ListBox6.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb7", ListBox7.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb8", ListBox8.Items[j].ToString());
                cmd.Parameters.AddWithValue("@lb9", ListBox9.Items[j].ToString());
                cmd.CommandText = "Insert into RSS_Registration(Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription) values(@regId, @regDate, @name, @nickName, @sex, @dob, @age, @nationality, @marriageDate, @occasion, @familyMember, @memberRss, @permanentAddr, @country, @state, @district, @city, @zone, @currAddr, @country1, @state1, @district1, @city1, @zone1, @officeAddr, @country2, @state2, @district2, @city2, @zone2, @emailId1, @emailId2, @contactNo1, @contactNo2, @contactNo3, @contactNo4, @qualification, @qSpec, @qSpec1, @qSpec2, @course1, @occupation, @eSpec, @eSpec1, @eSpec2, '1', @org1, @org1From, @org1To, @org1Ach, @org1Rem, '2', @org2, @org2From, @org2To, @org2Ach, @org2Rem, '3', @org3, @org3From, @org3To, @org3Ach, @org3Rem, '4', @org4, @org4From, @org4To, @org4Ach, @org4Rem, '1', @hobbies1, @extra1, '2', @hobbies2, @extra2, '3', @hobbies3, @extra3, '4', @hobbies4, @extra4, '5', @hobbies5, @extra5, @achievements, @behavior, @futureAmbition, @meetingReason, @meetingPlace, @meetingDate, @assignWork, @purpose, @isrno, @lb1, @lb10, @lb2, @lb3, @lb4, @lb5, @lb6, @lb7, @lb8, @lb9, @memo)";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                j = j + 1;
                isrno = isrno + 1;
            }             
            string jv1 = "<script>alert('Record has been saved, and your Registration No. is :" + txtreg_id.Text + ". Your ID and Password has been sent in your email id');</script>";          
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv1, false);
            transaction.Commit();
            con.Close();          
        }
        catch (Exception ex)
        {            
           transaction.Rollback();               
           con.Close();
           string jv1 = "<script>alert('Mobile number can not be repeated!!!');</script>";
           ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv1, false);
           //Label36.Text = ex.Message;
           return;
        }
        //Send_msg();       
        //Clear();
    }
    void Send_msg()
    {
        MailMessage mailMsg = new MailMessage();
        mailMsg.From = new MailAddress("admin@[your-website.com]");
        mailMsg.To.Add(txtemail_id1.Text);
        mailMsg.Subject = "Joining Message :";
        mailMsg.Body = "Congratulation " + txtname.Text + ", Your Registration No is :" + txtreg_id.Text;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "[SMTP_HOST]";
        smtp.EnableSsl = false;
        smtp.Port = 25;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("admin@[your-website.com]", "[SMTP_PASSWORD]");
        try
        {
            smtp.Send(mailMsg);
            Label36.Text = "Confirmation email has been sent in your Email ID!!!";
        }
        catch (Exception ex)
        {
            Label36.Text = ex.Message;
        }
    }
    void Clear()
    {        
        txtachievement_work.Text = "";
        txtachievements.Text = "";
        txtadditional_details.Text = "";
        txtadditional_remarks.Text = "";
        txtage.Text = "";
        ddl_occasion.Text = "";
        txtany_purpose.Text = "";
        txtbehavior_analysis.Text = "";
        txtcontact_no1.Text = "";
        txtcontact_no2.Text = "";
        txtcontact_no3.Text = "";
        txtcontact_no4.Text = "";
        txtcourse1.Text = "";               
        txtcurr_addr.Text = "";
        txtdate.Text = "";
        txtdob.Text = "";
        txtemail_id1.Text = "";
        txtemail_id2.Text = "";
        txtextra_act1.Text = "";
        txtextra_act2.Text = "";
        txtextra_act3.Text = "";
        txtextra_act4.Text = "";
        txtextra_act5.Text = "";
        txtfamily_member.Text = "";
        txtfuture_ambition.Text = "";
        txthobbies1.Text = "";
        txthobbies2.Text = "";
        txthobbies3.Text = "";
        txthobbies4.Text = "";
        txthobbies5.Text = "";
        txtmarriage_date.Text = "";        
        txtmeeting_date.Text = "";
        txtmeeting_place.Text = "";
        txtmeeting_reason.Text = "";
        txtmember_rss.Text = "";
        txtname.Text = "";
        txtnickname.Text = "";
        txtoffice_addr.Text = "";
        txtorg_date_from.Text = "";
        txtorg_date_to.Text = "";
        txtorg1.Text = "";
        txtorg1_achievement.Text = "";
        txtorg1_fromdate.Text = "";
        txtorg1_remark.Text = "";
        txtorg1_todate.Text = "";
        txtorg2.Text = "";
        txtorg2_achievement.Text = "";
        txtorg2_fromdate.Text = "";
        txtorg2_remark.Text = "";
        txtorg2_todate.Text = "";
        txtorg3.Text = "";
        txtorg3_achievement.Text = "";
        txtorg3_fromdate.Text = "";
        txtorg3_remark.Text = "";
        txtorg3_todate.Text = "";
        txtorg3.Text = "";
        txtorg4_achievement.Text = "";
        txtorg4_fromdate.Text = "";
        txtorg4_remark.Text = "";
        txtorg4_todate.Text = "";
        txtpermanent_addr.Text = "";
        txtreg_id.Text = "";
        ListBox1.Items.Clear();
        ListBox2.Items.Clear();
        ListBox3.Items.Clear();
        ListBox4.Items.Clear();
        ListBox5.Items.Clear();
        ListBox6.Items.Clear();
        ListBox7.Items.Clear();
        ListBox8.Items.Clear();
        ListBox9.Items.Clear();
        ListBox10.Items.Clear();
       
        AutoLoadData();

    }
    protected void btn_open_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "select * from RSS_Registration Where Reg_ID=@regId";
            cmd.Parameters.AddWithValue("@regId", txtreg_id.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtreg_id.Text = dr[0].ToString();
                txtdate.Text = dr[1].ToString();
                txtname.Text = dr[2].ToString();
                txtnickname.Text = dr[3].ToString();
                ddlsex.Text = dr[4].ToString();
                txtdob.Text = dr[5].ToString();
                txtage.Text = dr[6].ToString();
                ddlnationality.Text = dr[7].ToString();
                txtmarriage_date.Text = dr[8].ToString();
                ddl_occasion.Text = dr[9].ToString();
                txtfamily_member.Text = dr[10].ToString();
                txtmember_rss.Text = dr[11].ToString();
                txtpermanent_addr.Text = dr[12].ToString();
                ddl_country.Text = dr[13].ToString();
                ddl_state.Text = dr[14].ToString();
                ddl_district.Text = dr[15].ToString();
                ddl_city.Text = dr[16].ToString();
                ddl_zone.Text = dr[17].ToString();
                txtcurr_addr.Text = dr[18].ToString();
                ddl_country1.Text = dr[19].ToString();
                ddl_state1.Text = dr[20].ToString();
                ddl_district1.Text = dr[21].ToString();
                ddl_city1.Text = dr[22].ToString();
                ddl_zone1.Text = dr[23].ToString();
                txtoffice_addr.Text = dr[24].ToString();
                ddl_country2.Text = dr[25].ToString();
                ddl_state2.Text = dr[26].ToString();
                ddl_district2.Text = dr[27].ToString();
                ddl_city2.Text = dr[28].ToString();
                ddl_zone2.Text = dr[29].ToString();
                txtemail_id1.Text = dr[30].ToString();
                txtemail_id2.Text = dr[31].ToString();
                txtcontact_no1.Text = dr[32].ToString();
                txtcontact_no2.Text = dr[33].ToString();
                txtcontact_no3.Text = dr[34].ToString();
                txtcontact_no4.Text = dr[35].ToString();
                ddl_qualification.Text = dr[36].ToString(); 
                ddlspecialization.Text = dr[37].ToString();
                ddlspecialization1.Text = dr[38].ToString();
                ddlspelization2.Text = dr[39].ToString();
                txtcourse1.Text = dr[40].ToString();     
                ddloccupation.Text = dr[41].ToString();
                ddlspecialization4.Text = dr[42].ToString();
                ddlspecialization5.Text = dr[43].ToString();
                ddlspecialization6.Text = dr[44].ToString();
                txtorg1.Text = dr[46].ToString();
                txtorg1_fromdate.Text = dr[47].ToString();
                txtorg1_todate.Text = dr[48].ToString();
                txtorg1_achievement.Text = dr[49].ToString();
                txtorg1_remark.Text = dr[50].ToString();
                txtorg2.Text = dr[52].ToString();
                txtorg2_fromdate.Text = dr[53].ToString();
                txtorg2_todate.Text = dr[54].ToString();
                txtorg2_achievement.Text = dr[55].ToString();
                txtorg2_remark.Text = dr[56].ToString();
                txtorg3.Text = dr[58].ToString();
                txtorg3_fromdate.Text = dr[59].ToString();
                txtorg3_todate.Text = dr[60].ToString();
                txtorg3_achievement.Text = dr[61].ToString();
                txtorg3_remark.Text = dr[62].ToString();
                txtorg4.Text = dr[64].ToString();
                txtorg4_fromdate.Text = dr[65].ToString();
                txtorg4_todate.Text = dr[66].ToString();
                txtorg4_achievement.Text = dr[67].ToString();
                txtorg4_remark.Text = dr[68].ToString();
                txthobbies1.Text = dr[70].ToString();
                txtextra_act1.Text = dr[71].ToString();
                txthobbies2.Text = dr[73].ToString();
                txtextra_act2.Text = dr[74].ToString();
                txthobbies3.Text = dr[76].ToString();
                txtextra_act3.Text = dr[77].ToString();
                txthobbies4.Text = dr[79].ToString();
                txtextra_act4.Text = dr[80].ToString();
                txthobbies5.Text = dr[82].ToString();
                txtextra_act5.Text = dr[83].ToString();
                txtachievements.Text = dr[84].ToString();
                txtbehavior_analysis.Text = dr[85].ToString();
                txtfuture_ambition.Text = dr[86].ToString();
                txtmeeting_reason.Text = dr[87].ToString();
                txtmeeting_place.Text = dr[88].ToString();
                txtmeeting_date.Text = dr[89].ToString();
                ddlassign_work.Text = dr[90].ToString();
                txtany_purpose.Text = dr[91].ToString();
                txtmemo.Text = dr[103].ToString();                
            }
            dr.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = "select * from RSS_Registration Where Reg_ID=@regId2";
            cmd.Parameters.AddWithValue("@regId2", txtreg_id.Text);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListBox1.Items.Add(dr[93].ToString());
                ListBox10.Items.Add(dr[94].ToString());
                ListBox2.Items.Add(dr[95].ToString());
                ListBox3.Items.Add(dr[96].ToString());
                ListBox4.Items.Add(dr[97].ToString());
                ListBox5.Items.Add(dr[98].ToString());
                ListBox6.Items.Add(dr[99].ToString());
                ListBox7.Items.Add(dr[100].ToString());
                ListBox8.Items.Add(dr[101].ToString());
                ListBox9.Items.Add(dr[102].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            //lb_Message.Text = ex.Message;
            con.Close();
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        if (txtreg_id.Text.Trim() == "")
        {
            string jv = "<script>alert('Please enter User ID');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            txtreg_id.Focus();
            return;
        }
        try
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["BITRSS"].ConnectionString.Trim();
            con.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = "Delete from RSS_Registration Where Reg_ID=@regId";
            cmd.Parameters.AddWithValue("@regId", txtreg_id.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "Delete from RSS_SanghPariwar Where Reg_ID=@regId";
            cmd.Parameters.AddWithValue("@regId", txtreg_id.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            string jv = "<script>alert('Record has been Deleted!!!');</script>";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
            con.Close();
        }
        catch (Exception ex)
        {
            con.Close();
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {

    }
}

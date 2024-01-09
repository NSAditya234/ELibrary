using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ELibrary
{
    public partial class usersignup : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet DS = new DataSet();
            DS.ReadXml(Server.MapPath("/xmlfiles/States.xml"));

            ddlState.DataSource = DS;
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();

            ListItem li = new ListItem("Select Item", "-1");
            ddlState.Items.Insert(0, li);

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (checkMemberExists())
                {
                    /* alert start */
                    Session["alertMessage"] = "<strong> Failed! </strong>User is already exist Please use different UserID, Email, Mobile...";
                    Session["alertType"] = "<div class='alert alert-warning alert-dismissible fade show my-4' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                }
                else
                {
                    signUpNewMember();
                }
            }
            else
            {
                Response.Write("<script> alert('please enter valid id and password.'); </script>");
            }
        }

        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '" + tbUserId.Text.Trim() + "' OR email = '"+ tbEmail.Text.Trim() +"' OR contact_no = '"+ tbContactNo.Text.Trim() +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
                return false;
            }
        }

        protected void signUpNewMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address," +
                    "member_id,password,account_status,date_time_created) VALUES (@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address," +
                    "@member_id,@password,@account_status,@date_time_created)", con);
                cmd.Parameters.AddWithValue("@full_name", tbFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", tbDob.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", tbContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@email", tbEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddlState.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@city", tbCity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", tbPincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", tbAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", tbUserId.Text.Trim());
                cmd.Parameters.AddWithValue("@password", tbPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.Parameters.AddWithValue("@date_time_created", DateTime.Now.ToString());

                cmd.ExecuteNonQuery();
                con.Close();

                /* alert start */
                Session["alertMessage"] = "<strong> Success! </strong>Account Created. Go to user login and find your favorite books...";
                Session["alertType"] = "<div class='alert alert-success alert-dismissible fade show my-4' role='alert'>";
                Session["divClose"] = "</div>";
                /* alert end */
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }
    }
}
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
    public partial class userprofile : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    getUsersBookData();
                    getUserPersonalDetails();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void getUsersBookData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetIssueBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter("@member_id", Session["username"].ToString());
                    cmd.Parameters.Add(parameter);

                    con.Open();
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                tbFullName.Text = dt.Rows[0]["full_name"].ToString();
                tbDOB.Text = dt.Rows[0]["dob"].ToString();
                tbContactNo.Text = dt.Rows[0]["contact_no"].ToString();
                tbEmail.Text = dt.Rows[0]["email"].ToString();
                ddlState.SelectedValue = dt.Rows[0]["state"].ToString();
                tbCity.Text = dt.Rows[0]["city"].ToString();
                tbPincode.Text = dt.Rows[0]["pincode"].ToString();
                tbAddress.Text = dt.Rows[0]["full_address"].ToString();
                tbUserId.Text = dt.Rows[0]["member_id"].ToString();
                //tbOldPass.Text = dt.Rows[0]["password"].ToString();

                lAccountStatus.Text = dt.Rows[0]["account_status"].ToString().Trim().ToUpper();

                if (dt.Rows[0]["account_status"].ToString().Trim().ToUpper() == "ACTIVE")
                {
                    lAccountStatus.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim().ToUpper() == "PENDING")
                {
                    lAccountStatus.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim().ToUpper() == "DEACTIVE")
                {
                    lAccountStatus.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    lAccountStatus.Attributes.Add("class", "badge badge-pill badge-info");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void btnUpdateUserInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                updateUserPersonalDetails();
            }
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                updateUserPassword();
            }
        }

        void updateUserPassword()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '" +
                    Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                string password = dt.Rows[0]["password"].ToString();

                if (password == tbOldPass.Text.Trim())
                {
                    cmd = new SqlCommand("UPDATE member_master_tbl SET password=@password WHERE member_id = '" +
                    Session["username"].ToString() + "'", con);

                    cmd.Parameters.AddWithValue("@password", tbNewPass.Text.Trim());

                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {
                        Response.Write("<script> alert('Password Updated Successfuly.'); </script>");
                    }
                    else
                    {
                        Response.Write("<script> alert('SomeThing went wrong try again later.'); </script>");
                    }
                }
                else
                {
                    Response.Write("<script> alert('Your old password is incorrect if you forgot then contact to authority.'); </script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void updateUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET full_name=@full_name, dob=@dob, contact_no=@contact_no, " +
                    "email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address WHERE member_id = '" +
                    Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", tbFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", tbDOB.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", tbContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@email", tbEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddlState.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", tbCity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", tbPincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", tbAddress.Text.Trim());

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script> alert('Your details updated successfuly.'); </script>");
                    getUserPersonalDetails();
                    //getUsersBookData();
                }
                else
                {
                    Response.Write("<script> alert('USER does not exist.'); </script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }
    }
}
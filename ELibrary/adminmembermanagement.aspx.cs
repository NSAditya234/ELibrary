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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMemberIdGo_Click(object sender, EventArgs e)
        {
            getMemberById();
        }

        void getMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '" + tbMemberId.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {


                    while (dr.Read())
                    {
                        tbFullName.Text = dr.GetValue(1).ToString();
                        tbDOB.Text = dr.GetValue(2).ToString();
                        tbContactNo.Text = dr.GetValue(3).ToString();
                        tbEmail.Text = dr.GetValue(4).ToString();
                        tbState.Text = dr.GetValue(5).ToString();
                        tbCity.Text = dr.GetValue(6).ToString();
                        tbPincode.Text = dr.GetValue(7).ToString();
                        tbFullAddress.Text = dr.GetValue(8).ToString();
                        //tbMemberId.Text = dr.GetValue(8).ToString();
                        tbAccountStatus.Text = dr.GetValue(10).ToString();
                    }
                }
                else
                {
                    /* alert start */
                    Session["alertMessage"] = "<strong> Failed! </strong> Invalid UserID. No data found...";
                    Session["alertType"] = "<div class='alert alert-danger alert-dismissible fade show my-4' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void btnDeleteUserPermanent_Click(object sender, EventArgs e)
        {
            deleteMemberById();
        }

        void deleteMemberById()
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE member_master_tbl WHERE member_id = '" + tbMemberId.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    gvMembersList.DataBind();

                    /* alert start */
                    Session["alertMessage"] = "<strong> Success! </strong> Member with UserID ("+tbMemberId.Text+") Deleted...";
                    Session["alertType"] = "<div class='alert alert-warning alert-dismissible fade show my-4' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */

                    clearForm();

                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                }

            }
            else
            {
                /* alert start */
                Session["alertMessage"] = "<strong> Failed! </strong> Invalid Member ID...";
                Session["alertType"] = "<div class='alert alert-danger alert-dismissible fade show my-4' role='alert'>";
                Session["divClose"] = "</div>";
                /* alert end */
            }
        }

        protected void lbtnActive_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("active");
        }

        protected void lbtnPending_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("pending");
        }

        protected void lbtnDeactive_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("deactive");
        }

        void updateMemberStatusById(string status)
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status = '" + status + "' WHERE member_id = '" + tbMemberId.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    gvMembersList.DataBind();

                    /* alert start */
                    Session["alertMessage"] = "<strong> Success! </strong> Member with UserID (" + tbMemberId.Text + ") Status ("+status+") Updated...";
                    Session["alertType"] = "<div class='alert alert-success alert-dismissible fade show my-4' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                }

            }
            else
            {
                Response.Write("<script> alert('Invalid Member Id.'); </script>");
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = '" + tbMemberId.Text.Trim() + "'", con);
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

        void clearForm()
        {
            tbMemberId.Text = "";
            tbFullAddress.Text = "";
            tbFullName.Text = "";
            tbAccountStatus.Text = "";
            tbDOB.Text = "";
            tbContactNo.Text = "";
            tbEmail.Text = "";
            tbState.Text = "";
            tbCity.Text = "";
            tbPincode.Text = "";
        }

        protected void gvMembersList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    string status = e.Row.Cells[2].Text;
                    if(status == "pending")
                    {
                        e.Row.BackColor = System.Drawing.Color.Yellow;
                    }else if(status == "deactive")
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }else if(status == "active")
                    {
                        e.Row.BackColor = System.Drawing.Color.LightGreen;
                        //e.Row.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }
    }
}
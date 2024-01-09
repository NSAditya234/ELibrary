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
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            gvBookIssuingDetails.DataBind();
        }

        protected void btnBookIdGo_Click(object sender, EventArgs e)
        {
            getNames();
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (checkIfBookExist() && checkIfMemberExist())
                {
                    if (checkIfIssueEntryExist())
                    {
                        /* alert start */
                        Session["alertMessage"] = "<strong> Warning! </strong> "+tbMemberName.Text+" already has this ("+tbBookName.Text+") book...";
                        Session["alertType"] = "<div class='alert alert-warning alert-dismissible fade show my-4' role='alert'>";
                        Session["divClose"] = "</div>";
                        /* alert end */
                    }
                    else
                    {
                        issueBook();
                    }
                }
                else
                {
                    Response.Write("<script> alert('Wrong Book Id'); </script>");
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script> alert('This entry does not exist.'); </script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Wrong Book Id or Member Id'); </script>");
            }
        }

        void returnBook()
        {

            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id = '" + tbBookId.Text.Trim() + "'" +
                    "AND member_id = '" + tbMemberId.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock+1 WHERE book_id = '" + tbBookId.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    /* alert start */
                    Session["alertMessage"] = "<strong> Success! </strong> "+ tbMemberName.Text +" has been returned the book "+ tbBookName.Text +"...";
                    Session["alertType"] = "<div class='alert alert-success alert-dismissible fade show my-4' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */

                    gvBookIssuingDetails.DataBind();

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl (member_id, book_id, issue_date" +
                    ", due_date) VALUES (@member_id, @book_id, @issue_date, @due_date)", con);
                cmd.Parameters.AddWithValue("@member_id", tbMemberId.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", tbBookId.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", tbStartDate.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", tbEndDate.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock - 1 WHERE book_id = '" + tbBookId.Text.Trim()
                    + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();

                /* alert start */
                Session["alertMessage"] = "<strong> Success! </strong> Book "+ tbBookName.Text +" is issued to "+ tbMemberName.Text +"...";
                Session["alertType"] = "<div class='alert alert-success alert-dismissible fade show my-4' role='alert'>";
                Session["divClose"] = "</div>";
                /* alert end */

                gvBookIssuingDetails.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE book_id = '" + tbBookId.Text.Trim() + "'" +
                    " AND member_id = '" + tbMemberId.Text.Trim() + "'", con);
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

        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + tbBookId.Text.Trim() + "'" +
                    " AND current_stock > 0", con);
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

        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT full_name, account_status FROM member_master_tbl WHERE member_id = '" + tbMemberId.Text.Trim() + "'", con);
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

        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id = '" + tbBookId.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    tbBookName.Text = dt.Rows[0]["book_name"].ToString();
                    
                }
                else
                {
                    Response.Write("<script> alert('Invalid book ID.'); </script>");
                    tbBookName.Text = "";
                }

                cmd = new SqlCommand("SELECT full_name, account_status FROM member_master_tbl WHERE member_id = '" + tbMemberId.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    tbMemberName.Text = dt.Rows[0]["full_name"].ToString();
                    if (dt.Rows[0]["account_status"].ToString() == "pending" || dt.Rows[0]["account_status"].ToString() == "deactive")
                    {
                        Response.Write("<script> alert('The account status is deactive or pending.'); </script>");
                        btnIssue.Enabled = false;
                        btnIssue.CssClass = "btn btn-secondary btn-block";
                    }
                    else
                    {
                        btnIssue.Enabled = true;
                        btnIssue.CssClass = "btn btn-primary btn-block";
                    }
                }
                else
                {
                    Response.Write("<script> alert('Invalid member ID.'); </script>");
                    tbMemberName.Text = "";
                    btnIssue.Enabled = false;
                    btnIssue.CssClass = "btn btn-secondary btn-block";
                }

                //Response.Write("<script> alert('" + dt + "'); </script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void gvBookIssuingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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
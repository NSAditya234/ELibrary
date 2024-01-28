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
    public partial class adminauthormanagement : System.Web.UI.Page
    {

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAuthorIdGo_Click(object sender, EventArgs e)
        {
            if(tbAuthorId.Text.Equals(""))
            {
                Response.Write("<script> alert('Author id could not be empty.'); </script>");
            }else
            {
                getAuthorByID();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (checkAuthorExists())
                {
                    /* alert start */
                    Session["alertMessage"] = "<strong> Warning! </strong> Author with same ID or Name is already exist. Try another id or name....";
                    Session["alertType"] = "<div class='alert alert-warning alert-dismissible fade show my-4' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                }
                else
                {
                    addNewAuthor();
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid input field.'); </script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (checkAuthorExists())
                {
                    updateAuthor();
                }
                else
                {
                    /* alert start */
                    Session["alertMessage"] = "<strong> Failed! </strong> Author with ID = " + tbAuthorId.Text.Trim() + " does not exist....";
                    Session["alertType"] = "<div class='alert alert-danger alert-dismissible fade show my-4' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid input field.'); </script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (checkAuthorExists())
                {
                    deleteAuthor();
                }
                else
                {
                    /* alert start */
                    Session["alertMessage"] = "<strong> Failed! </strong> Author with ID = " + tbAuthorId.Text.Trim() + " does not exist....";
                    Session["alertType"] = "<div class='alert alert-danger alert-dismissible fade show my-4' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid input field.'); </script>");
            }
        }

        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id = '" + tbAuthorId.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    tbAuthorName.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    /* alert start */
                    Session["alertMessage"] = "<strong> Failed! </strong> Invalid Author ID...";
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

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id = '" + tbAuthorId.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();

                /* alert start */
                Session["alertMessage"] = "<strong> Success! </strong> Author ("+tbAuthorName.Text+") Deleted...";
                Session["alertType"] = "<div class='alert alert-warning alert-dismissible fade show my-4' role='alert'>";
                Session["divClose"] = "</div>";
                /* alert end */

                clearForm();
                gvAuthorDetails.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name WHERE author_id = '" + tbAuthorId.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@author_name", tbAuthorName.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                /* alert start */
                Session["alertMessage"] = "<strong> Success! </strong> Author Details Updated...";
                Session["alertType"] = "<div class='alert alert-success alert-dismissible fade show my-4' role='alert'>";
                Session["divClose"] = "</div>";
                /* alert end */

                clearForm();
                gvAuthorDetails.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl (author_id, author_name) VALUES (@author_id, @author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", tbAuthorId.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", tbAuthorName.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                /* alert start */
                Session["alertMessage"] = "<strong> Success! </strong> Author Details Added...";
                Session["alertType"] = "<div class='alert alert-success alert-dismissible fade show my-4' role='alert'>";
                Session["divClose"] = "</div>";
                /* alert end */

                clearForm();
                gvAuthorDetails.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id = '" + tbAuthorId.Text.Trim() + "' OR author_name = '"+ tbAuthorName.Text.Trim() +"'", con);
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
            tbAuthorId.Text = "";
            tbAuthorName.Text = "";
        }
    }
}
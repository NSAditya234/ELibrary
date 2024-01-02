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
                    Response.Write("<script> alert('Author with same ID or Name is already exist. Try another id.'); </script>");
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
                    Response.Write("<script> alert('Author with ID = " + tbAuthorId.Text.Trim() + " is not exists.') </script>");
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
                    Response.Write("<script> alert('Author with ID = " + tbAuthorId.Text.Trim() + " is not exists.') </script>");
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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

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
                    Response.Write("<script> alert('Invalid Author id.'); </script>");
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
                cmd.Clone();
                Response.Write("<script> alert('Author Deleted Successfully'); </script>");
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
                cmd.Clone();
                Response.Write("<script> alert('Author Updated successfully'); </script>");
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
                cmd.Clone();
                Response.Write("<script> alert('Author Added successfully'); </script>");
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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

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
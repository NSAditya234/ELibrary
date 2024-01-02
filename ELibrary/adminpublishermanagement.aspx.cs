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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPublisherGo_Click(object sender, EventArgs e)
        {
            if(tbPublisherId.Text.Equals(""))
            {
                Response.Write("<script> alert('Publisher id could not be empty.'); </script>");
            }
            else
            {
                getPublisherByID();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (checkPublisherExists())
                {
                    Response.Write("<script> alert('Publisher with same Id and Publisher Name is already exist. Try another id and name.'); </script>");
                }
                else
                {
                    addNewPublisher();
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid inputs.'); </script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (checkPublisherExists())
                {
                    updatePublisher();
                }
                else
                {
                    Response.Write("<script> alert('Publisher with ID = " + tbPublisherId.Text.Trim() + " is not exists.') </script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid inputs.'); </script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (checkPublisherExists())
                {
                    deletePublisher();
                }
                else
                {
                    Response.Write("<script> alert('Publisher with ID = " + tbPublisherId.Text.Trim() + " is not exists.') </script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid inputs.'); </script>");
            }
        }

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_id, publisher_name) VALUES (@publisher_id, @publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", tbPublisherId.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", tbPublisherName.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('publisher Added successfully'); </script>");
                clearForm();
                gvPublisherDetails.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name = @publisher_name WHERE publisher_id = '" + tbPublisherId.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@publisher_name", tbPublisherName.Text.Trim());

                cmd.ExecuteNonQuery();
                cmd.Clone();
                Response.Write("<script> alert('Publisher Updated successfully'); </script>");
                clearForm();
                gvPublisherDetails.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id = '" + tbPublisherId.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                cmd.Clone();
                Response.Write("<script> alert('Publisher Deleted Successfully'); </script>");
                clearForm();
                gvPublisherDetails.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        void getPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id = '" + tbPublisherId.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    tbPublisherName.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Invalid Publisher id.'); </script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id = '" + tbPublisherId.Text.Trim() + "' OR publisher_name='"+ tbPublisherName.Text.Trim() +"'", con);
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
            tbPublisherId.Text = "";
            tbPublisherName.Text = "";
        }
    }
}
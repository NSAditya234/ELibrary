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
    public partial class adminlogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbLogin_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                SqlConnection con = new SqlConnection(cs);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login_tbl WHERE username=@username AND password=@password", con);
                cmd.Parameters.AddWithValue("@username", tbAdminId.Text);
                cmd.Parameters.AddWithValue("@password", tbPassword.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('login successful'); </script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Id or Password Try again or Sign Up new account.'); </script>");
                }

            }
            else
            {
                Response.Write("<script> alert('please enter valid id and password.'); </script>");
            }    
        }
    }
}
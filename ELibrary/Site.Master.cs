using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString().Equals("admin"))
                {
                    lbUserLogin.Visible = false;
                    lbSignUp.Visible = false;

                    lbLogout.Visible = true;
                    lbHelloUser.Visible = true;
                    lbHelloUser.Text = "Hello " + Session["fullname"].ToString();

                    lbAdminLogin.Visible = false;
                    lbAuthorManagement.Visible = true;
                    lbPublisherManagement.Visible = true;
                    lbBookInventory.Visible = true;
                    lbBookIssuing.Visible = true;
                    lbMemberManagement.Visible = true;
                }

                if (Session["role"].ToString().Equals("user"))
                {
                    lbUserLogin.Visible = false;
                    lbSignUp.Visible = false;

                    lbLogout.Visible = true;
                    lbHelloUser.Visible = true;
                    lbHelloUser.Text = "Hello " + Session["fullname"].ToString();

                    lbAdminLogin.Visible = true;
                    lbAuthorManagement.Visible = false;
                    lbPublisherManagement.Visible = false;
                    lbBookInventory.Visible = false;
                    lbBookIssuing.Visible = false;
                    lbMemberManagement.Visible = false;
                }
            }
            else
            {
                lbUserLogin.Visible = true;
                lbSignUp.Visible = true;

                lbLogout.Visible = false;
                lbHelloUser.Visible = false;

                lbAdminLogin.Visible = true;
                lbAuthorManagement.Visible = false;
                lbPublisherManagement.Visible = false;
                lbBookInventory.Visible = false;
                lbBookIssuing.Visible = false;
                lbMemberManagement.Visible = false;
            }
        }

        protected void lbViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void lbUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void lbSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["role"] = null;
            Session["username"] = "";
            Session["fullname"] = "";
            Session["status"] = "";
            Response.Redirect("homepage.aspx");
        }

        protected void lbHelloUser_Click(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString().Equals("user"))
                {
                    Response.Redirect("userprofile.aspx");
                }
            }
        }

        protected void lbAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void lbAuthorManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void lbPublisherManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void lbBookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void lbBookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void lbMemberManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }
    }
}
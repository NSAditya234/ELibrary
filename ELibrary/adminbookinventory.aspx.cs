using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ELibrary
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_stock;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl",con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    ddlAuthorName.DataSource = dr;
                    ddlAuthorName.DataBind();
                    ListItem li = new ListItem("Select", "-1");
                    ddlAuthorName.Items.Insert(0, li);
                    con.Close();

                    cmd = new SqlCommand("SELECT * FROM publisher_master_tbl", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    ddlPublisherName.DataSource = dr;
                    ddlPublisherName.DataTextField = "publisher_name";
                    ddlPublisherName.DataValueField = "publisher_id";
                    ddlPublisherName.DataBind();
                    ddlPublisherName.Items.Insert(0, li);
                }
                ViewState["BookImg"] = "/book_inventory/books1.png";
            }
        }

        protected void btnBookIdGo_Click(object sender, EventArgs e)
        {
            getBookById();
        }

        void getBookById()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id = '" + tbBookId.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    tbBookName.Text = dt.Rows[0]["book_name"].ToString();
                    tbPublishDate.Text = dt.Rows[0]["publish_date"].ToString();
                    tbEdition.Text = dt.Rows[0]["edition"].ToString();
                    tbBookCost.Text = "" + Convert.ToInt32(dt.Rows[0]["book_cost"].ToString());
                    tbPages.Text = "" + Convert.ToInt32(dt.Rows[0]["no_of_pages"].ToString());
                    tbActualStock.Text = "" + Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString());
                    tbCurrentStock.Text = "" + Convert.ToInt32(dt.Rows[0]["current_stock"].ToString());
                    tbBookDescription.Text = dt.Rows[0]["book_description"].ToString();
                    tbIssuedBook.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    ddlLanguage.SelectedValue = dt.Rows[0]["language"].ToString();
                    ddlAuthorName.SelectedValue = dt.Rows[0]["author_id"].ToString();
                    ddlPublisherName.SelectedValue = dt.Rows[0]["publisher_id"].ToString();


                    lboxGenre.ClearSelection();
                    string[] genres = dt.Rows[0]["genre"].ToString().Trim().Split(',');

                    for (int i = 0; i < genres.Length; i++)
                    {
                        for (int j = 0; j < lboxGenre.Items.Count; j++)
                        {
                            if (lboxGenre.Items[j].ToString() == genres[i].Trim())
                            {
                                lboxGenre.Items[j].Selected = true;
                            }
                        }
                    }
                    
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                    ViewState["BookImg"] = global_filepath;
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString());
                    global_issued_stock = global_actual_stock - global_current_stock;
                }
                else
                {
                    /* alert start */
                    Session["alertMessage"] = "<strong> Failed! </strong> Invalid Book ID...";
                    Session["alertType"] = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (fuImage.HasFile)
                {
                    if (checkBookExists())
                    {
                        Response.Write("<script> alert('Book already exists try other book id or book name.'); </script>");
                    }
                    else
                    {
                        if (bookImageExists())
                        {
                            addNewBook();
                        }
                    }
                }
                else
                {
                    /* alert start */
                    Session["alertMessage"] = "<strong> Failed! </strong> Please Upload a image of your book";
                    Session["alertType"] = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                }
            }
        }

        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in lboxGenre.GetSelectedIndices())
                {
                    genres = genres + lboxGenre.Items[i] + ", ";
                }
                genres = genres.Remove(genres.Length - 2);

                string filepath = "/book_inventory/books1.png";
                string filename = Path.GetFileName(fuImage.PostedFile.FileName);
                fuImage.SaveAs(Server.MapPath("/book_inventory/" + filename));
                filepath = "/book_inventory/" + filename;
                ViewState["BookImg"] = filepath;

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id, book_name, genre, author_id, publisher_id, publish_date, language," +
                    "edition, book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) VALUES (@book_id, @book_name, @genre, " +
                    " @author_id, @publisher_id, @publish_date, @language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock, " +
                    "@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", tbBookId.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", tbBookName.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_id", ddlAuthorName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_id", ddlPublisherName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", tbPublishDate.Text.Trim());
                cmd.Parameters.AddWithValue("@language", ddlLanguage.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", tbEdition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", tbBookCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", tbPages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", tbBookDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", tbActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", tbActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                gvBookInventory.DataBind();

                /* alert start */
                Session["alertMessage"] = "<strong> Success! </strong> Book " + tbBookName.Text + " Details Added...";
                Session["alertType"] = "<div class='alert alert-success alert-dismissible fade show' role='alert'>";
                Session["divClose"] = "</div>";
                /* alert end */

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (bookImageExists())
                {
                    updateBookById();
                }
            }
        }

        void updateBookById()
        {
            if (checkBookExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(tbActualStock.Text.Trim());
                    int current_stock = Convert.ToInt32(tbCurrentStock.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_stock)
                        {
                            Response.Write("<script> alert('Actual stock value can not be less than issued books.'); </script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_stock;
                            tbCurrentStock.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in lboxGenre.GetSelectedIndices())
                    {
                        genres = genres + lboxGenre.Items[i] + ", ";
                    }
                    genres = genres.Remove(genres.Length - 2);

                    string filepath = "/book_inventory/books1.png";
                    string filename = Path.GetFileName(fuImage.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileInfo file = new FileInfo(Server.MapPath(global_filepath));
                        if(file.Exists)
                        {
                            file.Delete();
                        }
                        fuImage.SaveAs(Server.MapPath("/book_inventory/" + filename));
                        filepath = "/book_inventory/" + filename;
                        global_filepath = filepath;
                        ViewState["BookImg"] = filepath;
                    }


                    SqlConnection con = new SqlConnection(cs);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, genre=@genre, author_id=@author_id" +
                        ", publisher_id=@publisher_id, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost" +
                        ", no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock" +
                        ", book_img_link=@book_img_link WHERE book_id = '" + tbBookId.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", tbBookName.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_id", ddlAuthorName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_id", ddlPublisherName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", tbPublishDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", ddlLanguage.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", tbEdition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", tbBookCost.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", tbPages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", tbBookDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    gvBookInventory.DataBind();

                    /* alert start */
                    Session["alertMessage"] = "<strong> Success! </strong> Book " + tbBookName.Text + " Details Updated...";
                    Session["alertType"] = "<div class='alert alert-success alert-dismissible fade show' role='alert'>";
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
                Response.Write("<script> alert('Invalid Book Id.'); </script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
               deleteBookById();
            }
        }

        void deleteBookById()
        {
            if (checkBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    FileInfo fileInfo = new FileInfo(Server.MapPath(global_filepath));
                    if(fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE book_master_tbl WHERE book_id = '" + tbBookId.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    gvBookInventory.DataBind();

                    /* alert start */
                    Session["alertMessage"] = "<strong> Success! </strong> Book "+ tbBookName.Text +" Deleted...";
                    Session["alertType"] = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>";
                    Session["divClose"] = "</div>";
                    /* alert end */
                    ViewState["BookImg"] = "/book_inventory/books1.png";

                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "'); </script>");
                }

            }
            else
            {
                Response.Write("<script> alert('Invalid Book Id'); </script>");
            }
        }


        bool checkBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + tbBookId.Text.Trim() + "' OR book_name = '" +
                    tbBookName.Text.Trim() + "' ", con);
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

        bool bookImageExists()
        {
            string filepath = "/book_inventory/books1.png";
            string filename = Path.GetFileName(fuImage.PostedFile.FileName);
            fuImage.SaveAs(Server.MapPath("/book_inventory/" + filename));
            filepath = "/book_inventory/" + filename;
            FileInfo file = new FileInfo(Server.MapPath(filepath));
            ViewState["BookImg"] = filepath;
            if(file.Exists)
            {
                /* alert start */
                Session["alertMessage"] = "<strong> Failed! </strong> Image file already exists! Please change file name or Use different image...";
                Session["alertType"] = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>";
                Session["divClose"] = "</div>";
                /* alert end */
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        void clearForm()
        {
            tbBookId.Text = "";
            tbBookName.Text = "";
            ddlLanguage.SelectedIndex = -1;
            ddlAuthorName.SelectedIndex = -1;
            ddlPublisherName.SelectedIndex = -1;
            tbPublishDate.Text = "";
            lboxGenre.SelectedIndex = -1;
            tbEdition.Text = "";
            tbBookCost.Text = "";
            tbPages.Text = "";
            tbActualStock.Text = "";
            tbCurrentStock.Text = "";
            tbIssuedBook.Text = "";
            tbBookDescription.Text = "";
            ViewState["BookImg"] = "/book_inventory/books1.png";
        }

    }
}
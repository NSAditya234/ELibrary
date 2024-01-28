<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="ELibrary.adminbookinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imageview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Book Details</h4>
                            <img id="imageview" height="150" width="100" src="<%=ViewState["BookImg"].ToString() %>" />
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <hr />
                    </div>
                </div>

                <!-- Alerts start -->
                <% if (Session["alertMessage"] != null)
                    { %>
                <%=Session["alertType"] %>
                <%=Session["alertMessage"] %>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close" data-mdb-delay="3000">
                    <span aria-hidden="true">&times;</span>
                </button>
                <%=Session["divClose"] %>
                <% } %>
                <!-- Alerts end -->

                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="fuImage" runat="server" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="book img is required." ForeColor="Red" ControlToValidate="fuImage" Display="Dynamic" ValidationGroup="AddValid"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Book ID</label>
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="tbBookId" runat="server" placeholder="ID"></asp:TextBox>
                                <asp:Button CssClass="btn btn-secondary" CausesValidation="false" ID="btnBookIdGo" runat="server" Text="Go" OnClick="btnBookIdGo_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="book id is required." ForeColor="Red" ControlToValidate="tbBookId" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-9">
                        <div class="form-group">
                            <label>Book Name</label>
                            <asp:TextBox CssClass="form-control" ID="tbBookName" runat="server" placeholder="Book Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="book name is required." ForeColor="Red" ControlToValidate="tbBookName" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Language</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlLanguage" runat="server">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                <asp:ListItem Text="Marathi" Value="Marathi"></asp:ListItem>
                                <asp:ListItem Text="French" Value="French"></asp:ListItem>
                                <asp:ListItem Text="German" Value="German"></asp:ListItem>
                                <asp:ListItem Text="Sanskrit" Value="Sanskrit"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="language is required." ForeColor="Red" ControlToValidate="ddlLanguage" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Publisher Name</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlPublisherName" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Publisher Name is required." ForeColor="Red" ControlToValidate="ddlPublisherName" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Author Name</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlAuthorName" DataTextField="author_name" DataValueField="author_id" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Author Name is required." ForeColor="Red" ControlToValidate="ddlAuthorName" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Publish Date</label>
                            <asp:TextBox CssClass="form-control" TextMode="Date" ID="tbPublishDate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Publish Date is required." ForeColor="Red" ControlToValidate="tbPublishDate" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Genre</label>
                            <asp:ListBox CssClass="form-control" ID="lboxGenre" runat="server" SelectionMode="Multiple" Rows="5">
                                <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
                                <asp:ListItem Text="Adventure" Value="Adventure"></asp:ListItem>
                                <asp:ListItem Text="Comic Book" Value="Comic Book"></asp:ListItem>
                                <asp:ListItem Text="Self Help" Value="Self Help"></asp:ListItem>
                                <asp:ListItem Text="Motivation" Value="Motivation"></asp:ListItem>
                                <asp:ListItem Text="Healthy Living" Value="Healthy Living"></asp:ListItem>
                                <asp:ListItem Text="Wellness" Value="Wellness"></asp:ListItem>
                                <asp:ListItem Text="Crime" Value="Crime"></asp:ListItem>
                                <asp:ListItem Text="Drama" Value="Drama"></asp:ListItem>
                                <asp:ListItem Text="Fantasy" Value="Fantasy"></asp:ListItem>
                                <asp:ListItem Text="Horror" Value="Horror"></asp:ListItem>
                                <asp:ListItem Text="Poetry" Value="Poetry"></asp:ListItem>
                                <asp:ListItem Text="Personal Development" Value="Personal Development"></asp:ListItem>
                                <asp:ListItem Text="Romance" Value="Romance"></asp:ListItem>
                                <asp:ListItem Text="Science Fiction" Value="Science Fiction"></asp:ListItem>
                                <asp:ListItem Text="Suspense" Value="Suspense"></asp:ListItem>
                                <asp:ListItem Text="Thriller" Value="Thriller"></asp:ListItem>
                                <asp:ListItem Text="Art" Value="Art"></asp:ListItem>
                                <asp:ListItem Text="Autobiography" Value="Autobiography"></asp:ListItem>
                                <asp:ListItem Text="Encyclopedia" Value="Encyclopedia"></asp:ListItem>
                                <asp:ListItem Text="Health" Value="Health"></asp:ListItem>
                                <asp:ListItem Text="History" Value="History"></asp:ListItem>
                                <asp:ListItem Text="Math" Value="Math"></asp:ListItem>
                                <asp:ListItem Text="Textbook" Value="Textbook"></asp:ListItem>
                                <asp:ListItem Text="Science" Value="Science"></asp:ListItem>
                                <asp:ListItem Text="Travel" Value="Travel"></asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Genre is required." ForeColor="Red" ControlToValidate="lboxGenre" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Edition</label>
                            <asp:TextBox CssClass="form-control" ID="tbEdition" runat="server" placeholder="Edition"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Edition is required." ForeColor="Red" ControlToValidate="tbEdition" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Book Cost (Per Unit)</label>
                            <asp:TextBox CssClass="form-control" ID="tbBookCost" runat="server" placeholder="Cost" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Cost is required." ForeColor="Red" ControlToValidate="tbBookCost" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Page</label>
                            <asp:TextBox CssClass="form-control" ID="tbPages" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Pages is required." ForeColor="Red" ControlToValidate="tbPages" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Actual Stock</label>
                            <asp:TextBox CssClass="form-control" ID="tbActualStock" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Actual Stock is required." ForeColor="Red" ControlToValidate="tbActualStock" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Current Stock</label>
                            <asp:TextBox CssClass="form-control" ID="tbCurrentStock" runat="server" placeholder="Current Stock" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Issued Books</label>
                            <asp:TextBox CssClass="form-control" ID="tbIssuedBook" runat="server" placeholder="Issued Books" TextMode="Number" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <label>Book Description</label>
                            <asp:TextBox CssClass="form-control" ID="tbBookDescription" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Book Description is required." ForeColor="Red" ControlToValidate="tbBookDescription" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-outline-primary btn-block" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-outline-warning btn-block" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-outline-danger btn-block" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-dark btn-block" ID="btnClearForm" runat="server" Text="Clear" OnClick="btnClearForm_Click" CausesValidation="false"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Book Inventory List</h4>
                        </center>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="spGetBookInfo" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <div class="col">
                        <asp:GridView CssClass="table table-striped table-bordered" ID="gvBookInventory" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id"> 
                                    <ItemStyle Font-Bold="true" />
                                    </asp:BoundField>
                                <asp:TemplateField HeaderText="Book Info">
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-10">
                                                    <div class="row">
                                                        <div class="col-12">

                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">

                                                            Author -
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                            &nbsp;| Genre -
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                            &nbsp;| Language -
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">

                                                            Publisher -
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                            &nbsp;| Publish Date -
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                            &nbsp;| Pages -
                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                            &nbsp;| Edition -
                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">

                                                            Cost -
                                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                            &nbsp;| Actual Stock -
                                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                            &nbsp;| Available -
                                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">

                                                            Description -
                                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">

                                                    <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />

                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <a href="homepage.aspx" class="btn btn-link"><< Back to Home</a>
        </div>
    </div>

</asp:Content>

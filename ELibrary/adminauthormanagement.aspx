<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="ELibrary.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-title">
                        <div class="row mt-4">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="imgs/writer.png" />
                                </center>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="tbAuthorId" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-secondary" ID="btnAuthorIdGo" CausesValidation="false" runat="server" Text="Go" OnClick="btnAuthorIdGo_Click" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Author id is required." ControlToValidate="tbAuthorId" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Author Name</label>
                                    <asp:TextBox ID="tbAuthorName" runat="server" CssClass="form-control" placeholder="Author Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Author Name is required." ControlToValidate="tbAuthorName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Button CssClass="btn btn-primary btn-block" ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button CssClass="btn btn-success btn-block" ID="btnUpdate" runat="server" Text="UPDATE" OnClick="btnUpdate_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button CssClass="btn btn-danger btn-block" ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" />
                            </div>
                        </div>
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

            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="gvAuthorDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="ID" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="Author Name" SortExpression="author_name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <a href="homepage.aspx"><< back to home</a>
        </div>

    </div>

</asp:Content>

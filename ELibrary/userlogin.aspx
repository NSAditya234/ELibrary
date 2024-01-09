<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ELibrary.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="150" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                    <hr />
                            </div>
                        </div>

                        <%--Alert start--%>
                        <% if(Session["alertMessage"] != null) { %>
                        <%=Session["alertType"] %>
                        <%=Session["alertMessage"] %>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close" data-mdb-delay="3000">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <%=Session["divClose"] %>
                        <% } %>
                        <%--Alert start--%>

                        <div class="row">
                            <div class="col-9">
                                
                                <div class="form-group">
                                    <asp:TextBox ID="tbMemberId" runat="server" CssClass="form-control" placeholder="username"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="usersignup.aspx" class="text-decoration-none text-reset"><input class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Sign Up" /></a>
                                </div>

                            </div>

                            <div class="col-3">
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" ErrorMessage="username is Required" ControlToValidate="tbMemberId" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password is Required" ControlToValidate="tbPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>

                        </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< back to home</a>
            </div>
        </div>
    </div>

</asp:Content>

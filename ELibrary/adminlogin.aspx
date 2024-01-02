<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="ELibrary.adminlogin" %>
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
                                    <img src="imgs/adminuser.png" width="150" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                    <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-9">
                                
                                <div class="form-group">
                                    <asp:TextBox ID="tbAdminId" runat="server" CssClass="form-control" placeholder="Admin ID"></asp:TextBox>
                                    
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="tbLogin" runat="server" Text="Login" OnClick="tbLogin_Click" />
                                </div>

                            </div>
                            <div class="col-3">
                                <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" ErrorMessage="Id is Required" ControlToValidate="tbAdminId" ForeColor="Red"></asp:RequiredFieldValidator>
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

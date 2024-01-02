<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ELibrary.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="100" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span>Account Status - </span>
                                    <asp:Label ID="lAccountStatus" runat="server" Text="Active"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox ID="tbFullName" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Full Name is required" ControlToValidate="tbFullName" ForeColor="Red" Display="Dynamic" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Date of Birth</label>
                                    <asp:TextBox ID="tbDOB" runat="server" CssClass="form-control" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Date of Birth is required" ControlToValidate="tbDOB" ForeColor="Red" Display="Dynamic" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Contact No.</label>
                                    <asp:TextBox ID="tbContactNo" runat="server" CssClass="form-control" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Contact No is required" ControlToValidate="tbContactNo" ForeColor="Red" Display="Dynamic" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Email Id</label>
                                    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" placeholder="Email Id" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Email is required" ControlToValidate="tbEmail" ForeColor="Red" Display="Dynamic" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>State</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlState" runat="server">
                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Assam" Value="Assam"></asp:ListItem>
                                        <asp:ListItem Text="Bihar" Value="Bihar"></asp:ListItem>
                                        <asp:ListItem Text="Chattisgarh" Value="Chattisgarh"></asp:ListItem>
                                        <asp:ListItem Text="Rajasthan" Value="Rajasthan"></asp:ListItem>
                                        <asp:ListItem Text="Goa" Value="Goa"></asp:ListItem>
                                        <asp:ListItem Text="Gujarat" Value="Gujarat"></asp:ListItem>
                                        <asp:ListItem Text="Haryana" Value="Haryana"></asp:ListItem>
                                        <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Jammu And Kashmir" Value="Jammu And Kashmir"></asp:ListItem>
                                        <asp:ListItem Text="Jharkhand" Value="Jharkhand"></asp:ListItem>
                                        <asp:ListItem Text="Karnataka" Value="Karnataka"></asp:ListItem>
                                        <asp:ListItem Text="Kerala" Value="Kerala"></asp:ListItem>
                                        <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Maharashtra" Value="Maharashtra"></asp:ListItem>
                                        <asp:ListItem Text="Manipur" Value="Manipur"></asp:ListItem>
                                        <asp:ListItem Text="Meghalaya" Value="Meghalaya"></asp:ListItem>
                                        <asp:ListItem Text="Mizoram" Value="Mizoram"></asp:ListItem>
                                        <asp:ListItem Text="Nagaland" Value="Nagaland"></asp:ListItem>
                                        <asp:ListItem Text="Odisha" Value="Odisha"></asp:ListItem>
                                        <asp:ListItem Text="Punjab" Value="Punjab"></asp:ListItem>
                                        <asp:ListItem Text="Rajasthan" Value="Rajasthan"></asp:ListItem>
                                        <asp:ListItem Text="Sikkim" Value="Sikkim"></asp:ListItem>
                                        <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu"></asp:ListItem>
                                        <asp:ListItem Text="Telangana" Value="Telangana"></asp:ListItem>
                                        <asp:ListItem Text="Tripura" Value="Tripura"></asp:ListItem>
                                        <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Uttarakhand" Value="Uttarakhand"></asp:ListItem>
                                        <asp:ListItem Text="West Bengal" Value="West Bengal"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="State is required" ControlToValidate="ddlState" ForeColor="Red" Display="Dynamic" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>City</label>
                                    <asp:TextBox CssClass="form-control" ID="tbCity" runat="server" placeholder="City"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="City is required" ControlToValidate="tbCity" ForeColor="Red" Display="Dynamic" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Pincode</label>
                                    <asp:TextBox CssClass="form-control" ID="tbPincode" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Pincode is required" ControlToValidate="tbPincode" ForeColor="Red" Display="Dynamic" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Full Address</label>
                                    <asp:TextBox CssClass="form-control" ID="tbAddress" runat="server" placeholder="Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Address is required" ControlToValidate="tbAddress" ForeColor="Red" Display="Dynamic" ValidationGroup="updateInfo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block" ID="btnUpdateUserInfo" runat="server" Text="Update" OnClick="btnUpdateUserInfo_Click" ValidationGroup="updateInfo" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <span class="badge badge-pill badge-info">Login Credentials</span>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>User Id</label>
                                    <asp:TextBox CssClass="form-control" ID="tbUserId" runat="server" placeholder="User Id" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Old Password</label>
                                    <asp:TextBox CssClass="form-control" ID="tbOldPass" runat="server" placeholder="Old Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Old Password is required" ControlToValidate="tbOldPass" ForeColor="Red" Display="Dynamic" ValidationGroup="updatePass"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>New Password</label>
                                    <asp:TextBox CssClass="form-control" ID="tbNewPass" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Confirm Password</label>
                                    <asp:TextBox CssClass="form-control" ID="tbConfirmPass" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="New Password and Confirm Password should be same." ControlToValidate="tbConfirmPass" ControlToCompare="tbNewPass" Type="String" Operator="Equal" ForeColor="Red" ValidationGroup="updatePass"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mx-auto">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-info btn-block" ID="btnUpdatePassword" runat="server" Text="Update" OnClick="btnUpdatePassword_Click" ValidationGroup="updatePass"/>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books1.png" width="100" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                                    <asp:Label CssClass="badge badge-pill badge-info" ID="Label2" runat="server" Text="Your Books Status"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="full_name" HeaderText="Full Name" ReadOnly="True" SortExpression="full_name" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" ReadOnly="True" SortExpression="book_id" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" ReadOnly="True" SortExpression="book_name" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" ReadOnly="True" SortExpression="issue_date" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" ReadOnly="True" SortExpression="due_date" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="ELibrary.adminmembermanagement" %>
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
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Member Details</h4>
                            <img width="100" src="imgs/generaluser.png" />
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
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Member ID</label>
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="tbMemberId" runat="server" placeholder="ID"></asp:TextBox>
                                <asp:Button CssClass="btn btn-secondary" ID="btnMemberIdGo" runat="server" Text="Go" OnClick="btnMemberIdGo_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Full Name</label>
                            <asp:TextBox CssClass="form-control" ID="tbFullName" runat="server" placeholder="Name" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <div class="form-group">
                            <label>Account Status</label>
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control mr-1" ID="tbAccountStatus" runat="server" placeholder="status" ReadOnly="true"></asp:TextBox>
                                <asp:LinkButton CssClass="btn btn-success btn-sm mr-1" ID="lbtnActive" runat="server" OnClick="lbtnActive_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning btn-sm mr-1" ID="lbtnPending" runat="server" OnClick="lbtnPending_Click"><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger btn-sm mr-1" ID="lbtnDeactive" runat="server" OnClick="lbtnDeactive_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>DOB</label>
                            <asp:TextBox CssClass="form-control" ID="tbDOB" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Contact No.</label>
                            <asp:TextBox CssClass="form-control" ID="tbContactNo" runat="server" TextMode="Number" placeholder="Contact" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Email ID</label>
                            <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server" TextMode="Email" placeholder="Email" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>State</label>
                            <asp:TextBox CssClass="form-control" ID="tbState" runat="server" placeholder="state" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>City</label>
                            <asp:TextBox CssClass="form-control" ID="tbCity" runat="server" placeholder="city" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Pin Code</label>
                            <asp:TextBox CssClass="form-control" ID="tbPincode" runat="server" placeholder="pincode" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <label>Full Address</label>
                            <asp:TextBox CssClass="form-control" ID="tbFullAddress" runat="server" placeholder="Address" ReadOnly="true" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-danger btn-block btn-lg" ID="btnDeleteUserPermanent" runat="server" Text="Delete User Permanently" OnClick="btnDeleteUserPermanent_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Members List</h4>
                        </center>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="SELECT [member_id], [full_name], [account_status], [contact_no], [email], [state], [city] FROM [member_master_tbl]"></asp:SqlDataSource>
                    <div class="col">
                        <asp:GridView CssClass="table table-striped table-bordered" ID="gvMembersList" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1" OnRowDataBound="gvMembersList_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                <asp:BoundField DataField="full_name" HeaderText="Full Name" SortExpression="full_name" />
                                <asp:BoundField DataField="account_status" HeaderText="Status" SortExpression="account_status" />
                                <asp:BoundField DataField="contact_no" HeaderText="Mobile" SortExpression="contact_no" />
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <a href="homepage.aspx" class="btn btn-link"><< Back to Home</a>
        </div>
    </div>

</asp:Content>

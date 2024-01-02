<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="ELibrary.adminbookissuing" %>
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
                            <h4>Book Issuing</h4>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <center>
                            <img width="100" src="imgs/books.png" />
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <label>Member ID</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" placeholder="Member ID" ID="tbMemberId" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label>Book ID</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" placeholder="Book ID" ID="tbBookId" runat="server"></asp:TextBox>
                                <asp:Button CssClass="btn btn-dark" ID="btnBookIdGo" runat="server" Text="Go" OnClick="btnBookIdGo_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <label>Member Name</label>
                        <div class="form-group">
                            <asp:TextBox ReadOnly="true" CssClass="form-control" placeholder="Member Name" ID="tbMemberName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label>Book Name</label>
                        <div class="form-group">
                            <asp:TextBox ReadOnly="true" CssClass="form-control" placeholder="Book Name" ID="tbBookName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <label>Start Date</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" placeholder="Start Date" TextMode="Date" ID="tbStartDate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Start Date is required" ControlToValidate="tbStartDate" ForeColor="Red" ValidationGroup="validEnd" Display="Dynamic"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <label>End Date</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" placeholder="End Date" TextMode="Date" ID="tbEndDate" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="End Date is required" ControlToValidate="tbEndDate" ForeColor="Red" ValidationGroup="validEnd" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="End date should be greater than start date" ControlToValidate="tbEndDate" ControlToCompare="tbStartDate" Operator="GreaterThan" ForeColor="Red" ValidationGroup="validEnd" Display="Dynamic"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button CssClass="btn btn-secondary btn-block" ID="btnIssue" Enabled="false" runat="server" Text="Issue" OnClick="btnIssue_Click" ValidationGroup="validEnd" />
                    </div>
                    <div class="col-md-6">
                        <asp:Button CssClass="btn btn-success btn-block" ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Issued Book List</h4>
                        </center>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="spGetIssueBooks" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <div class="col">
                        <asp:GridView CssClass="table table-striped table-bordered" ID="gvBookIssuingDetails" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="gvBookIssuingDetails_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id">
                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="full_name" HeaderText="Member Name" ReadOnly="True" SortExpression="full_name">
                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id">
                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="book_name" HeaderText="Book Name" ReadOnly="True" SortExpression="book_name">
                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date">
                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date">
                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                            </Columns>
                           
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <a href="homepage.aspx"><< Back to home</a>
        </div>
    </div>

</asp:Content>

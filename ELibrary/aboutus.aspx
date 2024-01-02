<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aboutus.aspx.cs" Inherits="ELibrary.aboutus" %>

<%--Project Name: E-Library

Project Description:

The E-Library is a comprehensive Library Management System built using ASP.NET, C#, MS SQL Server, HTML, and CSS. It is designed to simplify the process of book borrowing for both users and administrators.

For users, the system provides an intuitive interface where they can search for books, view their borrowing history, and manage their account. The search functionality is robust, allowing users to find books based on various parameters such as title, author, genre, etc. Once a book is selected, users can check its availability and the number of copies left in the library.

For administrators, the E-Library system offers a suite of tools to manage the library’s inventory and users. Administrators have the exclusive authority to issue books to users. They can also add new books to the library, update book details, and manage user accounts.

The E-Library project aims to make library management more efficient and user-friendly, promoting a culture of reading and learning. It is a testament to the power of modern web technologies in transforming traditional systems.--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-9 mx-auto">
                <div class="card">
                    <%--<div class="row">--%>
                        <span class="card-header mx-auto"><b>E-Library Management System</b></span>
                    <%--</div>--%>
                    <div class="card-body">
                        <span class="card-header-pills"><b>Project Description: </b></span>
                        <br />
                        <p class="card-body">
                            The E-Library is a comprehensive Library Management System built using ASP.NET, C#, MS SQL Server, HTML, and CSS. It is designed to simplify the process of book borrowing for both users and administrators.
                            <br />
                            <br />

                            For users, the system provides an intuitive interface where they can search for books, view their borrowing history, and manage their account. The search functionality is robust, allowing users to find books based on various parameters such as title, author, genre, etc. Once a book is selected, users can check its availability and the number of copies left in the library.
                            <br />
                            <br />

                            For administrators, the E-Library system offers a suite of tools to manage the library’s inventory and users. Administrators have the exclusive authority to issue books to users. They can also add new books to the library, update book details, and manage user accounts.
                            <br />
                            <br />

                            The E-Library project aims to make library management more efficient and user-friendly, promoting a culture of reading and learning. It is a testament to the power of modern web technologies in transforming traditional systems.
                            <br />
                            <br />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

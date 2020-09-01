<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="Webpages_UserPage_UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <h1>Welcome, <asp:Label ID="name" Text="" runat="server"></asp:Label>!</h1>
    <h2>This is the user page, from here you are able to view user account info</h2>
    <br />
    <main>
    <form id="form1" runat="server" class="form-horizontal">

        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">Select a user:</div>
            <div class="col-sm-6">
                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="SqlDataSource2"
                    DataTextField="Username" DataValueField="Id" AutoPostBack="True" CssClass="form-control">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" 
                    SelectCommand="SELECT * FROM [dbo].[LoginTable] ORDER BY [Username]">
                </asp:SqlDataSource>
            </div>
        </div>
        <asp:Button ID="userSelect" Text="Select" runat="server" OnClick="BtnUserSelect" />
        <asp:Label ID="Label1" Text="" runat="server"></asp:Label>
        <asp:Label ID="Label2" Text="" runat="server"></asp:Label>
        <asp:Label ID="Label3" Text="" runat="server"></asp:Label>
        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">Username:</div>
            <div class="col-sm-6"><asp:Label ID="lblUname" Text="" visibility="True" runat="server"></asp:Label></div><br />
        </div>
        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">Phone:</div>
            <div class="col-sm-6"><asp:Label ID="lblUphone" Text="" visibility="True" runat="server"></asp:Label></div><br />
        </div>
        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">Email:</div>
            <div class="col-sm-6"><asp:Label ID="lblUemail" Text="" visibility="True" runat="server"></asp:Label></div>
        </div>
        <br />
        <br />
        <br />
    </form>
    </main>
    
</asp:Content>


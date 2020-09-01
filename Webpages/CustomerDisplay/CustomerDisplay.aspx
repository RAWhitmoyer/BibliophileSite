<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerDisplay.aspx.cs" Inherits="Webpages_CustomerDisplay_CustomerDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    
    <main>
    <form id="form1" runat="server" class="form-horizontal">

        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">Select a customer:</div>
            <div class="col-sm-6">
                <asp:DropDownList ID="ddlCustomers" runat="server" DataSourceID="SqlDataSource1"
                    DataTextField="Name" DataValueField="CustomerID" AutoPostBack="True" CssClass="form-control">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:TechSupportConnectionString %>" 
                    SelectCommand="SELECT * FROM [Customers] ORDER BY [Name]">
                </asp:SqlDataSource>
            </div>
        </div>
        <asp:Button ID="button" Text="Select" runat="server" OnClick="btnSelect" />
        <asp:Label ID="lbl1" Text="" runat="server"></asp:Label>
        <asp:Label ID="lbl2" Text="" runat="server"></asp:Label>
        <asp:Label ID="lbl3" Text="" runat="server"></asp:Label>
        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">Address:</div>
            <div class="col-sm-6"><asp:Label ID="lblAddress" Text="" visibility="True" runat="server"></asp:Label></div>
        </div>
        <div class="row">
            <div class="col-sm-offset-1 col-sm-3"></div>
            <div class="col-sm-6"><asp:Label ID="lblCityStateZip" Text="" visibility="True" runat="server"></asp:Label></div><br />
        </div>
        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">Phone:</div>
            <div class="col-sm-6"><asp:Label ID="lblPhone" Text="" visibility="True" runat="server"></asp:Label></div><br />
        </div>
        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">Email:</div>
            <div class="col-sm-6"><asp:Label ID="lblEmail" Text="" visibility="True" runat="server"></asp:Label></div>
        </div>
    </form>
    </main>



</asp:Content>


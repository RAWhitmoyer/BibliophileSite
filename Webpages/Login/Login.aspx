<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Webpages_Login_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <form runat="server">
        <article>
            <h2>Sign up</h2>


            <div class="auto-style6">

                

                <label for="uname" style="line-height: 2.8; margin-left: 20px">Username:</label>
                <asp:TextBox ID="uname" name="uname" CssClass="auto-style2" runat="server"></asp:TextBox>
                <br />
                <label for="pwd" style="line-height: 2.8; margin-left: 4.5px">Password:</label>
                <asp:TextBox ID="pwd" name="pwd" CssClass="auto-style3" runat="server"></asp:TextBox>
                <br />
                <label for="phone" style="line-height: 2.8; margin-left: 15px">Phone:</label>
                <asp:TextBox ID="phone" name="phone" CssClass="auto-style4" runat="server"></asp:TextBox>
                <br />
                <label for="email" style="line-height: 2.8; margin-left: 19px">Email:</label>
                <asp:TextBox ID="email" name="email" CssClass="auto-style5" runat="server"></asp:TextBox>

                <br /><br />
                <asp:Button ID="button" Text="Create" runat="server" OnClick="btnSignup_Click" />
                <asp:Label ID="lbl" Text="" runat="server"></asp:Label>
            </div>
        </article>
        <article>
            <h2>Login</h2>
            <div class="auto-style1">
                

                <label for="uname2" style="line-height: 2.8; margin-left: 20px">Username:</label>
                <asp:TextBox ID="uname2" name="uname2" CssClass="auto-style2" runat="server"></asp:TextBox>
                <br />
                <label for="pwd2" style="line-height: 2.8; margin-left: 4.5px">Password:</label>
                <asp:TextBox ID="pwd2" name="pwd2" CssClass="auto-style3" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Button ID="button2" Text="Log in" runat="server" OnClick="btnLogin_Click" />
                <asp:Label ID="lbl2" Text="" runat="server"></asp:Label>




            </div>




        </article>

    </form>
</asp:Content>
<asp:Content ID="LoginContent1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 310px;
            height: 148px;
            background-color: #4e5a65;
            border: 2px solid #000;
            font-size: 95%;
            padding: 10px;
            margin: 20px;
            width: 317px;
            color: white;
        }

        .auto-style2 {
            width: 200px;
            margin-left: 0px;
        }

        .auto-style3 {
            width: 200px;
        }

        .auto-style4 {
            width: 200px;
        }

        .auto-style5 {
            width: 200px;
        }
        .auto-style6 {
            width: 310px;
            height: 254px;
            background-color: #4e5a65;
            border: 2px solid #000;
            font-size: 95%;
            padding: 10px;
            margin: 20px;
            width: 328px;
            color: white;
        }
    </style>
</asp:Content>

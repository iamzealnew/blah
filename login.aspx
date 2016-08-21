<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master" CodeFile="login.aspx.cs" Inherits="login" %>



<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Label runat="server">Username</asp:Label>

    <asp:TextBox runat="server" ID="username"></asp:TextBox>

    <asp:Label runat="server">Password</asp:Label>

    <asp:TextBox runat="server" ID="password"></asp:TextBox>

    <asp:Button   runat="server" ID="submit" Text="Log In" OnClick="submit_Click" />
</asp:Content>
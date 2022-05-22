<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_15052022.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Home</asp:HyperLink>

    <asp:PlaceHolder ID="notLoginMenu" runat="server">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="loginMenu" runat="server">
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Logout.aspx">Logout</asp:HyperLink>
    </asp:PlaceHolder>
    

    <h1>Welcome <%= HttpContext.Current.Session[1] %> </h1>
    <table>
        <tr>
            <td>First Name: </td>
            <td><%= HttpContext.Current.Session[1] %></td>
        </tr>
        <tr>
            <td>Last Name: </td>
            <td><%= HttpContext.Current.Session[2] %></td>
        </tr>
    </table>
</asp:Content>

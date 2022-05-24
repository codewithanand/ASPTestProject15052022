<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ActivateAccount.aspx.cs" Inherits="_15052022.ActivateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="linkExpiredAlertBox" runat="server">
        <div class="alert alert-danger alert-dismissible fade show" role="alert">
            <strong>Error!</strong> Link is expired.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </asp:PlaceHolder>
    
    <div class="container my-5">
        <div class="col-md-12 shadow-sm p-3 mb-5 bg-body rounded">
            <asp:PlaceHolder ID="accountActiveMsg" runat="server">
                <h5>Success</h5>
                <p>Congratulations! Your account is activated. Please login to get started.</p>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javaScriptContent" runat="server">
</asp:Content>

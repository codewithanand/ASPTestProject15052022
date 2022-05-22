<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_15052022.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="activationAlertBox" runat="server">
        <div class="alert alert-danger alert-dismissible fade show" role="alert">
            <strong>Account Not Activated!</strong> Click on the link given in the email to activate your account.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="invalidUserAlertBox" runat="server">
        <div class="alert alert-warning alert-dismissible fade show" role="alert">
            <strong>Warning!</strong> Invalid login credentials.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </asp:PlaceHolder>
    <div class="container my-5">
        <h1 class="mb-4">Login</h1>
        <div class="col-md-6">
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label1" runat="server" Text="Email Address"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="email" runat="server" placeholder="johndoe@example.com"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label2" runat="server" Text="Password"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="pass" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 row">
                <div class="col-form-check">
                    <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                    <label class="form-check-label" for="flexCheckDefault">
                        Remember me
                    </label>
                </div>
            </div>
            <asp:Button CssClass="btn btn-primary" ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
        </div>
    </div>
</asp:Content>

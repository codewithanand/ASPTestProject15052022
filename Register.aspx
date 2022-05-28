<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_15052022.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="emailErrAlertBox" runat="server">
        <div class="alert alert-danger alert-dismissible fade show" role="alert">
            <strong>Warning!</strong> An user is already registered with this email address.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </asp:PlaceHolder>
    <div class="container my-5">
        <h1 class="mb-4">Registration</h1>
        <div class="col-md-6">
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label1" runat="server" Text="First Name"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="fname" runat="server" placeholder="John"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="fname" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label2" runat="server" Text="Last Name"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="lname" runat="server" placeholder="Doe"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label6" runat="server" Text="Gender"></asp:Label>
                <div class="col-md-4">
                    <asp:RadioButton CssClass="" ID="genMale" runat="server" GroupName="gender" Text=" Male" />
                </div>
                <div class="col-md-4">
                    <asp:RadioButton CssClass="" ID="genFemale" runat="server" GroupName="gender" Text=" Female" />
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label7" runat="server" Text="Caste"></asp:Label>
                <div class="col-md-8">
                    <asp:DropDownList CssClass="form-select" ID="casteList" runat="server">
                        <asp:ListItem Selected="False">Please select</asp:ListItem>
                        <asp:ListItem>SC</asp:ListItem>
                        <asp:ListItem>ST</asp:ListItem>
                        <asp:ListItem>OBC</asp:ListItem>
                        <asp:ListItem>GEN</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div> 
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label3" runat="server" Text="Email Address"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="email" runat="server" placeholder="johndoe@example.com"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ControlToValidate="email" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label4" runat="server" Text="Password"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="pass" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ControlToValidate="pass" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3 row">
                <asp:Label CssClass="col-sm-4 col-form-label" ID="Label5" runat="server" Text="Confirm Password"></asp:Label>
                <div class="col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="cpass" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="cpass" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" ControlToCompare="pass" ControlToValidate="cpass" ForeColor="Red"></asp:CompareValidator>
            </div>
            <asp:Label CssClass="col-sm-4 col-form-label" ID="errMsgLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:Button ID="registerBtn" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="registerBtn_Click" />
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="javaScriptContent" runat="server">
</asp:Content>

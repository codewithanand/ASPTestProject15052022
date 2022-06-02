<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="_15052022.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:PlaceHolder ID="succUpdateMsg" runat="server">
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            <strong>Success!</strong> Profile updated successfully.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </asp:PlaceHolder>


    <div class="container my-5">
        <div class="main-body">
            <div class="row">
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex flex-column align-items-center text-center">
                                <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Admin" class="rounded-circle" width="150">
                                <div class="mt-3">
                                    <h4>
                                        <asp:Label ID="pUserFname" runat="server" Text=""></asp:Label> <asp:Label ID="pUserLname" runat="server" Text=""></asp:Label>
                                    </h4>
                                    <p class="text-secondary mb-1">
                                        <asp:Label ID="pUserOccupation" runat="server" Text=""></asp:Label>
                                    </p>
                                    <p class="text-muted font-size-sm">
                                        <asp:Label ID="pUserAddress" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-8">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Full Name</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:TextBox CssClass="form-control mb-3" ID="userFname" runat="server"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="userLname" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Email</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="userEmailAdd" CssClass="form-control" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Gender</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <div class="col-md-4">
                                        <asp:RadioButton CssClass="" ID="genMale" runat="server" GroupName="userGender" Text=" Male" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RadioButton CssClass="" ID="genFemale" runat="server" GroupName="userGender" Text=" Female" />
                                    </div>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Caste</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:DropDownList CssClass="form-select" ID="userCaste" runat="server">
                                        <asp:ListItem Selected="False">Please select</asp:ListItem>
                                        <asp:ListItem>SC</asp:ListItem>
                                        <asp:ListItem>ST</asp:ListItem>
                                        <asp:ListItem>OBC</asp:ListItem>
                                        <asp:ListItem>GEN</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Mobile</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:TextBox CssClass="form-control" ID="userMobile" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Address</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:TextBox CssClass="form-control" ID="userAdd" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:Button class="btn btn-success" ID="updateProfileBtn" runat="server" Text="Update Profile" OnClick="updateProfileBtn_Click" />
                                    <asp:HyperLink CssClass="btn btn-danger" ID="HyperLink1" runat="server" NavigateUrl="~/MyProfile.aspx">Cancel</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javaScriptContent" runat="server">
</asp:Content>

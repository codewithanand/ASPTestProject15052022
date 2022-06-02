<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="_15052022.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <div class="main-body">
            <!-- /Breadcrumb -->
            <div class="row gutters-sm">
                <div class="col-md-4 mb-3">
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

                                   <!--  <button class="btn btn-primary">Follow</button> -->
                                   <!--  <button class="btn btn-outline-primary">Message</button> -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="card mb-3">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Full Name</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="userFname" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="userLname" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Email</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="userEmailAdd" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Gender</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="userGender" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Caste</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="userCaste" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Mobile</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="userMobile" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Address</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="userAdd" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:HyperLink ID="editProfileBtn" class="btn btn-danger" runat="server" NavigateURL="~/EditProfile.aspx">Edit Profile</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card mb-3">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-3">Password</h6>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:HyperLink ID="HyperLink1" class="btn btn-danger" runat="server" NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink>
                                    </div>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="_15052022.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="passChangedMsg" runat="server">
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            <strong>Success!</strong> Password changed successfully.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="passNotMatchedMsg" runat="server">
        <div class="alert alert-danger alert-dismissible fade show" role="alert">
            <strong>Error!</strong> Old password does not match.
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
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card mb-3">
                            <div class="card-body">
                                <div class="row mb-3">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Old Password</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary">
                                        <asp:TextBox CssClass="form-control" ID="userOldPass" runat="server" TextMode="Password" placeholder="Enter old password" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="userOldPass" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">New Password</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary">
                                        <asp:TextBox CssClass="form-control" ID="userNewPass" runat="server" TextMode="Password" placeholder="Enter new password" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="userNewPass" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Confirm Password</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary">
                                        <asp:TextBox CssClass="form-control" ID="userConfPass" runat="server" TextMode="Password" placeholder="Confirm new password" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ControlToValidate="userConfPass" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Password does not match" ControlToValidate="userConfPass" ControlToCompare="userNewPass" ForeColor="Red"></asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Button class="btn btn-success" ID="updatePassBtn" runat="server" Text="Update Password" OnClick="updatePassBtn_Click" />
                                        <asp:HyperLink CssClass="btn btn-danger" ID="HyperLink1" runat="server" NavigateUrl="~/MyProfile.aspx">Cancel</asp:HyperLink>
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

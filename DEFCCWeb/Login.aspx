<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container my-5">
        <div class="row">
            <div class="col-md-4 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="80px" src="images/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>
                                        Member Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div>
                                <asp:Label ID="lblmessage" ForeColor="Red" runat="server"></asp:Label>
                            </div>
                            <div class="col">
                                <label>
                                    User Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtUserName" runat="server" placeholder="User Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqUserName" runat="server" ControlToValidate="txtUserName" ForeColor="Red" ErrorMessage="Please enter user name"></asp:RequiredFieldValidator>
                                </div>
                                <label>
                                    Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="Password"
                                        TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ForeColor="Red" ErrorMessage="Please enter password"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="btnLogin" runat="server"
                                        Text="Login" onclick="btnLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


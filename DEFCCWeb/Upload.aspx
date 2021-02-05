<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container my-2" id="UploadMapSection" runat="server">
        <div class="row">
            <div class="col-md-12 col-sm-12 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div id="Div1" class="col" runat="server">
                                <center>
                                    <h3>
                                        Upload Map</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                                <asp:Label ID="lblSuccessMessage" ForeColor="Green" Text="File uploaded successfully"
                                    runat="server"></asp:Label>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <asp:Label ID="lblmessage" ForeColor="Green" Font-Bold="true" runat="server" />
                                    <div class="col-md-2">
                                        <label>
                                            Division :</label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:DropDownList ID="drpDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDivision_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label>
                                            Range :</label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:DropDownList ID="drpRange" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpRange_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <label>
                                            Thana :</label>
                                    </div>
                                    <div class=" col-md-2 form-group">
                                        <asp:DropDownList ID="drpThana" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="row">
                            <div class="col-md-2">
                                <label>
                                    Select Folder:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:DropDownList ID="drpFolder" runat="server">
                                </asp:DropDownList>
                                <span><a href="AddFolder.aspx">Create New Folder</a></span>
                            </div>
                            <div class="col-md-3">
                                <label>
                                    File Upload:</label>
                            </div>
                            <div class="col-md-3 form-group">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" Style="width: 85px" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container my-2" id="ViewMapSection" runat="server">
        <div class="row">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-body">
                        <center>
                            <h3>
                                View Map</h3>
                        </center>
                        <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>
                        <asp:GridView ID="grdThanaMap" runat="server" AutoGenerateColumns="false" BorderColor="black"
                            BorderWidth="1px" CellPadding="3" PageSize="5" CellSpacing="3" GridLines="None"
                            OnPageIndexChanging="grdUser_PageIndexChanging" OnSorting="grdUser_Sorting" AllowPaging="true"
                            AllowSorting="true" HeaderStyle-Height="30" Width="100%">
                            <AlternatingRowStyle BackColor="#99ccff" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="GrayText" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" Wrap="false" />
                            <PagerSettings Mode="Numeric" Visible="true" Position="TopAndBottom" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="ThanaName" HeaderText="Thana" ItemStyle-Height="30" ItemStyle-CssClass="gridLeftPadding"
                                    HeaderStyle-CssClass="gridLeftPadding" SortExpression="ThanaName" />
                                <asp:BoundField DataField="RangeName" HeaderText="Range" ItemStyle-Height="30" ItemStyle-CssClass="gridLeftPadding"
                                    HeaderStyle-CssClass="gridLeftPadding" SortExpression="RangeName" />
                                <asp:BoundField DataField="DivisionName" HeaderText="Division" ItemStyle-Height="30"
                                    ItemStyle-CssClass="gridLeftPadding" HeaderStyle-CssClass="gridLeftPadding" SortExpression="DivisionName" />
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <div class="gallerycontainer">
                                            <a class="thumbnail" href="#thumb">
                                                <asp:Image ID="thanaMap" runat="server" ImageUrl='<%#  Eval("ImagePath") %>' Height="50px"
                                                    Width="50px" />
                                                <span>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImagePath") %>' /><br />
                                                    Simply beautiful.</span></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                    <span> </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Download">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="False" CommandArgument='<%#  Eval("ImagePath") %>'
                                            OnClick="DownloadMap" Text='Download Map' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--   </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style type="text/css">
        .gallerycontainer
        {
            position: relative; /*Add a height attribute and set to largest image's height to prevent overlaying*/
        }
        
        .thumbnail img
        {
            border: 1px solid white;
            margin: 0 5px 5px 0;
        }
        
        .thumbnail:hover
        {
            background-color: transparent;
        }
        
        .thumbnail:hover img
        {
            border: 1px solid blue;
        }
        
        .thumbnail span
        {
            /*CSS for enlarged image*/
            position: absolute;
            background-color: lightyellow;
            padding: 5px;
            left: -1000px;
            border: 1px dashed gray;
            visibility: hidden;
            color: black;
            text-decoration: none;
        }
        
        .thumbnail span img
        {
            /*CSS for enlarged image*/
            border-width: 0;
            padding: 2px;
        }
        
        .thumbnail:hover span
        {
            /*CSS for enlarged image*/
            visibility: visible;
            top: 0;
            left: 10px; /*position where enlarged image should offset horizontally */
            z-index: 50;
        }
        .gridLeftPadding
        {
            padding-left: 5px;
        }
    </style>
</asp:Content>

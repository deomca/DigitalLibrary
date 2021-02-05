<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="AddFolder.aspx.cs" Inherits="AddFolder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container my-2" id="ViewMapSection" runat="server">
        <div class="row">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body text-center">
                       <b>Add / View Folder</b> 
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row" runat="server">
                            <div class="col-md-2">
                                <label>
                                    Folder Name:</label>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="txtFolderName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-3">
                                <label>
                                    Parent Folder:</label>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:DropDownList ID="drpParentFolder" runat="server">
                                    </asp:DropDownList>
                                </div>
                        </div>
                        <div class="col-md-2">
                                <asp:Button ID="btnSaveFolder" runat="server" Text="Save" OnClick="btnSaveFolder_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="container" id="ViewFolderSection"  runat="server">
                            <asp:GridView ID="grdFolder"  runat="server" AutoGenerateColumns="false" BorderColor="black"
                            BorderWidth="1px" CellPadding="3"  CellSpacing="3" GridLines="None"
                             HeaderStyle-Height="30" Width="100%">
                            <AlternatingRowStyle BackColor="#99ccff" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="GrayText" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" Wrap="false" />
                            <PagerSettings Mode="Numeric" Visible="true" Position="TopAndBottom" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <Columns>
                                    
                                    <asp:BoundField DataField="FolderName" ItemStyle-Height="30" ItemStyle-CssClass="gridLeftPadding"
                                    HeaderStyle-CssClass="gridLeftPadding"  HeaderText="Folder" />
                                      <asp:BoundField DataField="ParentFolderName" ItemStyle-Height="30" ItemStyle-CssClass="gridLeftPadding"
                                    HeaderStyle-CssClass="gridLeftPadding"  HeaderText="Parent Folder" />
  
                                     <asp:BoundField DataField="CreatedBy" ItemStyle-Height="30" ItemStyle-CssClass="gridLeftPadding"
                                    HeaderStyle-CssClass="gridLeftPadding"  HeaderText="Created By" />
                                     <asp:BoundField DataField="CreatedDate" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-Height="30" ItemStyle-CssClass="gridLeftPadding"
                                    HeaderStyle-CssClass="gridLeftPadding"  HeaderText="Created Date" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

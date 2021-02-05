<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="BrowsByFolder.aspx.cs" Inherits="BrowsByList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container my-5">
        <h3>
            Folder View</h3>
        <hr />
        <div style="float: right; width: 75%">
            <asp:PlaceHolder ID="plcHolder" runat="server"></asp:PlaceHolder>
        </div>
        <asp:TreeView ID="TreeView1" runat="server" Width="25%" ImageSet="XPFileExplorer"
            NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ExpandDepth="3"
            NodeWrap="True" TabIndex="1">
            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
            <LeafNodeStyle Font-Underline="False" />
            <NodeStyle Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="1px"
                VerticalPadding="2px"></NodeStyle>
            <ParentNodeStyle Font-Bold="True" BorderStyle="None" />
            <RootNodeStyle Font-Bold="True" Font-Size="Small" ForeColor="#0099FF" />
            <SelectedNodeStyle Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px"
                Font-Italic="True" ForeColor="#FF0066" />
        </asp:TreeView>
    </div>
</asp:Content>

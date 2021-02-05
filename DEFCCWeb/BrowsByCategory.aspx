<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true"
    CodeFile="BrowsByCategory.aspx.cs" Inherits="BrowsByCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="text-center my-5">
        <asp:Label ID="lbleSearhBy" runat="server">Search By : </asp:Label>
        <asp:RadioButton ID="rdDivision" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="rdDivisionChanged"/>Division
        <asp:RadioButton ID="rdRange" runat="server" AutoPostBack="true" OnCheckedChanged="rdRangeChanged" />Range
        <asp:RadioButton ID="rdThana" runat="server" AutoPostBack="true" OnCheckedChanged="rdThanaChanged" />Thana
        <div class="my-2" id="divDivision" runat="server">
            <asp:Label ID="lblDivision" runat="server" Text="Division"></asp:Label>
            <asp:DropDownList ID="drpDivision" runat="server">
            </asp:DropDownList>
        </div>
        <div class="my-2" id="divRange" visible="false" runat="server">
            <asp:Label ID="lblRange" runat="server" Text="Range"></asp:Label>
            <asp:DropDownList ID="drpRange" runat="server">
            </asp:DropDownList>
        </div>
        <div class="my-2" id="divThana" visible="false" runat="server">
            <asp:Label ID="lblThana" runat="server" Text="Thana"></asp:Label>
            <asp:DropDownList ID="drpThana" runat="server">
            </asp:DropDownList>
        </div>
        <div class="my-2" id="divButton" runat="server">
        <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
        </div>
        <hr />
    </div>
    <div>
        <asp:PlaceHolder ID="plcHolder" runat="server"></asp:PlaceHolder>       
    </div>
</asp:Content>

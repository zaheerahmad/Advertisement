<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="AdminSite.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContentArea" runat="server">
<div class="span12">
    <%if (AdminSite.Common.Common.showSideBar)
      { %>
    
    <%} %>
    
</div>
&nbsp;<br /><br /><asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>

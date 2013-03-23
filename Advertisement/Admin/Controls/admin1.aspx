<%@ Page Language="C#" AutoEventWireup="true" EnableSessionState="True" MasterPageFile="~/Admin/AdminSite.Master" CodeBehind="admin1.aspx.cs" Inherits="Advertisement.Admin.Controls.admin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContentArea" runat="server">
<div class="span12">
    <%if (AdminSite.Common.Common.showSideBar)
      { %>
    
    <%} %>
    
</div>
&nbsp;<br /><br /><asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>
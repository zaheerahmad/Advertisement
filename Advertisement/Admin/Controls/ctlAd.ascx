<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlAd.ascx.cs" Inherits="AdminSite.Controls.ctlAd" %>
<link href="~/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen"/>
<link href="~/assets/bootstrap/css/bootstrap-responsive.css" rel="stylesheet"/>

<script type="text/javascript">
    $(document).ready(function () {
        $("li#add").click(function () {
            $("li.#home").css({ "class": "active" });
        });
    });
</script>
<div class="span2">
    <ul class="nav nav-list">
      <li class="nav-header">Advertisements</li>
      <li id="home" class="active"><a href="Admin.aspx?ctl=5&id=<%=Session["userId"]%>">Home</a></li>
      <li id="add"><a href="Admin.aspx?ctl=2&id=<%=Session["userId"]%>">Post Ad</a></li>
      <li id="manage"><a href="Admin.aspx?ctl=3&id=<%=Session["userId"]%>">Manage Your Ads</a></li>
    </ul>
</div>
<div class="span8">
    <div class="page-header">
      <h1>Advertisement<small> Welcome to Advertisements Control</small></h1>
    </div>
    <div class="hero-unit">
        <legend><h3>Account Summary</h3></legend>
        <div class="row-fluid">
            <div class="span4">
                <table class="table">
                    <tr>
                        <td><p class="muted"><strong><asp:Label ID="lblActiveListing" runat="server"></asp:Label></strong></p></td>
                        <td>&nbsp;</td>
                        <td>Active Listings</td>
                    </tr>
                </table>
            </div>
            <div class="span4 offset1">
                <table class="table">
                    <tr>
                        <td><p class="muted"><strong><asp:Label ID="lblExpiredListing" runat="server"></asp:Label></strong></p></td>
                        <td>&nbsp;</td>
                        <td>Expired Listings</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <legend>Latest Ad</legend>
            <table class="table">
            <tr>
                    <th>Title</th>
                    <th>Image</th>
                    <th>Posted On (Date)</th>
                    <th>Asking Price</th>
                    <th>Status</th>
                    <th>&nbsp;</th>
                </tr>
                <%Advertisement.Controller.AdController adController = new Advertisement.Controller.AdController();
                  int i = 0;
                  foreach (Advertisement.Model.Ad ad in adController.FetchAll().Where("LoginId", Session["userId"]).OrderByDesc("AdDate"))
                  {
                      i++;
                      if (i == 5)
                      { break; }
                      %>
                        <tr>
                            <th><%=ad.AdTitle%></th>
                            <td><img src="../upload/AdImage/thumbnails/<%=ad.AdPicture.Substring(0,ad.AdPicture.IndexOf(','))%>" /></td>
                            <td><%=ad.AdDate %></td>
                            <td><%=ad.AdAskingPrice %></td>
                            <th><i class="icon-flag"></i>Availabe</th>
                            <td><a href="../Advertisement.aspx?ctl=1&id=<%=ad.AdId %>">Check Details</a></td>
                        </tr>
                  <%
                  }
                     %>
            </table>
        </div>
    </div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlManageAd.ascx.cs" Inherits="AdminSite.Controls.ctlManageAd" %>
<link href="~/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen"/>
<link href="~/assets/bootstrap/css/bootstrap-responsive.css" rel="stylesheet"/>
<script type="text/javascript">
    $(document).ready(function () {
        $('a').click(
        function () {
            $(this).parent().parent().fadeOut(1000);
            var AdId = $(this).attr('title');
            //Do something with link_text 
            $.ajax({
                type: "POST",
                url: "WebServices/AdService.asmx/RemoveAd",
                data: "{'pAdId':" + AdId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                cache: false,
                success: function (msg) {
                    var obj = jQuery.parseJSON(msg.d);


                }
            });
        });
        $('a#signUpAnchor').click(function () {
            $('a#signUpAnchor').parent().addClass('active');
        });
    });
</script>

<div class="span2" style="position:fixed">
    <ul class="nav nav-list">
      <li class="nav-header">ADVERTISEMENTS</li>
      <li id="home"><a href="admin1.aspx?ctl=5&id=<%=Session["userId"]%>">Home</a></li>
      <li id="add"><a href="admin1.aspx?ctl=2&id=<%=Session["userId"]%>">Post Ad</a></li>
      <li id="manage" class="active"><a href="admin1.aspx?ctl=3&id=<%=Session["userId"]%>">Manage Ads</a></li>
    </ul>
</div>
<div class="span8 offset2">
    <div class="page-header">
      <h1>Advertisement<small> Manage Ads</small></h1>
    </div>
    <form id="Form1" name="frmManageService" runat="server">
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <legend>Your Current Ads</legend>
            <table class="table table-hover">
                <tr>
                    <th>Title</th>
                    <th>Image</th>
                    <th>Posted On (Date)</th>
                    <th>Status</th>
                    <th><i class="icon-edit"></i></th>
                    <th><i class="icon-remove"></i></th>
                </tr>
                <%
                    Advertisement.Controller.Ad1Controller adController = new Advertisement.Controller.Ad1Controller();
                    int id = TTD.Common.Utility.GetIntParameter("id");
                    foreach (Advertisement.Model.Ad1 ad in adController.FetchByLoginID(Session["userId"]).OrderByDesc("AdDate"))
                    {%>
                        <tr id="<%=ad.AdId %>">
                            <td><%=ad.AdTitle %></td>
                            <td><img src="../../upload/AdImage/thumbnails/<%=ad.AdPicture.Substring(0,ad.AdPicture.IndexOf(',')) %>" alt="" /></td>
                            <td><%=ad.AdDate %></td>
                            <td><i class="icon-flag"></i><%=ad.AdStatus %></td>
                            <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2&id=<%=Session["userId"]%>&ad=<%=ad.AdId %>">Edit</a></td>
                            <td><i class="icon-remove"></i><a  title="<%=ad.AdId %>" href="#">Delete</a></td>
                        </tr>
                   <% }
                     %>
            </table>
    </form>
</div>
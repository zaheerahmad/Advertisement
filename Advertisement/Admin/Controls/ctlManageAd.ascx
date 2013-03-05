<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlManageAd.ascx.cs" Inherits="AdminSite.Controls.ctlManageAd" %>
<link href="~/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen"/>
<link href="~/assets/bootstrap/css/bootstrap-responsive.css" rel="stylesheet"/>
<script type="text/javascript">
    $(document).ready(function () {
        $('a').click(
        function () {
            $(this).parent().parent().fadeOut(1000);
            //Do something with link_text 
        });
        $('a#signUpAnchor').click(function () {
            $('a#signUpAnchor').parent().addClass('active');
        });
    });
</script>
<div class="span2" style="position:fixed">
    <ul class="nav nav-list">
      <li class="nav-header">ADVERTISEMENTS</li>
      <li id="home"><a href="Admin.aspx?ctl=5">Home</a></li>
      <li id="add"><a href="Admin.aspx?ctl=2">Post Ad</a></li>
      <li id="manage" class="active"><a href="Admin.aspx?ctl=3">Manage Ads</a></li>
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
                    <th>Material Name</th>
                    <th>Image</th>
                    <th>Posted On (Date)</th>
                    <th>Status</th>
                    <th><i class="icon-edit"></i></th>
                    <th><i class="icon-remove"></i></th>
                </tr>
                <tr id="1">
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a id="1" href="#">Delete</a></td>
                </tr>
                <tr id="2">
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a id="2" href="#">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#" onclick="fadeOut(this)">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#">Delete</a></td>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td><img src="../../assets/images/thumb1.jpg" alt="" /></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-flag"></i>Available</td>
                    <td><i class="icon-edit"></i><a href="Admin.aspx?ctl=2">Edit</a></td>
                    <td><i class="icon-remove"></i><a href="#">Delete</a></td>
                </tr>
            </table>
    </form>
</div>
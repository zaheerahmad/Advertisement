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
      <li id="home" class="active"><a href="Admin.aspx?ctl=5">Home</a></li>
      <li id="add"><a href="Admin.aspx?ctl=2">Post Ad</a></li>
      <li id="manage"><a href="Admin.aspx?ctl=3">Manage Your Ads</a></li>
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
                        <td><p class="muted"><strong>0</strong></p></td>
                        <td>&nbsp;</td>
                        <td>Active Listings</td>
                    </tr>
                </table>
            </div>
            <div class="span4 offset1">
                <table class="table">
                    <tr>
                        <td><p class="muted"><strong>0</strong></p></td>
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
                    <th>Material Name</th>
                    <th>Material Type</th>
                    <th>Image</th>
                    <th>Posted On (Date)</th>
                    <th>Status</th>
                    <th>&nbsp;</th>
                </tr>
                <tr>
                    <td>Material Name A</td>
                    <td>Material Type A</td>
                    <td></td>
                    <td>10-12-2012</td>
                    <td><i class="icon-ok"></i>Sold</td>
                    <td><a href="#">Check Details</a></td>
                </tr>
            </table>
        </div>
    </div>
</div>
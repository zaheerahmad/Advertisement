<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlPostAd.ascx.cs" Inherits="AdminSite.Controls.ctlPostAd" %>
<link href="~/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen"/>
<link href="~/assets/bootstrap/css/bootstrap-responsive.css" rel="stylesheet"/>

<script type="text/javascript">
    $(document).ready(function () {
        $("li#add").click(function () {
            $("li.#home").css({ "class": "active" });
        });
    });
</script>
<div class="span2" style="position:fixed">
    <ul class="nav nav-list">
      <li class="nav-header">Advertisements</li>
      <li id="home"><a href="Admin.aspx?ctl=5&id=<%=Session["userId"]%>">Home</a></li>
      <li id="add" class="active"><a href="Admin.aspx?ctl=2&id=<%=Session["userId"]%>">Post Ad</a></li>
      <li id="manage"><a href="Admin.aspx?ctl=3&id=<%=Session["userId"]%>">Manage Your Ads</a></li>
    </ul>
</div>
<div class="span8 offset2">
    <div class="page-header">
      <h1>Advertisement<small> Post Ad</small></h1>
    </div>
    <form name="frmAddService" class="form-horizontal" runat="server">
        <div class="alert alert-error" id="divStatusError" runat="server">
            <asp:Label ID="labelStatusError" runat="server"></asp:Label>
        </div>
        <div class="alert alert-success" id="divStatusSuccess" runat="server">
          <asp:Label ID="lblStatusSuccess" runat="server"></asp:Label>
        </div>
      <div class="control-group">
        <label class="control-label" for="txtServiceTitle">Title of your Ad</label>
        <div class="controls">
          <asp:TextBox ID="txtAdTitle" runat="server" placeHolder="Type Ad Title..."></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvServiceTitle" ControlToValidate="txtAdTitle" runat="server" ForeColor="Red" Text="*" />
        </div>
      </div>
      <div class="control-group">
        <label class="control-label" for="txtServiceDescription">Detail of your Ad</label>
        <div class="controls">
          <asp:TextBox ID="txtAdDetail" runat="server" placeHolder="Type Ad Description..." TextMode="MultiLine" MaxLength="100" Height="50px" Width="400px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvServiceDescription" ControlToValidate="txtAdDetail" runat="server" ForeColor="Red" Text="*" />
        </div>
      </div>
      <div class="control-group">
        <label class="control-label" for="txtAskingPrice">Asking Price</label>
        <div class="controls">
          <asp:TextBox ID="txtAskingPrice" runat="server" placeHolder="e.g. '250$' or 'On Call'" TextMode="SingleLine"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAskingPrice" runat="server" ForeColor="Red" Text="*" />
            <label class="checkbox">
                <asp:CheckBox ID="chkBoxFree" runat="server"/> Free
            </label>
        </div>
      </div>
      <div class="control-group">
        <label class="control-label" for="fuAdPictures">Pictures of your Ad<br /><small>You can add 4 pictures</small></label><br />
        <div class="controls">
            <asp:FileUpload ID="fuAdPicture1" runat="server"/>
            <asp:FileUpload ID="fuAdPicture2" runat="server" />
            <asp:FileUpload ID="fuAdPicture3" runat="server" />
            <asp:FileUpload ID="fuAdPicture4" runat="server" />
        </div>
      </div>
      <legend>Your Details</legend>
      <div class="control-group">
        <label class="control-label" for="txtContactNo">Contact Number</label>
        <div class="controls">
          <asp:TextBox ID="txtContactNo" runat="server" placeHolder="e.g. '+923219570199'" TextMode="SingleLine"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtContactNo" runat="server" ForeColor="Red" Text="*" />
        </div>
      </div>
      <div class="control-group">
        <label class="control-label" for="txtContactNo">Email</label>
        <div class="controls">
          <asp:TextBox ID="txtEmail" runat="server" placeHolder="something@domain.com" TextMode="SingleLine"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" runat="server" ForeColor="Red" Text="*" />
        </div>
      </div>
      <div class="control-group">
        <label class="control-label" for="txtAddress">Address(Optional)</label>
        <div class="controls">
          <asp:TextBox ID="txtAddress" runat="server" placeHolder="Type Address Here..." TextMode="MultiLine" MaxLength="100" Height="50px" Width="400px"></asp:TextBox>
        </div>
      </div>
      <div class="control-group">
        <div class="controls">
            <asp:Button ID="btnPostAd" class="btn btn-primary" runat="server" Text="Post Ad" 
                onclick="btnPostAd_Click"/>
        </div>
      </div>
    </form>
</div>
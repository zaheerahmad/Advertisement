<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlAddServices.ascx.cs" Inherits="AdminSite.Controls.ctlAddServices" %>
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
      <li id="home"><a href="Admin.aspx?ctl=5">Home</a></li>
      <li id="add" class="active"><a href="Admin.aspx?ctl=2">Post Ad</a></li>
      <li id="manage"><a href="Admin.aspx?ctl=3">Manage Your Ads</a></li>
    </ul>
</div>
<div class="span8">
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
        <label class="control-label" for="txtAddress">Address(Optional)</label>
        <div class="controls">
          <asp:TextBox ID="txtAddress" runat="server" placeHolder="Type Address Here'" TextMode="MultiLine" MaxLength="100" Height="50px" Width="400px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAddress" runat="server" ForeColor="Red" Text="*" />
        </div>
      </div>
      <div class="control-group">
        <div class="controls">
            <asp:Button ID="btnAddService" class="btn" runat="server" Text="Add Service" 
                onclick="btnAddService_Click"/>
        </div>
      </div>
    </form>
</div>
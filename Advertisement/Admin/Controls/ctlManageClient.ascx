<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlManageClient.ascx.cs" Inherits="AdminSite.Controls.ctlManageClient" %>
<link href="~/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen"/>
<link href="~/assets/bootstrap/css/bootstrap-responsive.css" rel="stylesheet"/>
<div class="span2">
    <ul class="nav nav-list">
      <li class="nav-header">Clients</li>
      <li id="home"><a href="Admin.aspx?ctl=8">Home</a></li>
      <li id="add"><a href="Admin.aspx?ctl=9">Add Clients</a></li>
      <li id="manage" class="active"><a href="Admin.aspx?ctl=10">Manage Clients</a></li>
    </ul>
</div>
<div class="span8">
    <div class="page-header">
      <h1>Clients<small> Manage Client</small></h1>
    </div>
    <form id="Form1" name="frmManageClients" runat="server">
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <asp:GridView ID="grdClients" runat="server" AutoGenerateColumns="False" 
        GridLines="None" Width="100%" OnRowCommand="rptClients_ItemCommand" OnPageIndexChanging="grdClients_PageIndexChanging"
        AllowPaging="True" CellPadding="4" ForeColor="#333333"  >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Label ID="EventID" runat="server" Text='<%# Bind("clientId") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Clients">
                <ItemStyle Width="900px" />
                <HeaderStyle HorizontalAlign="Left" />
                <ItemTemplate>
                <table width="100%">
                    <tr>
                        <td style="width:20%">
                            <%# Eval("clientName")%>
                        </td>
                        <td style="width:20%">
                            <%# Eval("clientContactPerson") %>
                        </td>
                        <td style="width:20%">
                            <%# Eval("clientContactNo") %>
                        </td>
                        <td style="width:20%">
                            <img src='../upload/ClientLogos/<%#Eval("clientLogo")%>' alt="No Image" width="100" height="120"/>
                        </td>
                    </tr>
                </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <a href='Admin.aspx?ctl=9&amp;id=<%#Eval("clientId")%>'>Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
                
            <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("clientId") %>' CausesValidation="False" CommandName="Del"
                Text="Delete"></asp:LinkButton>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>

            </Columns>
            <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </form>
</div>
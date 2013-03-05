using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OurWeb.Model;

namespace AdminSite.Controls
{
    public partial class ctlManageClient : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindClients();
        }

        public int NewsPageIndex
        {
            get
            { object o = this.ViewState["_PageIndex"];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }

            set
            {
                this.ViewState["_PageIndex"] = value;
            }
        }

        void BindClients()
        {
            ClientCollection clientCollection = new ClientCollection();
            //coll.Where(DocCat.Columns.Active, 1);
            clientCollection.Load();
            grdClients.DataSource = clientCollection;
            grdClients.DataBind();
            //pnlMain.UpdateAfterCallBack = true;

        }

        protected void grdClients_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClients.PageIndex = e.NewPageIndex;
            BindClients();
        }

        protected void btnShowAddCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Global.GetPageLink(Global.PageLink.AddClient));
        }

        void DeleteNews(int Id)
        {
            Client.Destroy(Id);
        }

        protected void rptClients_ItemCommand(object source, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            if (command == "Del")
            {
                DeleteNews(int.Parse(e.CommandArgument.ToString()));
                grdClients.EditIndex = -1;
                BindClients();
            }
        }
    }
}
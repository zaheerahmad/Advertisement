using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTD.Common;
using Advertisement.Controller;
using Advertisement.Model;

namespace AdminSite.Controls
{
    public partial class ctlAd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Advertisement.Controller.AdController adController = new Advertisement.Controller.AdController();

            foreach (Advertisement.Model.Ad ad in adController.FetchAll().Where("LoginId", Session["userId"]).Load())
            {
                int i = 0;
            }
            int userId = Utility.GetIntParameter("id");
            if (userId > 0)
            {
                AdCollection col = new AdCollection();
                col.Where("LoginId", userId).Load();
                if (col.Count > 0)
                {
                    lblActiveListing.Text = "" + col.Count;
                    lblExpiredListing.Text = "0";
                }
                else
                {
                    lblActiveListing.Text = "0";
                    lblExpiredListing.Text = "0";
                }
            }
        }
    }
}
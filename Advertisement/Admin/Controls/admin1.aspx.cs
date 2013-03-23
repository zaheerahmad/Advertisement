using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTD.Common;
using AdminSite.Controls;

namespace Advertisement.Admin.Controls
{
    public partial class admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {   
               int id = Utility.GetIntParameter("id");
               Session["userId"] = id;
                    //Session["userId"] = Utility.GetIntParameter("id");               
                                  
                    if (Utility.GetIntParameter("id") != null)
                    {
                        int control = Utility.GetIntParameter("ctl");
                        Utility.LoadPageContent(this.PlaceHolder1, ControlSettings.GetControlFileName((ControlSettings.ControlName)control, ""));

                    }
                    // do nothing
               
                else
                {
                    Response.Redirect("../../Advertisement.aspx");
                }

             
            }
            else
            {
                int id = Utility.GetIntParameter("id");
                if (Session["userId"].ToString().Equals("" + id))
                {
                    ViewState["userId"] = id.ToString();
                    int control = Utility.GetIntParameter("ctl");
                    //if (control > 0)
                    //{
                    //    Common.Common.showSideBar = true;
                    //}
                    //else
                    //{
                    Utility.LoadPageContent(this.PlaceHolder1, ControlSettings.GetControlFileName((ControlSettings.ControlName)control, ""));
                    //}
                }
                else
                {
                    int ctl = Utility.GetIntParameter("ctl");
                    id = Utility.GetIntParameter("id");
                    if (ctl == 4 && id != 0)
                    {
                        Utility.LoadPageContent(this.PlaceHolder1, ControlSettings.GetControlFileName((ControlSettings.ControlName)ctl, ""));
                    }
                    else
                    {
                        Response.Redirect("../../Advertisement.aspx");
                    }
                }
            }
        }
    }
}
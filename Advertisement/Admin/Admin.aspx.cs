﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTD.Common;
using AdminSite.Controls;

namespace AdminSite
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userId"] == null || Session["userId"].Equals(""))
            if (Session["userId"] == null)
            {
                Response.Redirect("../Advertisement.aspx");
            }
            else
            {
                int id = Utility.GetIntParameter("id");
                if (Session["userId"].ToString().Equals("" + id))
                {
                    int control = Utility.GetIntParameter("ctl");
                    //if (control > 0)
                    //{
                    //    Common.Common.showSideBar = true;
                    //}
                    //else
                    //{
                    Utility.LoadPageContent(this.PlaceHolder1, ControlSettings.GetControlFileName((ControlSettings.ControlName)control, Global.ControlsPath));
                    //}
                }
                else
                {
                    Response.Redirect("../Advertisement.aspx");
                }
            }
        }
    }
}
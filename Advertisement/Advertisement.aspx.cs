using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTD.Common;
using Advertisement.Controls;

namespace Advertisement
{
    public partial class Advertisement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int control = Utility.GetIntParameter("ctl");
            //if (control == 0)
            //{
            //    Utility.LoadPageContent(this.PlaceHolder1, ControlSettings.GetControlFileName((ControlSettings.ControlName)1, Global.ControlsPath));
            //    Utility.LoadPageContent(this.PlaceHolder2, ControlSettings.GetControlFileName((ControlSettings.ControlName)0, Global.ControlsPath));
            //}
            //else
            //{
                Utility.LoadPageContent(this.PlaceHolder1, ControlSettings.GetControlFileName((ControlSettings.ControlName)control, Global.ControlsPath));
            //}
        }
    }
}
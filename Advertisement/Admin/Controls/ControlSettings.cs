using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminSite.Controls
{
    public class ControlSettings
    {
        public enum ControlName : int
        {
            Welcome = 1,
            PostAd = 2,
            ManageAd = 3,
        }

        public static string GetControlFileName(ControlName controlId, string folderPath)
        {
            string controlName = "";
            string ext = ".ascx";
            switch (controlId)
            {
                case ControlName.Welcome:
                    controlName = "ctlWelcome";
                    break;
                case ControlName.PostAd:
                    controlName = "ctlPostAd";
                    break;
                case ControlName.ManageAd:
                    controlName = "ctlManageAd";
                    break;
                default:
                    controlName = "ctlAd";
                    break;
            }
            controlName += ext;
            return (String.IsNullOrEmpty(folderPath) == false ? folderPath + controlName : controlName);
        }
    }
}
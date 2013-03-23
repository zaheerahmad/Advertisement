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
            AdminAdDetail = 4,
            Ad = 5,
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
                case ControlName.AdminAdDetail:
                    controlName = "ctlAdminAdDetail";
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
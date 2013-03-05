using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advertisement.Controls
{
    public class ControlSettings
    {
        public enum ControlName : int
        {
            Home = 0,
            AdDetail = 1,
            PostAd = 2,
            ManageAd = 3,
            AddNews = 4,
            Ad = 5,
            News = 6,
            ManageNews = 7,
            Client = 8,
            AddClient = 9,
            ManageClient = 10,
            Project = 11,
            AddProject = 12,
            ManageProject = 13,
            Portfolio = 14,
            AddPortfolio = 15,
            ManagePortfolio = 16
        }

        public static string GetControlFileName(ControlName controlId, string folderPath)
        {
            string controlName = "";
            string ext = ".ascx";
            switch (controlId)
            {
                case ControlName.AdDetail:
                    controlName = "ctlAdDetail";
                    break;
                case ControlName.PostAd:
                    controlName = "ctlPostAd";
                    break;
                case ControlName.ManageAd:
                    controlName = "ctlManageAd";
                    break;
                case ControlName.AddNews:
                    controlName = "ctlAddNews";
                    break;
                case ControlName.Ad:
                    controlName = "ctlAd";
                    break;
                case ControlName.News:
                    controlName = "ctlNews";
                    break;
                case ControlName.ManageNews:
                    controlName = "ctlManageNews";
                    break;
                case ControlName.Client:
                    controlName = "ctlClient";
                    break;
                case ControlName.AddClient:
                    controlName = "ctlAddClient";
                    break;
                case ControlName.ManageClient:
                    controlName = "ctlManageClient";
                    break;
                case ControlName.Project:
                    controlName = "ctlProject";
                    break;
                case ControlName.AddProject:
                    controlName = "ctlAddProject";
                    break;
                case ControlName.ManageProject:
                    controlName = "ctlManageProject";
                    break;
                case ControlName.Portfolio:
                    controlName = "ctlPortfolio";
                    break;
                case ControlName.AddPortfolio:
                    controlName = "ctlAddPortfolio";
                    break;
                case ControlName.ManagePortfolio:
                    controlName = "ctlManagePortfolio";
                    break;
                default:
                    controlName = "ctlHome";
                    break;
            }
            controlName += ext;
            return (String.IsNullOrEmpty(folderPath) == false ? folderPath + controlName : controlName);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.IO;

namespace AdminSite.Common
{
    public static class Common
    {
        public static bool showSideBar = false;
        public static string selectedMenu = "Services";

        public static bool ResizeAndSaveImage(string pOriginalImagePath, string pNewPath, int pWidth, int pHeight)
        {
            Bitmap map = new Bitmap(Image.FromFile(pOriginalImagePath), new Size(pWidth, pHeight));
            map.Save(pNewPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            return true;
        }
    }
}
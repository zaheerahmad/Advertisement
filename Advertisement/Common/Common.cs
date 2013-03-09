using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advertisement.Common
{
    public static class Common
    {
        public static List<string> GetImageNameLists(string pListString)
        {
            List<string> imageList = new List<string>();
            string[] imageArr = pListString.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (imageArr.Length > 0)
            {
                foreach (string image in imageArr)
                {
                    imageList.Add(image);
                }
            }
            return imageList;
        }
    }
}
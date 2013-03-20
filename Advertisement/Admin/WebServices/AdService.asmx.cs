using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Advertisement.Model;
using Advertisement.Controller;

namespace Advertisement.Admin.WebServices
{
    /// <summary>
    /// Summary description for AdService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class AdService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public void RemoveAd(int pAdId)
        {
            Ad ad = new Ad("AdId", pAdId);
            if (ad != null)
            {
                Ad.Delete(ad.AdId);
            }
        }
    }
}

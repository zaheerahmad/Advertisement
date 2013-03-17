using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advertisement.Common
{
    public class ServiceResponce
    {
        public string html { get; set; }
        public int serviceErrorCode { get; set; }
        public string message { get; set; }
        public int id { get; set; }
        public string htmlFeatureAdd { get; set; }

        public ServiceResponce()
        {
            html = string.Empty;
            htmlFeatureAdd = string.Empty;
            serviceErrorCode = -1;
            message = string.Empty;
            id = 0;
        }
    }
}
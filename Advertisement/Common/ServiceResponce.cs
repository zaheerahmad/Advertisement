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

        public ServiceResponce()
        {
            html = string.Empty;
            serviceErrorCode = -1;
        }
    }
}
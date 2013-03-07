﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Advertisement.Common;

namespace Advertisement.WebServices
{
    /// <summary>
    /// Summary description for Users
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class Users : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string SignUpUser(string fullName, string userName, string password)
        {
            Model.User user = new Model.User("userName", userName);
            if (user.FName.Equals("") && user.Username.Equals("") && user.Password.Equals(""))
            {
                user.IsNew = true;
                user.FName = fullName;
                user.Username = userName;
                user.Password = password;
                user.Role = "Standard";
                user.Save();
                ServiceResponce serviceResponce = new ServiceResponce
                {
                    serviceErrorCode = 0
                };
                string jsonString = serviceResponce.ToJSON();
                return jsonString;
            }
            ServiceResponce serviceResponceError = new ServiceResponce
            {
                serviceErrorCode = 1
            };
            string jsonStringError = serviceResponceError.ToJSON();
            return jsonStringError;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Advertisement.Common;
using System.Web.SessionState;

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

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        
        public string SignInUser(string userName, string password)
        {
            Model.User user = new Model.User("userName", userName);
            if (user.FName.Equals("") && user.Username.Equals("") && user.Password.Equals(""))
            {
                ServiceResponce serviceResponce = new ServiceResponce
                {
                    serviceErrorCode = 1
                };
                string jsonString = serviceResponce.ToJSON();
                return jsonString;
            }
            else
            {
                if (user.Password.Equals(password))
                {
                    ServiceResponce serviceResponceError = new ServiceResponce
                    {
                        serviceErrorCode = 0,
                        id = user.LoginId
                    };
                    Session.Timeout = 40;
                    Session["userId"] = user.LoginId;
                    string jsonStringError = serviceResponceError.ToJSON();
                    return jsonStringError;
                }
                else
                {
                    ServiceResponce serviceResponceError = new ServiceResponce
                    {
                        serviceErrorCode = 1
                    };
                    string jsonStringError = serviceResponceError.ToJSON();
                    return jsonStringError;
                }   
            }
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ManageUser(string adverId, string suggestionText)
        {
            try
            {
                if (!string.IsNullOrEmpty(adverId) && !string.IsNullOrEmpty(suggestionText))
                {
                    Model.Suggestion sugesstion = new Model.Suggestion();
                    sugesstion.AdverId = Convert.ToInt32(adverId);
                    sugesstion.SuggestionText = suggestionText;
                    sugesstion.Save();
                }
              
            }
            catch (Exception ex)
            {

            }
            return string.Empty;
        }
    }
}

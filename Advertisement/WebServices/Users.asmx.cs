﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using Advertisement.Common;
using System.Web.SessionState;
using Advertisement.Controller;
using Advertisement.Model;
using System.Text;
using System.Web.Configuration;



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
                    Session.Timeout = 140;
                    Session["userId"] = user.LoginId;
                    Session["username"] = user.Username;
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
                    string username = string.Empty;
                    Model.Suggestion sugesstion = new Model.Suggestion();
                    if (Session != null)
                    {
                        username = Convert.ToString(Session["username"]);
                    
                        sugesstion.AdverId = Convert.ToInt32(adverId);
                        sugesstion.SuggestionText = suggestionText;
                        sugesstion.Username = username;
                        sugesstion.Save();
                        return string.Empty;

                    }


                    username = Convert.ToString(Session["username"]);                  
                    sugesstion.AdverId = Convert.ToInt32(adverId);
                    sugesstion.SuggestionText = suggestionText;
                    sugesstion.Username = "Anonymous";
                    sugesstion.Save();
                }
              
            }
            catch (Exception ex)
            {

            }
            return string.Empty;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetUpdatedAdds(string paginationVal)
        {
            if (string.IsNullOrEmpty(paginationVal))
            {
                paginationVal = "1";


            }
            string returnHtml = string.Empty;
            StringBuilder sbReturnHtml = new StringBuilder();
            StringBuilder sbReturnHtmlGallery = new StringBuilder();
            string strPagination = string.Empty;

           
            Dictionary<string, int> paramsDict = new Dictionary<string, int>();
           
            
            
            
            try
            {
             
                string username = string.Empty;
                int paginationCount = Convert.ToInt32(WebConfigurationManager.AppSettings["pagination"]);
                AdController adController = new AdController();
                AdCollection coll2 = adController.FetchAll();
                int totalCount = coll2.Count;
                                    
                AdCollection coll = adController.FetchPagination(paginationCount, Convert.ToInt32(paginationVal)).OrderByDesc("AdDate");
                                   

             
                paramsDict["paginationCount"] = paginationCount;
                paramsDict["paginationLimit"] = totalCount;
                paramsDict["selectedParam"] = Convert.ToInt32(paginationVal);
                strPagination =  PreparePagination(paramsDict);



                //int countAdds = 0;
                foreach (Ad ad in coll)
                {
                    //if (countAdds == paginationCount)
                    //{
                    //    break;
                    //}
                    //countAdds += 1;
                  

                    User user = new User("LoginId", ad.LoginId);
                    username = user.Username;
                    string[] arr = ad.AdPicture.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string image in arr){
                        sbReturnHtmlGallery.AppendFormat(@"
                                                   <a href='Advertisement.aspx?ctl=1&id={0}' class='show'>
                                                    <img src='../upload/AdImage/MainSlider/{1}' alt='Flowing Rock' width='950' height='450' title='' alt='' rel='<h3>{2}</h3>{3}/>
                                                   </a>
                                                   <div class='caption'><div class='content'></div></div>", ad.AdId, image, ad.AdTitle, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100)+" ..." : ad.AdDetail);
                    }
                    
                    
                    
                    sbReturnHtml.AppendFormat(@" <div class='media infoDiv'  style='margin-top:19px;'>
                                                <a class='pull-left' href='../Advertisement.aspx?ctl=1&id={0}'>
                                                    <img class='media-object imgInfo' src='../upload/AdImage/thumbnails/{1}' alt='No Image'></img>
                                                </a>
                                               <div class='media-body'>
                                                <div class='row'>
                                                    <div class='span5'>
                                                        <h4 class='media-heading'>{7}</h4> 
                                                    </div>
                                                    <div class='span3 priceDiv'>
                                                        <span>{2}</span>
                                                    </div>
                                                </div>
                                                 <div class='row'>
                                                    <div class='span5'>
                                                        <div class='media'>
                                                            {3}
                                                        
                                                        </div>
                                                    </div>
                                                    <div class='span3 moreInfo'>
                                                               <ul> 
                                                               
                                                                    <li><i class='icon-asterisk'></i><strong>{4}</strong></li>
                                                                    <li><i class='icon-asterisk'></i><strong>{5}</strong></li>
                                                                    <li><i class='icon-ok'></i><strong>{6}</strong></li>
                                                               </ul>
                                                    </div>
                                               </div>
                                            </div>

                                        </div>

                                                    ", Convert.ToString(ad.AdId), ad.AdPicture.Substring(0, ad.AdPicture.IndexOf(',')), ad.AdAskingPrice, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100)+" ..." : ad.AdDetail, username, ad.AdAddress, ad.AdStatus, ad.AdTitle);
//                    sbReturnHtml.AppendFormat(@" <div class='row materialContent'>
//                                       
//                                         
//                                            <div class='media infoDiv'  style='margin-top:19px;'>
//                                         <a class='pull-left' href='../Advertisement.aspx?ctl=1&id={0}'>
//                                             <img class='media-object imgInfo' src='../upload/AdImage/thumbnails/{1}' alt='No Image'></img>
//                                          </a>
//                                          <div class='media-body'>
//                                            <div class='row'>
//                                                <div class='span5'>
//                                                     <h4 class='media-heading'>{7}</h4> 
//                                                </div>
//                                                <div class='span3 priceDiv'>
//                                                 <span>{2}</span>
//                                                </div>
//                                           </div>
//                                               <div class='row'>
//                                                    <div class='span5'>
//                                                        <div class='media'>
//
//                                                            {3}
//                                                        </div>
//                                                    </div>
//                                                    <div class='span3 moreInfo'>
//                                                              <ul> 
////                                                               
////                                                                    <li><i class='icon-asterisk'></i><strong>{4}</strong></li>
////                                                                    <li><i class='icon-asterisk'></i><strong>{5}</strong></li>
////                                                                    <li><i class='icon-ok'></i><strong>{6}</strong></li>
////                                                               </ul>
//                                                    </div>
//                                               </div>
//                                          </div>
//
//                                        </div>
//                                         <% }
//                                             %>
//
//                                        <div class='row'>
//                                                      <ul class='pager'>
//                                                              <li class='previous'>
//                                                                    <a href='#' onClick=''>&larr; Older</a>
//                                                              </li>
//                                                               <li class='next'>
//                                                                    <a href='#'>Newer &rarr;</a>
//                                                                </li>
//                                                       </ul>
//                                        </div>
//                               </div>", Convert.ToString(ad.AdId), ad.AdPicture.Substring(0, ad.AdPicture.IndexOf(',')), ad.AdAskingPrice, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100) : ad.AdDetail, username, ad.AdAddress, ad.AdStatus, ad.AdTitle);

                }
            }
            catch(Exception ex)
            {
            }

           
            
            ServiceResponce serviceResponceError = new ServiceResponce
            {
                serviceErrorCode = 0,
                html = Convert.ToString(sbReturnHtml),
                htmlPagination = strPagination,
            };
            string jsonStringError = serviceResponceError.ToJSON();
            return jsonStringError;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string FilterResultsByDate(string startDate, string endDate, string paginationVal)
        {
            string returnHtml = string.Empty;
            StringBuilder sbReturnHtmlGallery = new StringBuilder();
            StringBuilder sbReturnHtml = new StringBuilder();
            int paginationCount = Convert.ToInt32(WebConfigurationManager.AppSettings["pagination"]);
            string strPagination = string.Empty;
         
           
            if (string.IsNullOrEmpty(paginationVal))
            {
                paginationVal = "1";


            }
            string[] lsStartDate;
            string[] lsEndDate;
            string username = string.Empty;
            try
            {
                System.DateTime dtEndDate = new DateTime();
                bool bothDates = false;
                lsStartDate = startDate.Split('/');
                if (!string.IsNullOrEmpty(endDate))
                {
                    lsEndDate = endDate.Split('/');
                    int eDmonth = Convert.ToInt32(lsEndDate[0]);
                    int eDday = Convert.ToInt32(lsEndDate[1]);
                    int eDyear = Convert.ToInt32(lsEndDate[2]);
                    dtEndDate = new DateTime(eDyear, eDmonth, eDday, 0, 0, 0, 0);
                    bothDates = true;
                }
                int sDmonth = Convert.ToInt32(lsStartDate[0]);
                int sDday = Convert.ToInt32(lsStartDate[1]);
                int sDyear = Convert.ToInt32(lsStartDate[2]);

                System.DateTime dtStartDate = new DateTime(sDyear, sDmonth, sDday, 0, 0, 0, 0);

                if (bothDates)
                {
                    if (dtStartDate > dtEndDate)
                    {
                        return string.Empty;
                    }

                }

                AdCollection adver = new AdController().FetchByDate("AdDate", dtStartDate, dtEndDate, paginationCount, Convert.ToInt32(paginationVal));
                int totalCount = adver.Count;

                Dictionary<string, int> paramsDict = new Dictionary<string, int>();
                paramsDict["paginationCount"] = paginationCount;
                paramsDict["paginationLimit"] = totalCount;
                paramsDict["selectedParam"] = Convert.ToInt32(paginationVal);
                strPagination = PreparePagination(paramsDict);


                foreach (Ad ad in adver)
                {

                    User user = new User("LoginId", ad.LoginId);
                    username = user.Username;
                    string[] arr = ad.AdPicture.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string image in arr)
                    {
                        sbReturnHtmlGallery.AppendFormat(@"
                                                   <a href='Advertisement.aspx?ctl=1&id={0}' class='show'>
                                                    <img src='../upload/AdImage/MainSlider/{1}' alt='Flowing Rock' width='950' height='450' title='' alt='' rel='<h3>{2}</h3>{3}/>
                                                   </a>
                                                   <div class='caption'><div class='content'></div></div>", ad.AdId, image, ad.AdTitle, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100) + " ..." : ad.AdDetail);
                    }



                    sbReturnHtml.AppendFormat(@" <div class='media infoDiv'  style='margin-top:19px;'>
                                                <a class='pull-left' href='../Advertisement.aspx?ctl=1&id={0}'>
                                                    <img class='media-object imgInfo' src='../upload/AdImage/thumbnails/{1}' alt='No Image'></img>
                                                </a>
                                               <div class='media-body'>
                                                <div class='row'>
                                                    <div class='span5'>
                                                        <h4 class='media-heading'>{7}</h4> 
                                                    </div>
                                                    <div class='span3 priceDiv'>
                                                        <span>{2}</span>
                                                    </div>
                                                </div>
                                                 <div class='row'>
                                                    <div class='span5'>
                                                        <div class='media'>
                                                            {3}
                                                        
                                                        </div>
                                                    </div>
                                                    <div class='span3 moreInfo'>
                                                               <ul> 
                                                               
                                                                    <li><i class='icon-asterisk'></i><strong>{4}</strong></li>
                                                                    <li><i class='icon-asterisk'></i><strong>{5}</strong></li>
                                                                    <li><i class='icon-ok'></i><strong>{6}</strong></li>
                                                               </ul>
                                                    </div>
                                               </div>
                                            </div>

                                        </div>

                                                    ", Convert.ToString(ad.AdId), ad.AdPicture.Substring(0, ad.AdPicture.IndexOf(',')), ad.AdAskingPrice, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100) + " ..." : ad.AdDetail, username, ad.AdAddress, ad.AdStatus, ad.AdTitle);
                }



            }
            catch (Exception ex)
            {

            }

            ServiceResponce serviceResponceError = new ServiceResponce
            {
                serviceErrorCode = 0,
                html = Convert.ToString(sbReturnHtml),
                htmlPagination = strPagination,
            };
            string jsonStringError = serviceResponceError.ToJSON();
            return jsonStringError;

        }


        public string PreparePagination(Dictionary<string,int> paramsDict)
        {
            string returnString = string.Empty;
            StringBuilder sbReturnPaginationHtml = new StringBuilder();
            if (paramsDict.ContainsKey("paginationCount") && paramsDict.ContainsKey("paginationLimit"))
            {
                double paginationCount = paramsDict["paginationCount"];
                double paginationLimit = paramsDict["paginationLimit"];
                int selectedPagination = paramsDict["selectedParam"];
                if (paginationLimit < paginationCount)
                {
                                       
                    return string.Empty;
                }
                double res = paginationLimit / paginationCount;
                double totalPages =Math.Ceiling(res);

                for(int i = 0; i < totalPages; i++){
                    if (i + 1 == selectedPagination)
                    {
                        sbReturnPaginationHtml.AppendFormat(@"
                                      <ul>                           
                                        <li class='currentLi'><a href='#'>{0}</a></li>
                                                              
                                      </ul>
                                ", Convert.ToString(i + 1));
                    }
                    else
                    {
                        sbReturnPaginationHtml.AppendFormat(@"
                                          <ul>                           
                                            <li><a href='#'>{0}</a></li>
                                                              
                                          </ul>
                                    ", Convert.ToString(i + 1));
                    }
                }
                    

            }

            return Convert.ToString(sbReturnPaginationHtml);
        }
      
    }
     

}

using System;
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
                    if (Session["username"] != null)
                    {
                        username = Convert.ToString(Session["username"]);
                    
                        sugesstion.AdverId = Convert.ToInt32(adverId);
                        sugesstion.SuggestionText = suggestionText;
                        sugesstion.Username = username;
                        sugesstion.Save();



                        ServiceResponce serviceResponceError = new ServiceResponce
                        {
                            serviceErrorCode = 0,
                            html = username,
                           
                        };
                        string jsonStringError = serviceResponceError.ToJSON();
                        return jsonStringError;


                    }


                              
                    sugesstion.AdverId = Convert.ToInt32(adverId);
                    sugesstion.SuggestionText = suggestionText;
                    sugesstion.Username = "Anonymous";
                    sugesstion.Save();



                    ServiceResponce serviceResponceError1 = new ServiceResponce
                    {
                        serviceErrorCode = 0,
                        html = "Anonymous",

                    };
                    string jsonStringError1 = serviceResponceError1.ToJSON();
                    return jsonStringError1;



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
                Ad1Controller adController = new Ad1Controller();
                Ad1Collection coll2 = adController.FetchAll();
                int totalCount = coll2.Count;
                                    
                Ad1Collection coll = adController.FetchPagination(paginationCount, Convert.ToInt32(paginationVal)).OrderByAsc("AdDate");
                                   

             
                paramsDict["paginationCount"] = paginationCount;
                paramsDict["paginationLimit"] = totalCount;
                paramsDict["selectedParam"] = Convert.ToInt32(paginationVal);
                strPagination =  PreparePagination(paramsDict);



                //int countAdds = 0;
                foreach (Ad1 ad in coll)
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
                                                   <a href='index.aspx?ctl=1&id={0}' class='show'>
                                                    <img src='../upload/AdImage/MainSlider/{1}' alt='Flowing Rock' width='950' height='450' title='' alt='' rel='<h3>{2}</h3>{3}/>
                                                   </a>
                                                   <div class='caption'><div class='content'></div></div>", ad.AdId, image, ad.AdTitle, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100)+" ..." : ad.AdDetail);
                    }
                    
                    
                    
                    sbReturnHtml.AppendFormat(@" <div class='media infoDiv'  style='margin-top:19px;'>
                                                <a class='pull-left' href='../index.aspx?ctl=1&id={0}'>
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

                                                    ", Convert.ToString(ad.AdId), ad.AdPicture.Substring(0, ad.AdPicture.IndexOf(',')), ad.AdAskingPrice, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100)+" ..." : ad.AdDetail, username, ad.AdDate.ToString(), ad.AdStatus, ad.AdTitle);
//                    sbReturnHtml.AppendFormat(@" <div class='row materialContent'>
//                                       
//                                         
//                                            <div class='media infoDiv'  style='margin-top:19px;'>
//                                         <a class='pull-left' href='../index.aspx?ctl=1&id={0}'>
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
                        ServiceResponce serviceResponceError = new ServiceResponce
                        {
                            serviceErrorCode = 1,
                            html = "Start date couldn't be greater than end date",
                            htmlPagination = string.Empty,
                        };
                        string returnJson = serviceResponceError.ToJSON();
                        return returnJson;
                    }

                }

                Ad1Collection adver = new Ad1Controller().FetchByDate("AdDate", dtStartDate, dtEndDate, paginationCount, Convert.ToInt32(paginationVal)).OrderByAsc("AdDate");
                int totalCount = adver.Count;


                if (totalCount == 0)
                {
                    ServiceResponce serviceResponceError = new ServiceResponce
                    {
                        serviceErrorCode = 2,
                        html = "<div class='alert alert-info'>No results found .. !</div>",
                        htmlPagination = string.Empty,
                    };
                    string returnJson = serviceResponceError.ToJSON();
                    return returnJson;


                }



                Dictionary<string, int> paramsDict = new Dictionary<string, int>();
                paramsDict["paginationCount"] = paginationCount;
                paramsDict["paginationLimit"] = totalCount;
                paramsDict["selectedParam"] = Convert.ToInt32(paginationVal);
                strPagination = PreparePagination(paramsDict);


                foreach (Ad1 ad in adver)
                {

                    User user = new User("LoginId", ad.LoginId);
                    username = user.Username;
                    string[] arr = ad.AdPicture.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string image in arr)
                    {
                        sbReturnHtmlGallery.AppendFormat(@"
                                                   <a href='index.aspx?ctl=1&id={0}' class='show'>
                                                    <img src='../upload/AdImage/MainSlider/{1}' alt='Flowing Rock' width='950' height='450' title='' alt='' rel='<h3>{2}</h3>{3}/>
                                                   </a>
                                                   <div class='caption'><div class='content'></div></div>", ad.AdId, image, ad.AdTitle, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100) + " ..." : ad.AdDetail);
                    }



                    sbReturnHtml.AppendFormat(@" <div class='media infoDiv'  style='margin-top:19px;'>
                                                <a class='pull-left' href='../index.aspx?ctl=1&id={0}'>
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

            ServiceResponce serviceResponceErrorFinal = new ServiceResponce
            {
                serviceErrorCode = 0,
                html = Convert.ToString(sbReturnHtml),
                htmlPagination = strPagination,
            };
            string jsonStringError = serviceResponceErrorFinal.ToJSON();
            return jsonStringError;

        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string NextPaginator(string paginationEndValue)
        {
            StringBuilder returnPaginator = new StringBuilder();

            try
            {
                    Ad1Collection ad = new Ad1Controller().FetchAll().OrderByAsc("AdDate");
                    double totalCount = ad.Count;


                    double paginationCount = Convert.ToInt32(WebConfigurationManager.AppSettings["pagination"]);



                    double res = totalCount / paginationCount;
                    double totalAdds = Math.Ceiling(res);



                    int paginationEndVal = Convert.ToInt32(paginationEndValue);
                    int loopStartValue = paginationEndVal + 1;

                    double orgPaginationEndValue = paginationEndVal;
                
                    paginationEndVal += 5;
                    
                
                   
                    double loopEndValue = 0;

                    if (paginationEndVal > totalAdds)
                    {
                        loopEndValue = totalAdds - orgPaginationEndValue;
                        if (loopEndValue == 0)
                        {
                            ServiceResponce serviceResponceError1 = new ServiceResponce
                            {
                                serviceErrorCode = 1,
                                html = "",
                                htmlPagination = returnPaginator.ToString()
                            };
                            string jsonStringError1 = serviceResponceError1.ToJSON();
                            return jsonStringError1;
                        }
                        loopEndValue = (loopStartValue + loopEndValue)-1;
                    }
                    else
                    {
                        loopEndValue = paginationEndVal;
                    }

                    returnPaginator.Append(@"<ul class='pager'> <li class='previous'>
                                                            <a class='previous' href='#'>&larr; Older</a>
                                            </li></ul>");
                    for (int i = loopStartValue; i <= loopEndValue; i++)
                    {
                        returnPaginator.AppendFormat(@"
                                          <ul>                           
                                            <li><a class='pg' href='#'>{0}</a></li>
                                                              
                                          </ul>
                                    ", Convert.ToString(i));

                    }

                    returnPaginator.Append(@" <ul class='pager'><li class='next'>
                                                            <a class='newer' href='#'>&larr; Newer</a>
                                            </li></ul>");


            }
            catch (Exception ex)
            {

            
            }

          
            ServiceResponce serviceResponceError = new ServiceResponce
            {
                serviceErrorCode = 0,
                html = "",
                htmlPagination = returnPaginator.ToString()
            };
            string jsonStringError = serviceResponceError.ToJSON();
            return jsonStringError;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string PreviousPaginator(string paginationStartValue)
        {
            StringBuilder previousPaginatorHtml = new StringBuilder();

            try
            {

                Ad1Collection ad = new Ad1Controller().FetchAll().OrderByAsc("AdDate");
                int totalAdds = ad.Count;

                int paginationStartVal = Convert.ToInt32(paginationStartValue);
                int loopStartValue = 0;

                if (paginationStartVal > 1)
                {
                    paginationStartVal -= 5;
                }
                else if (paginationStartVal == 1)
                {
                    ServiceResponce serviceResponceError1 = new ServiceResponce
                    {
                        serviceErrorCode = 1,
                        html = "",
                        htmlPagination = previousPaginatorHtml.ToString()
                    };
                    string jsonStringError1 = serviceResponceError1.ToJSON();
                    return jsonStringError1;
                }
                else
                {
                    loopStartValue = paginationStartVal;

                }
                
                loopStartValue = paginationStartVal;
                int loopEndValue = loopStartValue + 4;
                
             
                previousPaginatorHtml.Append(@"<ul class='pager'> <li class='previous'>
                                                            <a class='previous' href='#'>&larr; Older</a>
                                           </li></ul>");

                int count = loopStartValue;
                while (count <= loopEndValue)
                {
                    
                    previousPaginatorHtml.AppendFormat(@"
                                          <ul>                           
                                            <li><a class='pg' href='#'>{0}</a></li>
                                                              
                                          </ul>
                                    ", Convert.ToString(count));

                    count++;
                    
                }
                
                
                previousPaginatorHtml.Append(@" <ul class='pager'><li class='next'>
                                                            <a class='newer' href='#'>&larr; Newer</a>
                                            </li></ul>");



             
             

               

            }
            catch (Exception ex)
            {


            }  

            ServiceResponce serviceResponceError = new ServiceResponce
            {
                serviceErrorCode = 0,
                html = "",
                htmlPagination = previousPaginatorHtml.ToString()
            };
            string jsonStringError = serviceResponceError.ToJSON();
            return jsonStringError;


        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string PaginationHandler(string paginationVal)
        {

            StringBuilder sbReturnHtmlGallery = new StringBuilder();
            StringBuilder sbReturnHtml = new StringBuilder();

            
            string username = string.Empty;
            try
            {

                if (string.IsNullOrEmpty(paginationVal))
                {
                    paginationVal = "1";


                }


                int paginationCount = Convert.ToInt32(WebConfigurationManager.AppSettings["pagination"]);
                Ad1Controller adController = new Ad1Controller();
                Ad1Collection coll2 = adController.FetchAll();
                int totalCount = coll2.Count;
                Ad1Collection coll = adController.FetchPagination(paginationCount, Convert.ToInt32(paginationVal)).OrderByAsc("AdDate");


                foreach (Ad1 ad in coll)
                {
                    //if (countAdds == paginationCount)
                    //{
                    //    break;
                    //}
                    //countAdds += 1;


                    User user = new User("LoginId", ad.LoginId);
                    username = user.Username;
                    string[] arr = ad.AdPicture.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string image in arr)
                    {
                        sbReturnHtmlGallery.AppendFormat(@"
                                                   <a href='index.aspx?ctl=1&id={0}' class='show'>
                                                    <img src='../upload/AdImage/MainSlider/{1}' alt='Flowing Rock' width='950' height='450' title='' alt='' rel='<h3>{2}</h3>{3}/>
                                                   </a>
                                                   <div class='caption'><div class='content'></div></div>", ad.AdId, image, ad.AdTitle, ad.AdDetail.Length > 100 ? ad.AdDetail.Substring(0, 100) + " ..." : ad.AdDetail);
                    }



                    sbReturnHtml.AppendFormat(@" <div class='media infoDiv'  style='margin-top:19px;'>
                                                <a class='pull-left' href='../index.aspx?ctl=1&id={0}'>
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
                    //                    sbReturnHtml.AppendFormat(@" <div class='row materialContent'>
                    //                                       
                    //                                         
                    //                                            <div class='media infoDiv'  style='margin-top:19px;'>
                    //                                         <a class='pull-left' href='../index.aspx?ctl=1&id={0}'>
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
            catch (Exception ex)
            {


            }

            ServiceResponce serviceResponceError = new ServiceResponce
            {
                serviceErrorCode = 0,
                html = Convert.ToString(sbReturnHtml),
                htmlPagination = "",
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


                sbReturnPaginationHtml.Append(@"<ul class='pager'> <li class='previous'>
                                                            <a class='previous' href='#'>&larr; Older</a>
                                            </li></ul>");
                
                
                //for(int i = 0; i < totalPages; i++){
                if (totalPages > 5)
                {
                    totalPages = 5;
                }




                for (int i = 0; i < totalPages; i++)
                {
                    if (i + 1 == selectedPagination)
                    {
                        sbReturnPaginationHtml.AppendFormat(@"
                                      <ul>                           
                                        <li class='currentLi'><a class='pg' href='#'>{0}</a></li>
                                                              
                                      </ul>
                                ", Convert.ToString(i + 1));
                    }
                    else
                    {
                        sbReturnPaginationHtml.AppendFormat(@"
                                          <ul>                           
                                            <li><a class='pg' href='#'>{0}</a></li>
                                                              
                                          </ul>
                                    ", Convert.ToString(i + 1));
                    }
                }

                sbReturnPaginationHtml.Append(@" <ul class='pager'><li class='next'>
                                                            <a class='newer'href='#'>&larr; Newer</a>
                                            </ul></li>");
                    

            }

            return Convert.ToString(sbReturnPaginationHtml);
        }
      
    }
     

}

using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
using Advertisement.Model;

namespace Advertisement.Controller
{
    /// <summary>
    /// Controller class for tblAd
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AdController
    {
        // Preload our schema..
        Ad thisSchemaLoad = new Ad();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public AdCollection FetchAll()
        {
            AdCollection coll = new AdCollection();
            Query qry = new Query(Ad.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdCollection FetchByID(object AdId)
        {
            AdCollection coll = new AdCollection().Where("AdId", AdId).Load();
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdCollection FetchByLoginID(object LoginId)
        {
            AdCollection coll = new AdCollection().Where("LoginId", LoginId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AdCollection FetchByQuery(Query qry)
        {
            AdCollection coll = new AdCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object AdId)
        {
            return (Ad.Delete(AdId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object AdId)
        {
            return (Ad.Destroy(AdId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int LoginId,string AdTitle,string AdDetail,string AdAskingPrice,string AdPicture,string AdContactNo,string AdEmailAddress,string AdAddress,string AdStatus,string AdDate)
	    {
		    Ad item = new Ad();
		    
            item.LoginId = LoginId;
            
            item.AdTitle = AdTitle;
            
            item.AdDetail = AdDetail;
            
            item.AdAskingPrice = AdAskingPrice;
            
            item.AdPicture = AdPicture;
            
            item.AdContactNo = AdContactNo;
            
            item.AdEmailAddress = AdEmailAddress;
            
            item.AdAddress = AdAddress;
            
            item.AdStatus = AdStatus;
            
            item.AdDate = AdDate;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int AdId,int LoginId,string AdTitle,string AdDetail,string AdAskingPrice,string AdPicture,string AdContactNo,string AdEmailAddress,string AdAddress,string AdStatus,string AdDate)
	    {
		    Ad item = new Ad();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.AdId = AdId;
				
			item.LoginId = LoginId;
				
			item.AdTitle = AdTitle;
				
			item.AdDetail = AdDetail;
				
			item.AdAskingPrice = AdAskingPrice;
				
			item.AdPicture = AdPicture;
				
			item.AdContactNo = AdContactNo;
				
			item.AdEmailAddress = AdEmailAddress;
				
			item.AdAddress = AdAddress;
				
			item.AdStatus = AdStatus;
				
			item.AdDate = AdDate;
				
	        item.Save(UserName);
	    }

    }

}


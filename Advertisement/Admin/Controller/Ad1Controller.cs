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
    /// Controller class for tblAd1
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Ad1Controller
    {
        // Preload our schema..
        Ad1 thisSchemaLoad = new Ad1();
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
        public Ad1Collection FetchAll()
        {
            Ad1Collection coll = new Ad1Collection();
            Query qry = new Query(Ad1.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Ad1Collection FetchByDate(string columnName, DateTime dateStart, DateTime dateEnd, int sizePerPage, int pageIndex)
        {
            Ad1Collection coll = new Ad1Collection();
            Query qry = new Query(Ad1.Schema);
            qry = qry.AddBetweenAnd(columnName, dateStart, dateEnd);
            qry.PageSize = sizePerPage;
            qry.PageIndex = pageIndex;
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
                [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Ad1Collection FetchPagination(int paginationSize, int pageIndex)
        {
            Ad1Collection coll = new Ad1Collection();
           
            Query qry = new Query(Ad1.Schema);
            qry.OrderBy =OrderBy.Desc(Ad1.Columns.AdDate);
            qry.PageIndex = pageIndex;
            qry.PageSize = paginationSize;             
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Ad1Collection FetchByLoginID(object LoginId)
        {
            Ad1Collection coll = new Ad1Collection().Where("LoginId", LoginId).Load();
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Ad1Collection FetchByID(object AdId)
        {
            Ad1Collection coll = new Ad1Collection().Where("AdId", AdId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public Ad1Collection FetchByQuery(Query qry)
        {
            Ad1Collection coll = new Ad1Collection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object AdId)
        {
            return (Ad1.Delete(AdId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object AdId)
        {
            return (Ad1.Destroy(AdId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int LoginId,string AdTitle,string AdDetail,string AdAskingPrice,string AdPicture,string AdContactNo,string AdEmailAddress,string AdAddress,string AdStatus,DateTime AdDate)
	    {
		    Ad1 item = new Ad1();
		    
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
	    public void Update(int AdId,int LoginId,string AdTitle,string AdDetail,string AdAskingPrice,string AdPicture,string AdContactNo,string AdEmailAddress,string AdAddress,string AdStatus,DateTime AdDate)
	    {
		    Ad1 item = new Ad1();
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


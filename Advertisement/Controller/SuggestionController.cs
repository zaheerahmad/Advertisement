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

namespace Advertisement.Model
{
    /// <summary>
    /// Controller class for tblSuggestion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SuggestionController
    {
        // Preload our schema..
        Suggestion thisSchemaLoad = new Suggestion();
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
        public SuggestionCollection FetchAll()
        {
            SuggestionCollection coll = new SuggestionCollection();
            Query qry = new Query(Suggestion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SuggestionCollection FetchByID(object SuggestionId)
        {
            SuggestionCollection coll = new SuggestionCollection().Where("suggestionId", SuggestionId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SuggestionCollection FetchByQuery(Query qry)
        {
            SuggestionCollection coll = new SuggestionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SuggestionId)
        {
            return (Suggestion.Delete(SuggestionId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SuggestionId)
        {
            return (Suggestion.Destroy(SuggestionId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? AdverId,string SuggestionText)
	    {
		    Suggestion item = new Suggestion();
		    
            item.AdverId = AdverId;
            
            item.SuggestionText = SuggestionText;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int? AdverId,int SuggestionId,string SuggestionText)
	    {
		    Suggestion item = new Suggestion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.AdverId = AdverId;
				
			item.SuggestionId = SuggestionId;
				
			item.SuggestionText = SuggestionText;
				
	        item.Save(UserName);
	    }

    }

}


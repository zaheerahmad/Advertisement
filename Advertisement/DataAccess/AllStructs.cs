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

namespace Advertisement.DataAccess
{
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Ad = @"tblAds";
        
		public static string User = @"tblUsers";
        
	}

	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table Ad{
            get { return DataService.GetSchema("tblAds","csmDefaultDB"); }

		}

        
		public static TableSchema.Table User{
            get { return DataService.GetSchema("tblUsers","csmDefaultDB"); }

		}

        
	
    }

    #endregion
    #region View Struct
    public partial struct Views 
    {
		
    }

    #endregion
    
    #region Query Factories
	public static partial class DB
	{
	    public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
	        return SubSonic.Select.AllColumnsFrom<T>();
	    }

	        
	    public static Select Select()
	    {
	        return new Select(DataService.Providers["csmDefaultDB"]);
	    }

	    
		public static Select Select(params string[] columns)
		{
	        return new Select(DataService.Providers["csmDefaultDB"], columns);
	    }

	    
		public static Select Select(params Aggregate[] aggregates)
		{
	        return new Select(DataService.Providers["csmDefaultDB"], aggregates);
	    }

   
	    public static Update Update<T>() where T : ActiveRecord<T>, new()
	    {
	        return new SubSonic.Update(new T().GetSchema());
	    }
     
	    
	    public static Insert Insert()
	    {
	        Insert i=new Insert();
	        i.provider = DataService.Providers["csmDefaultDB"];
	        return i;
	    }

	    
	    public static Delete Delete()
	    {
	        return new Delete("csmDefaultDB");
	    }

	    
	    public static InlineQuery Query()
	    {
   	        return new InlineQuery("csmDefaultDB");
	    }

	    
	    
	}

    #endregion
    
}

#region Databases
public partial struct Databases 
{
	
	public static string csmDefaultDB = @"csmDefaultDB";
    
}

#endregion
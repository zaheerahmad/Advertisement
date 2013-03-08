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
	/// Strongly-typed collection for the Ad class.
	/// </summary>
///ssss
	[Serializable]
	public partial class AdCollection : ActiveList<Ad,AdCollection>
	{	   
		public AdCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the tblAds table.
	/// </summary>
	[Serializable]
	public partial class Ad : ActiveRecord<Ad>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Ad()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Ad(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

        
		public Ad(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Ad(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}

		
		protected static void SetSQLProps() { GetTableSchema(); }

		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }

		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}

		}

		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("tblAds", TableType.Table, DataService.GetInstance("csmDefaultDB"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAdId = new TableSchema.TableColumn(schema);
				colvarAdId.ColumnName = "AdId";
				colvarAdId.DataType = DbType.Int32;
				colvarAdId.MaxLength = 0;
				colvarAdId.AutoIncrement = false;
				colvarAdId.IsNullable = false;
				colvarAdId.IsPrimaryKey = true;
				colvarAdId.IsForeignKey = false;
				colvarAdId.IsReadOnly = false;
				colvarAdId.DefaultSetting = @"";
				colvarAdId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdId);
				
				TableSchema.TableColumn colvarLoginId = new TableSchema.TableColumn(schema);
				colvarLoginId.ColumnName = "LoginId";
				colvarLoginId.DataType = DbType.Int32;
				colvarLoginId.MaxLength = 0;
				colvarLoginId.AutoIncrement = false;
				colvarLoginId.IsNullable = false;
				colvarLoginId.IsPrimaryKey = false;
				colvarLoginId.IsForeignKey = false;
				colvarLoginId.IsReadOnly = false;
				colvarLoginId.DefaultSetting = @"";
				colvarLoginId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLoginId);
				
				TableSchema.TableColumn colvarAdTitle = new TableSchema.TableColumn(schema);
				colvarAdTitle.ColumnName = "AdTitle";
				colvarAdTitle.DataType = DbType.String;
				colvarAdTitle.MaxLength = 150;
				colvarAdTitle.AutoIncrement = false;
				colvarAdTitle.IsNullable = false;
				colvarAdTitle.IsPrimaryKey = false;
				colvarAdTitle.IsForeignKey = false;
				colvarAdTitle.IsReadOnly = false;
				colvarAdTitle.DefaultSetting = @"";
				colvarAdTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdTitle);
				
				TableSchema.TableColumn colvarAdDetail = new TableSchema.TableColumn(schema);
				colvarAdDetail.ColumnName = "AdDetail";
				colvarAdDetail.DataType = DbType.String;
				colvarAdDetail.MaxLength = 1500;
				colvarAdDetail.AutoIncrement = false;
				colvarAdDetail.IsNullable = false;
				colvarAdDetail.IsPrimaryKey = false;
				colvarAdDetail.IsForeignKey = false;
				colvarAdDetail.IsReadOnly = false;
				colvarAdDetail.DefaultSetting = @"";
				colvarAdDetail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdDetail);
				
				TableSchema.TableColumn colvarAdAskingPrice = new TableSchema.TableColumn(schema);
				colvarAdAskingPrice.ColumnName = "AdAskingPrice";
				colvarAdAskingPrice.DataType = DbType.String;
				colvarAdAskingPrice.MaxLength = 50;
				colvarAdAskingPrice.AutoIncrement = false;
				colvarAdAskingPrice.IsNullable = false;
				colvarAdAskingPrice.IsPrimaryKey = false;
				colvarAdAskingPrice.IsForeignKey = false;
				colvarAdAskingPrice.IsReadOnly = false;
				colvarAdAskingPrice.DefaultSetting = @"";
				colvarAdAskingPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdAskingPrice);
				
				TableSchema.TableColumn colvarAdPicture = new TableSchema.TableColumn(schema);
				colvarAdPicture.ColumnName = "AdPicture";
				colvarAdPicture.DataType = DbType.String;
				colvarAdPicture.MaxLength = 500;
				colvarAdPicture.AutoIncrement = false;
				colvarAdPicture.IsNullable = false;
				colvarAdPicture.IsPrimaryKey = false;
				colvarAdPicture.IsForeignKey = false;
				colvarAdPicture.IsReadOnly = false;
				colvarAdPicture.DefaultSetting = @"";
				colvarAdPicture.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdPicture);
				
				TableSchema.TableColumn colvarAdContactNo = new TableSchema.TableColumn(schema);
				colvarAdContactNo.ColumnName = "AdContactNo";
				colvarAdContactNo.DataType = DbType.String;
				colvarAdContactNo.MaxLength = 150;
				colvarAdContactNo.AutoIncrement = false;
				colvarAdContactNo.IsNullable = false;
				colvarAdContactNo.IsPrimaryKey = false;
				colvarAdContactNo.IsForeignKey = false;
				colvarAdContactNo.IsReadOnly = false;
				colvarAdContactNo.DefaultSetting = @"";
				colvarAdContactNo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdContactNo);
				
				TableSchema.TableColumn colvarAdEmailAddress = new TableSchema.TableColumn(schema);
				colvarAdEmailAddress.ColumnName = "AdEmailAddress";
				colvarAdEmailAddress.DataType = DbType.String;
				colvarAdEmailAddress.MaxLength = 150;
				colvarAdEmailAddress.AutoIncrement = false;
				colvarAdEmailAddress.IsNullable = false;
				colvarAdEmailAddress.IsPrimaryKey = false;
				colvarAdEmailAddress.IsForeignKey = false;
				colvarAdEmailAddress.IsReadOnly = false;
				colvarAdEmailAddress.DefaultSetting = @"";
				colvarAdEmailAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdEmailAddress);
				
				TableSchema.TableColumn colvarAdAddress = new TableSchema.TableColumn(schema);
				colvarAdAddress.ColumnName = "AdAddress";
				colvarAdAddress.DataType = DbType.String;
				colvarAdAddress.MaxLength = 1500;
				colvarAdAddress.AutoIncrement = false;
				colvarAdAddress.IsNullable = true;
				colvarAdAddress.IsPrimaryKey = false;
				colvarAdAddress.IsForeignKey = false;
				colvarAdAddress.IsReadOnly = false;
				colvarAdAddress.DefaultSetting = @"";
				colvarAdAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdAddress);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["csmDefaultDB"].AddSchema("tblAds",schema);
			}

		}

		#endregion
		
		#region Props
		  
		[XmlAttribute("AdId")]
		[Bindable(true)]
		public int AdId 
		{
			get { return GetColumnValue<int>(Columns.AdId); }

			set { SetColumnValue(Columns.AdId, value); }

		}

		  
		[XmlAttribute("LoginId")]
		[Bindable(true)]
		public int LoginId 
		{
			get { return GetColumnValue<int>(Columns.LoginId); }

			set { SetColumnValue(Columns.LoginId, value); }

		}

		  
		[XmlAttribute("AdTitle")]
		[Bindable(true)]
		public string AdTitle 
		{
			get { return GetColumnValue<string>(Columns.AdTitle); }

			set { SetColumnValue(Columns.AdTitle, value); }

		}

		  
		[XmlAttribute("AdDetail")]
		[Bindable(true)]
		public string AdDetail 
		{
			get { return GetColumnValue<string>(Columns.AdDetail); }

			set { SetColumnValue(Columns.AdDetail, value); }

		}

		  
		[XmlAttribute("AdAskingPrice")]
		[Bindable(true)]
		public string AdAskingPrice 
		{
			get { return GetColumnValue<string>(Columns.AdAskingPrice); }

			set { SetColumnValue(Columns.AdAskingPrice, value); }

		}

		  
		[XmlAttribute("AdPicture")]
		[Bindable(true)]
		public string AdPicture 
		{
			get { return GetColumnValue<string>(Columns.AdPicture); }

			set { SetColumnValue(Columns.AdPicture, value); }

		}

		  
		[XmlAttribute("AdContactNo")]
		[Bindable(true)]
		public string AdContactNo 
		{
			get { return GetColumnValue<string>(Columns.AdContactNo); }

			set { SetColumnValue(Columns.AdContactNo, value); }

		}

		  
		[XmlAttribute("AdEmailAddress")]
		[Bindable(true)]
		public string AdEmailAddress 
		{
			get { return GetColumnValue<string>(Columns.AdEmailAddress); }

			set { SetColumnValue(Columns.AdEmailAddress, value); }

		}

		  
		[XmlAttribute("AdAddress")]
		[Bindable(true)]
		public string AdAddress 
		{
			get { return GetColumnValue<string>(Columns.AdAddress); }

			set { SetColumnValue(Columns.AdAddress, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varAdId,int varLoginId,string varAdTitle,string varAdDetail,string varAdAskingPrice,string varAdPicture,string varAdContactNo,string varAdEmailAddress,string varAdAddress)
		{
			Ad item = new Ad();
			
			item.AdId = varAdId;
			
			item.LoginId = varLoginId;
			
			item.AdTitle = varAdTitle;
			
			item.AdDetail = varAdDetail;
			
			item.AdAskingPrice = varAdAskingPrice;
			
			item.AdPicture = varAdPicture;
			
			item.AdContactNo = varAdContactNo;
			
			item.AdEmailAddress = varAdEmailAddress;
			
			item.AdAddress = varAdAddress;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varAdId,int varLoginId,string varAdTitle,string varAdDetail,string varAdAskingPrice,string varAdPicture,string varAdContactNo,string varAdEmailAddress,string varAdAddress)
		{
			Ad item = new Ad();
			
				item.AdId = varAdId;
			
				item.LoginId = varLoginId;
			
				item.AdTitle = varAdTitle;
			
				item.AdDetail = varAdDetail;
			
				item.AdAskingPrice = varAdAskingPrice;
			
				item.AdPicture = varAdPicture;
			
				item.AdContactNo = varAdContactNo;
			
				item.AdEmailAddress = varAdEmailAddress;
			
				item.AdAddress = varAdAddress;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn AdIdColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn LoginIdColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn AdTitleColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn AdDetailColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn AdAskingPriceColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        public static TableSchema.TableColumn AdPictureColumn
        {
            get { return Schema.Columns[5]; }

        }

        
        
        
        public static TableSchema.TableColumn AdContactNoColumn
        {
            get { return Schema.Columns[6]; }

        }

        
        
        
        public static TableSchema.TableColumn AdEmailAddressColumn
        {
            get { return Schema.Columns[7]; }

        }

        
        
        
        public static TableSchema.TableColumn AdAddressColumn
        {
            get { return Schema.Columns[8]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string AdId = @"AdId";
			 public static string LoginId = @"LoginId";
			 public static string AdTitle = @"AdTitle";
			 public static string AdDetail = @"AdDetail";
			 public static string AdAskingPrice = @"AdAskingPrice";
			 public static string AdPicture = @"AdPicture";
			 public static string AdContactNo = @"AdContactNo";
			 public static string AdEmailAddress = @"AdEmailAddress";
			 public static string AdAddress = @"AdAddress";
						
		}

		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}

}


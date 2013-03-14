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
	/// Strongly-typed collection for the Suggestion class.
	/// </summary>
///ssss
	[Serializable]
	public partial class SuggestionCollection : ActiveList<Suggestion,SuggestionCollection>
	{	   
		public SuggestionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the tblSuggestion table.
	/// </summary>
	[Serializable]
	public partial class Suggestion : ActiveRecord<Suggestion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Suggestion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Suggestion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

        
		public Suggestion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Suggestion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblSuggestion", TableType.Table, DataService.GetInstance("csmDefaultDB"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAdverId = new TableSchema.TableColumn(schema);
				colvarAdverId.ColumnName = "adverId";
				colvarAdverId.DataType = DbType.Int32;
				colvarAdverId.MaxLength = 0;
				colvarAdverId.AutoIncrement = false;
				colvarAdverId.IsNullable = true;
				colvarAdverId.IsPrimaryKey = false;
				colvarAdverId.IsForeignKey = false;
				colvarAdverId.IsReadOnly = false;
				colvarAdverId.DefaultSetting = @"";
				colvarAdverId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdverId);
				
				TableSchema.TableColumn colvarSuggestionId = new TableSchema.TableColumn(schema);
				colvarSuggestionId.ColumnName = "suggestionId";
				colvarSuggestionId.DataType = DbType.Int32;
				colvarSuggestionId.MaxLength = 0;
				colvarSuggestionId.AutoIncrement = true;
				colvarSuggestionId.IsNullable = false;
				colvarSuggestionId.IsPrimaryKey = true;
				colvarSuggestionId.IsForeignKey = false;
				colvarSuggestionId.IsReadOnly = false;
				colvarSuggestionId.DefaultSetting = @"";
				colvarSuggestionId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSuggestionId);
				
				TableSchema.TableColumn colvarSuggestionText = new TableSchema.TableColumn(schema);
				colvarSuggestionText.ColumnName = "suggestionText";
				colvarSuggestionText.DataType = DbType.String;
				colvarSuggestionText.MaxLength = 500;
				colvarSuggestionText.AutoIncrement = false;
				colvarSuggestionText.IsNullable = true;
				colvarSuggestionText.IsPrimaryKey = false;
				colvarSuggestionText.IsForeignKey = false;
				colvarSuggestionText.IsReadOnly = false;
				colvarSuggestionText.DefaultSetting = @"";
				colvarSuggestionText.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSuggestionText);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["csmDefaultDB"].AddSchema("tblSuggestion",schema);
			}

		}

		#endregion
		
		#region Props
		  
		[XmlAttribute("AdverId")]
		[Bindable(true)]
		public int? AdverId 
		{
			get { return GetColumnValue<int?>(Columns.AdverId); }

			set { SetColumnValue(Columns.AdverId, value); }

		}

		  
		[XmlAttribute("SuggestionId")]
		[Bindable(true)]
		public int SuggestionId 
		{
			get { return GetColumnValue<int>(Columns.SuggestionId); }

			set { SetColumnValue(Columns.SuggestionId, value); }

		}

		  
		[XmlAttribute("SuggestionText")]
		[Bindable(true)]
		public string SuggestionText 
		{
			get { return GetColumnValue<string>(Columns.SuggestionText); }

			set { SetColumnValue(Columns.SuggestionText, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varAdverId,string varSuggestionText)
		{
			Suggestion item = new Suggestion();
			
			item.AdverId = varAdverId;
			
			item.SuggestionText = varSuggestionText;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int? varAdverId,int varSuggestionId,string varSuggestionText)
		{
			Suggestion item = new Suggestion();
			
				item.AdverId = varAdverId;
			
				item.SuggestionId = varSuggestionId;
			
				item.SuggestionText = varSuggestionText;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn AdverIdColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn SuggestionIdColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn SuggestionTextColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string AdverId = @"adverId";
			 public static string SuggestionId = @"suggestionId";
			 public static string SuggestionText = @"suggestionText";
						
		}

		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}

}


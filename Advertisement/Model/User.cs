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
	/// Strongly-typed collection for the User class.
	/// </summary>
///ssss
	[Serializable]
	public partial class UserCollection : ActiveList<User,UserCollection>
	{	   
		public UserCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the tblUsers table.
	/// </summary>
	[Serializable]
	public partial class User : ActiveRecord<User>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public User()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public User(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

        
		public User(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public User(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tblUsers", TableType.Table, DataService.GetInstance("csmDefaultDB"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarLoginId = new TableSchema.TableColumn(schema);
				colvarLoginId.ColumnName = "loginId";
				colvarLoginId.DataType = DbType.Int32;
				colvarLoginId.MaxLength = 0;
				colvarLoginId.AutoIncrement = true;
				colvarLoginId.IsNullable = false;
				colvarLoginId.IsPrimaryKey = true;
				colvarLoginId.IsForeignKey = false;
				colvarLoginId.IsReadOnly = false;
				colvarLoginId.DefaultSetting = @"";
				colvarLoginId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLoginId);
				
				TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(schema);
				colvarUsername.ColumnName = "username";
				colvarUsername.DataType = DbType.String;
				colvarUsername.MaxLength = 150;
				colvarUsername.AutoIncrement = false;
				colvarUsername.IsNullable = false;
				colvarUsername.IsPrimaryKey = false;
				colvarUsername.IsForeignKey = false;
				colvarUsername.IsReadOnly = false;
				colvarUsername.DefaultSetting = @"";
				colvarUsername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsername);
				
				TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(schema);
				colvarPassword.ColumnName = "password";
				colvarPassword.DataType = DbType.String;
				colvarPassword.MaxLength = 150;
				colvarPassword.AutoIncrement = false;
				colvarPassword.IsNullable = false;
				colvarPassword.IsPrimaryKey = false;
				colvarPassword.IsForeignKey = false;
				colvarPassword.IsReadOnly = false;
				colvarPassword.DefaultSetting = @"";
				colvarPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPassword);
				
				TableSchema.TableColumn colvarFName = new TableSchema.TableColumn(schema);
				colvarFName.ColumnName = "fName";
				colvarFName.DataType = DbType.String;
				colvarFName.MaxLength = 250;
				colvarFName.AutoIncrement = false;
				colvarFName.IsNullable = false;
				colvarFName.IsPrimaryKey = false;
				colvarFName.IsForeignKey = false;
				colvarFName.IsReadOnly = false;
				colvarFName.DefaultSetting = @"";
				colvarFName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFName);
				
				TableSchema.TableColumn colvarRole = new TableSchema.TableColumn(schema);
				colvarRole.ColumnName = "role";
				colvarRole.DataType = DbType.String;
				colvarRole.MaxLength = 150;
				colvarRole.AutoIncrement = false;
				colvarRole.IsNullable = false;
				colvarRole.IsPrimaryKey = false;
				colvarRole.IsForeignKey = false;
				colvarRole.IsReadOnly = false;
				colvarRole.DefaultSetting = @"";
				colvarRole.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRole);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["csmDefaultDB"].AddSchema("tblUsers",schema);
			}

		}

		#endregion
		
		#region Props
		  
		[XmlAttribute("LoginId")]
		[Bindable(true)]
		public int LoginId 
		{
			get { return GetColumnValue<int>(Columns.LoginId); }

			set { SetColumnValue(Columns.LoginId, value); }

		}

		  
		[XmlAttribute("Username")]
		[Bindable(true)]
		public string Username 
		{
			get { return GetColumnValue<string>(Columns.Username); }

			set { SetColumnValue(Columns.Username, value); }

		}

		  
		[XmlAttribute("Password")]
		[Bindable(true)]
		public string Password 
		{
			get { return GetColumnValue<string>(Columns.Password); }

			set { SetColumnValue(Columns.Password, value); }

		}

		  
		[XmlAttribute("FName")]
		[Bindable(true)]
		public string FName 
		{
			get { return GetColumnValue<string>(Columns.FName); }

			set { SetColumnValue(Columns.FName, value); }

		}

		  
		[XmlAttribute("Role")]
		[Bindable(true)]
		public string Role 
		{
			get { return GetColumnValue<string>(Columns.Role); }

			set { SetColumnValue(Columns.Role, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUsername,string varPassword,string varFName,string varRole)
		{
			User item = new User();
			
			item.Username = varUsername;
			
			item.Password = varPassword;
			
			item.FName = varFName;
			
			item.Role = varRole;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varLoginId,string varUsername,string varPassword,string varFName,string varRole)
		{
			User item = new User();
			
				item.LoginId = varLoginId;
			
				item.Username = varUsername;
			
				item.Password = varPassword;
			
				item.FName = varFName;
			
				item.Role = varRole;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn LoginIdColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn UsernameColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn PasswordColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn FNameColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn RoleColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string LoginId = @"loginId";
			 public static string Username = @"username";
			 public static string Password = @"password";
			 public static string FName = @"fName";
			 public static string Role = @"role";
						
		}

		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}

}


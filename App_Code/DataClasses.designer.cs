﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="bubblr")]
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void Insertpost(post instance);
  partial void Updatepost(post instance);
  partial void Deletepost(post instance);
  partial void Insertuser(user instance);
  partial void Updateuser(user instance);
  partial void Deleteuser(user instance);
  #endregion
	
	public DataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["bubblrConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<post> posts
	{
		get
		{
			return this.GetTable<post>();
		}
	}
	
	public System.Data.Linq.Table<user> users
	{
		get
		{
			return this.GetTable<user>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="test3.post")]
public partial class post : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _Picture;
	
	private string _Title;
	
	private string _ShortDesc;
	
	private string _ContDesc;
	
	private System.Nullable<System.DateTime> _CreatedDate;
	
	private System.Nullable<int> _UserId;
	
	private System.Nullable<int> _Status;
	
	private EntityRef<user> _user;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPictureChanging(string value);
    partial void OnPictureChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnShortDescChanging(string value);
    partial void OnShortDescChanged();
    partial void OnContDescChanging(string value);
    partial void OnContDescChanged();
    partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedDateChanged();
    partial void OnUserIdChanging(System.Nullable<int> value);
    partial void OnUserIdChanged();
    partial void OnStatusChanging(System.Nullable<int> value);
    partial void OnStatusChanged();
    #endregion
	
	public post()
	{
		this._user = default(EntityRef<user>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Picture", DbType="NVarChar(50)")]
	public string Picture
	{
		get
		{
			return this._Picture;
		}
		set
		{
			if ((this._Picture != value))
			{
				this.OnPictureChanging(value);
				this.SendPropertyChanging();
				this._Picture = value;
				this.SendPropertyChanged("Picture");
				this.OnPictureChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(50)")]
	public string Title
	{
		get
		{
			return this._Title;
		}
		set
		{
			if ((this._Title != value))
			{
				this.OnTitleChanging(value);
				this.SendPropertyChanging();
				this._Title = value;
				this.SendPropertyChanged("Title");
				this.OnTitleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShortDesc", DbType="NVarChar(50)")]
	public string ShortDesc
	{
		get
		{
			return this._ShortDesc;
		}
		set
		{
			if ((this._ShortDesc != value))
			{
				this.OnShortDescChanging(value);
				this.SendPropertyChanging();
				this._ShortDesc = value;
				this.SendPropertyChanged("ShortDesc");
				this.OnShortDescChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContDesc", DbType="NVarChar(MAX)")]
	public string ContDesc
	{
		get
		{
			return this._ContDesc;
		}
		set
		{
			if ((this._ContDesc != value))
			{
				this.OnContDescChanging(value);
				this.SendPropertyChanging();
				this._ContDesc = value;
				this.SendPropertyChanged("ContDesc");
				this.OnContDescChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime")]
	public System.Nullable<System.DateTime> CreatedDate
	{
		get
		{
			return this._CreatedDate;
		}
		set
		{
			if ((this._CreatedDate != value))
			{
				this.OnCreatedDateChanging(value);
				this.SendPropertyChanging();
				this._CreatedDate = value;
				this.SendPropertyChanged("CreatedDate");
				this.OnCreatedDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int")]
	public System.Nullable<int> UserId
	{
		get
		{
			return this._UserId;
		}
		set
		{
			if ((this._UserId != value))
			{
				if (this._user.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIdChanging(value);
				this.SendPropertyChanging();
				this._UserId = value;
				this.SendPropertyChanged("UserId");
				this.OnUserIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
	public System.Nullable<int> Status
	{
		get
		{
			return this._Status;
		}
		set
		{
			if ((this._Status != value))
			{
				this.OnStatusChanging(value);
				this.SendPropertyChanging();
				this._Status = value;
				this.SendPropertyChanged("Status");
				this.OnStatusChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_post", Storage="_user", ThisKey="UserId", OtherKey="Id", IsForeignKey=true)]
	public user user
	{
		get
		{
			return this._user.Entity;
		}
		set
		{
			user previousValue = this._user.Entity;
			if (((previousValue != value) 
						|| (this._user.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._user.Entity = null;
					previousValue.posts.Remove(this);
				}
				this._user.Entity = value;
				if ((value != null))
				{
					value.posts.Add(this);
					this._UserId = value.Id;
				}
				else
				{
					this._UserId = default(Nullable<int>);
				}
				this.SendPropertyChanged("user");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="test3.[user]")]
public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _Name;
	
	private string _City;
	
	private System.Nullable<int> _BirthYear;
	
	private string _Email;
	
	private string _Password;
	
	private System.Nullable<System.DateTime> _CreatedDate;
	
	private System.Nullable<int> _Status;
	
	private EntitySet<post> _posts;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnCityChanging(string value);
    partial void OnCityChanged();
    partial void OnBirthYearChanging(System.Nullable<int> value);
    partial void OnBirthYearChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedDateChanged();
    partial void OnStatusChanging(System.Nullable<int> value);
    partial void OnStatusChanged();
    #endregion
	
	public user()
	{
		this._posts = new EntitySet<post>(new Action<post>(this.attach_posts), new Action<post>(this.detach_posts));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="NVarChar(50)")]
	public string City
	{
		get
		{
			return this._City;
		}
		set
		{
			if ((this._City != value))
			{
				this.OnCityChanging(value);
				this.SendPropertyChanging();
				this._City = value;
				this.SendPropertyChanged("City");
				this.OnCityChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BirthYear", DbType="Int")]
	public System.Nullable<int> BirthYear
	{
		get
		{
			return this._BirthYear;
		}
		set
		{
			if ((this._BirthYear != value))
			{
				this.OnBirthYearChanging(value);
				this.SendPropertyChanging();
				this._BirthYear = value;
				this.SendPropertyChanged("BirthYear");
				this.OnBirthYearChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50)")]
	public string Email
	{
		get
		{
			return this._Email;
		}
		set
		{
			if ((this._Email != value))
			{
				this.OnEmailChanging(value);
				this.SendPropertyChanging();
				this._Email = value;
				this.SendPropertyChanged("Email");
				this.OnEmailChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50)")]
	public string Password
	{
		get
		{
			return this._Password;
		}
		set
		{
			if ((this._Password != value))
			{
				this.OnPasswordChanging(value);
				this.SendPropertyChanging();
				this._Password = value;
				this.SendPropertyChanged("Password");
				this.OnPasswordChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime")]
	public System.Nullable<System.DateTime> CreatedDate
	{
		get
		{
			return this._CreatedDate;
		}
		set
		{
			if ((this._CreatedDate != value))
			{
				this.OnCreatedDateChanging(value);
				this.SendPropertyChanging();
				this._CreatedDate = value;
				this.SendPropertyChanged("CreatedDate");
				this.OnCreatedDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
	public System.Nullable<int> Status
	{
		get
		{
			return this._Status;
		}
		set
		{
			if ((this._Status != value))
			{
				this.OnStatusChanging(value);
				this.SendPropertyChanging();
				this._Status = value;
				this.SendPropertyChanged("Status");
				this.OnStatusChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_post", Storage="_posts", ThisKey="Id", OtherKey="UserId")]
	public EntitySet<post> posts
	{
		get
		{
			return this._posts;
		}
		set
		{
			this._posts.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_posts(post entity)
	{
		this.SendPropertyChanging();
		entity.user = this;
	}
	
	private void detach_posts(post entity)
	{
		this.SendPropertyChanging();
		entity.user = null;
	}
}
#pragma warning restore 1591

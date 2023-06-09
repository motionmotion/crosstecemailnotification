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

namespace MotionMotion.Crosstec.EmailNotification
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="WebERPEmail")]
	public partial class SQLWebERPDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public SQLWebERPDataContext() : 
				base(global::MotionMotion.Crosstec.EmailNotification.Properties.Settings.Default.WebERPEmailConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SQLWebERPDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLWebERPDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLWebERPDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLWebERPDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ct_project> ct_projects
		{
			get
			{
				return this.GetTable<ct_project>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ct_project")]
	public partial class ct_project
	{
		
		private string _proj_no;
		
		private string _brand_code;
		
		private string _country_code;
		
		private string _location_code;
		
		private string _yearend;
		
		private string _runningno;
		
		private string _description;
		
		private string _company;
		
		private string _address;
		
		private string _address2;
		
		private string _address3;
		
		private string _address4;
		
		private string _phone1;
		
		private string _phone2;
		
		private string _e_mail;
		
		private string _contact1;
		
		private string _contact2;
		
		private string _payterm;
		
		private string _currency;
		
		private System.Nullable<decimal> _mark_up;
		
		private string _remark1;
		
		private string _remark2;
		
		private string _quot_remark;
		
		private string _requested;
		
		private System.Nullable<System.DateTime> _created_dt;
		
		private System.Nullable<System.DateTime> _updated_dt;
		
		private string _updated;
		
		private string _category;
		
		private System.Nullable<int> _CAT_DC;
		
		private System.Nullable<int> _CAT_FH;
		
		private System.Nullable<int> _CAT_FO;
		
		private System.Nullable<int> _CAT_FS;
		
		private System.Nullable<int> _CAT_MA;
		
		private System.Nullable<int> _CAT_MF;
		
		private System.Nullable<System.DateTime> _start_dt;
		
		private System.Nullable<System.DateTime> _end_dt;
		
		private string _PM_ID;
		
		private string _status;
		
		private string _acc_status;
		
		private string _quot_no;
		
		private string _quot_no2;
		
		private System.Nullable<decimal> _quot_amt;
		
		private System.Nullable<decimal> _proj_cost;
		
		private System.Nullable<decimal> _mat_cost;
		
		private System.Nullable<decimal> _subcon_cost;
		
		private System.Nullable<decimal> _logistic_cost;
		
		private System.Nullable<decimal> _insurance_cost;
		
		private System.Nullable<decimal> _outgoing_cost;
		
		private System.Nullable<int> _costlock;
		
		private System.Nullable<int> _term1;
		
		private System.Nullable<int> _term2;
		
		private System.Nullable<int> _term3;
		
		private System.Nullable<int> _term4;
		
		private System.Nullable<System.DateTime> _remind1;
		
		private System.Nullable<System.DateTime> _remind2;
		
		private System.Nullable<System.DateTime> _remind3;
		
		private System.Nullable<System.DateTime> _remind4;
		
		private System.Nullable<System.DateTime> _confirm_dt;
		
		private string _work_nature;
		
		private System.Nullable<System.DateTime> _schedule_dt;
		
		private string _work_staff;
		
		private string _shop;
		
		private System.Data.Linq.Binary _work_pic;
		
		private System.Nullable<System.DateTime> _lock_dt;
		
		private System.Nullable<int> _calert;
		
		private System.Nullable<decimal> _quot_adj;
		
		private string _PM2_ID;
		
		private string _vo_proj_no;
		
		public ct_project()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_proj_no", DbType="NVarChar(20)")]
		public string proj_no
		{
			get
			{
				return this._proj_no;
			}
			set
			{
				if ((this._proj_no != value))
				{
					this._proj_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_brand_code", DbType="NVarChar(3)")]
		public string brand_code
		{
			get
			{
				return this._brand_code;
			}
			set
			{
				if ((this._brand_code != value))
				{
					this._brand_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_country_code", DbType="NVarChar(2)")]
		public string country_code
		{
			get
			{
				return this._country_code;
			}
			set
			{
				if ((this._country_code != value))
				{
					this._country_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_location_code", DbType="NVarChar(4)")]
		public string location_code
		{
			get
			{
				return this._location_code;
			}
			set
			{
				if ((this._location_code != value))
				{
					this._location_code = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_yearend", DbType="NVarChar(2)")]
		public string yearend
		{
			get
			{
				return this._yearend;
			}
			set
			{
				if ((this._yearend != value))
				{
					this._yearend = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_runningno", DbType="NVarChar(4)")]
		public string runningno
		{
			get
			{
				return this._runningno;
			}
			set
			{
				if ((this._runningno != value))
				{
					this._runningno = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(150)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this._description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_company", DbType="NVarChar(254)")]
		public string company
		{
			get
			{
				return this._company;
			}
			set
			{
				if ((this._company != value))
				{
					this._company = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(254)")]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this._address = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address2", DbType="NVarChar(254)")]
		public string address2
		{
			get
			{
				return this._address2;
			}
			set
			{
				if ((this._address2 != value))
				{
					this._address2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address3", DbType="NVarChar(254)")]
		public string address3
		{
			get
			{
				return this._address3;
			}
			set
			{
				if ((this._address3 != value))
				{
					this._address3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address4", DbType="NVarChar(254)")]
		public string address4
		{
			get
			{
				return this._address4;
			}
			set
			{
				if ((this._address4 != value))
				{
					this._address4 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone1", DbType="NVarChar(20)")]
		public string phone1
		{
			get
			{
				return this._phone1;
			}
			set
			{
				if ((this._phone1 != value))
				{
					this._phone1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone2", DbType="NVarChar(20)")]
		public string phone2
		{
			get
			{
				return this._phone2;
			}
			set
			{
				if ((this._phone2 != value))
				{
					this._phone2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_e_mail", DbType="NVarChar(60)")]
		public string e_mail
		{
			get
			{
				return this._e_mail;
			}
			set
			{
				if ((this._e_mail != value))
				{
					this._e_mail = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contact1", DbType="NVarChar(50)")]
		public string contact1
		{
			get
			{
				return this._contact1;
			}
			set
			{
				if ((this._contact1 != value))
				{
					this._contact1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contact2", DbType="NVarChar(50)")]
		public string contact2
		{
			get
			{
				return this._contact2;
			}
			set
			{
				if ((this._contact2 != value))
				{
					this._contact2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_payterm", DbType="NVarChar(30)")]
		public string payterm
		{
			get
			{
				return this._payterm;
			}
			set
			{
				if ((this._payterm != value))
				{
					this._payterm = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_currency", DbType="NVarChar(3)")]
		public string currency
		{
			get
			{
				return this._currency;
			}
			set
			{
				if ((this._currency != value))
				{
					this._currency = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mark_up", DbType="Decimal(6,3)")]
		public System.Nullable<decimal> mark_up
		{
			get
			{
				return this._mark_up;
			}
			set
			{
				if ((this._mark_up != value))
				{
					this._mark_up = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_remark1", DbType="NVarChar(MAX)")]
		public string remark1
		{
			get
			{
				return this._remark1;
			}
			set
			{
				if ((this._remark1 != value))
				{
					this._remark1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_remark2", DbType="NVarChar(MAX)")]
		public string remark2
		{
			get
			{
				return this._remark2;
			}
			set
			{
				if ((this._remark2 != value))
				{
					this._remark2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quot_remark", DbType="NVarChar(MAX)")]
		public string quot_remark
		{
			get
			{
				return this._quot_remark;
			}
			set
			{
				if ((this._quot_remark != value))
				{
					this._quot_remark = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_requested", DbType="NVarChar(20)")]
		public string requested
		{
			get
			{
				return this._requested;
			}
			set
			{
				if ((this._requested != value))
				{
					this._requested = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> created_dt
		{
			get
			{
				return this._created_dt;
			}
			set
			{
				if ((this._created_dt != value))
				{
					this._created_dt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> updated_dt
		{
			get
			{
				return this._updated_dt;
			}
			set
			{
				if ((this._updated_dt != value))
				{
					this._updated_dt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_updated", DbType="NVarChar(20)")]
		public string updated
		{
			get
			{
				return this._updated;
			}
			set
			{
				if ((this._updated != value))
				{
					this._updated = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category", DbType="NVarChar(30)")]
		public string category
		{
			get
			{
				return this._category;
			}
			set
			{
				if ((this._category != value))
				{
					this._category = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CAT_DC", DbType="Int")]
		public System.Nullable<int> CAT_DC
		{
			get
			{
				return this._CAT_DC;
			}
			set
			{
				if ((this._CAT_DC != value))
				{
					this._CAT_DC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CAT_FH", DbType="Int")]
		public System.Nullable<int> CAT_FH
		{
			get
			{
				return this._CAT_FH;
			}
			set
			{
				if ((this._CAT_FH != value))
				{
					this._CAT_FH = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CAT_FO", DbType="Int")]
		public System.Nullable<int> CAT_FO
		{
			get
			{
				return this._CAT_FO;
			}
			set
			{
				if ((this._CAT_FO != value))
				{
					this._CAT_FO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CAT_FS", DbType="Int")]
		public System.Nullable<int> CAT_FS
		{
			get
			{
				return this._CAT_FS;
			}
			set
			{
				if ((this._CAT_FS != value))
				{
					this._CAT_FS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CAT_MA", DbType="Int")]
		public System.Nullable<int> CAT_MA
		{
			get
			{
				return this._CAT_MA;
			}
			set
			{
				if ((this._CAT_MA != value))
				{
					this._CAT_MA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CAT_MF", DbType="Int")]
		public System.Nullable<int> CAT_MF
		{
			get
			{
				return this._CAT_MF;
			}
			set
			{
				if ((this._CAT_MF != value))
				{
					this._CAT_MF = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_start_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> start_dt
		{
			get
			{
				return this._start_dt;
			}
			set
			{
				if ((this._start_dt != value))
				{
					this._start_dt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_end_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> end_dt
		{
			get
			{
				return this._end_dt;
			}
			set
			{
				if ((this._end_dt != value))
				{
					this._end_dt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PM_ID", DbType="NVarChar(4)")]
		public string PM_ID
		{
			get
			{
				return this._PM_ID;
			}
			set
			{
				if ((this._PM_ID != value))
				{
					this._PM_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="NVarChar(15)")]
		public string status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this._status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_acc_status", DbType="NVarChar(15)")]
		public string acc_status
		{
			get
			{
				return this._acc_status;
			}
			set
			{
				if ((this._acc_status != value))
				{
					this._acc_status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quot_no", DbType="NVarChar(50)")]
		public string quot_no
		{
			get
			{
				return this._quot_no;
			}
			set
			{
				if ((this._quot_no != value))
				{
					this._quot_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quot_no2", DbType="NVarChar(50)")]
		public string quot_no2
		{
			get
			{
				return this._quot_no2;
			}
			set
			{
				if ((this._quot_no2 != value))
				{
					this._quot_no2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quot_amt", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> quot_amt
		{
			get
			{
				return this._quot_amt;
			}
			set
			{
				if ((this._quot_amt != value))
				{
					this._quot_amt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_proj_cost", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> proj_cost
		{
			get
			{
				return this._proj_cost;
			}
			set
			{
				if ((this._proj_cost != value))
				{
					this._proj_cost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mat_cost", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> mat_cost
		{
			get
			{
				return this._mat_cost;
			}
			set
			{
				if ((this._mat_cost != value))
				{
					this._mat_cost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_subcon_cost", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> subcon_cost
		{
			get
			{
				return this._subcon_cost;
			}
			set
			{
				if ((this._subcon_cost != value))
				{
					this._subcon_cost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logistic_cost", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> logistic_cost
		{
			get
			{
				return this._logistic_cost;
			}
			set
			{
				if ((this._logistic_cost != value))
				{
					this._logistic_cost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_insurance_cost", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> insurance_cost
		{
			get
			{
				return this._insurance_cost;
			}
			set
			{
				if ((this._insurance_cost != value))
				{
					this._insurance_cost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_outgoing_cost", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> outgoing_cost
		{
			get
			{
				return this._outgoing_cost;
			}
			set
			{
				if ((this._outgoing_cost != value))
				{
					this._outgoing_cost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_costlock", DbType="Int")]
		public System.Nullable<int> costlock
		{
			get
			{
				return this._costlock;
			}
			set
			{
				if ((this._costlock != value))
				{
					this._costlock = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_term1", DbType="Int")]
		public System.Nullable<int> term1
		{
			get
			{
				return this._term1;
			}
			set
			{
				if ((this._term1 != value))
				{
					this._term1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_term2", DbType="Int")]
		public System.Nullable<int> term2
		{
			get
			{
				return this._term2;
			}
			set
			{
				if ((this._term2 != value))
				{
					this._term2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_term3", DbType="Int")]
		public System.Nullable<int> term3
		{
			get
			{
				return this._term3;
			}
			set
			{
				if ((this._term3 != value))
				{
					this._term3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_term4", DbType="Int")]
		public System.Nullable<int> term4
		{
			get
			{
				return this._term4;
			}
			set
			{
				if ((this._term4 != value))
				{
					this._term4 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_remind1", DbType="DateTime")]
		public System.Nullable<System.DateTime> remind1
		{
			get
			{
				return this._remind1;
			}
			set
			{
				if ((this._remind1 != value))
				{
					this._remind1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_remind2", DbType="DateTime")]
		public System.Nullable<System.DateTime> remind2
		{
			get
			{
				return this._remind2;
			}
			set
			{
				if ((this._remind2 != value))
				{
					this._remind2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_remind3", DbType="DateTime")]
		public System.Nullable<System.DateTime> remind3
		{
			get
			{
				return this._remind3;
			}
			set
			{
				if ((this._remind3 != value))
				{
					this._remind3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_remind4", DbType="DateTime")]
		public System.Nullable<System.DateTime> remind4
		{
			get
			{
				return this._remind4;
			}
			set
			{
				if ((this._remind4 != value))
				{
					this._remind4 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_confirm_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> confirm_dt
		{
			get
			{
				return this._confirm_dt;
			}
			set
			{
				if ((this._confirm_dt != value))
				{
					this._confirm_dt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_work_nature", DbType="NVarChar(100)")]
		public string work_nature
		{
			get
			{
				return this._work_nature;
			}
			set
			{
				if ((this._work_nature != value))
				{
					this._work_nature = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_schedule_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> schedule_dt
		{
			get
			{
				return this._schedule_dt;
			}
			set
			{
				if ((this._schedule_dt != value))
				{
					this._schedule_dt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_work_staff", DbType="NVarChar(100)")]
		public string work_staff
		{
			get
			{
				return this._work_staff;
			}
			set
			{
				if ((this._work_staff != value))
				{
					this._work_staff = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shop", DbType="NVarChar(100)")]
		public string shop
		{
			get
			{
				return this._shop;
			}
			set
			{
				if ((this._shop != value))
				{
					this._shop = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_work_pic", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary work_pic
		{
			get
			{
				return this._work_pic;
			}
			set
			{
				if ((this._work_pic != value))
				{
					this._work_pic = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lock_dt", DbType="DateTime")]
		public System.Nullable<System.DateTime> lock_dt
		{
			get
			{
				return this._lock_dt;
			}
			set
			{
				if ((this._lock_dt != value))
				{
					this._lock_dt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_calert", DbType="Int")]
		public System.Nullable<int> calert
		{
			get
			{
				return this._calert;
			}
			set
			{
				if ((this._calert != value))
				{
					this._calert = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quot_adj", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> quot_adj
		{
			get
			{
				return this._quot_adj;
			}
			set
			{
				if ((this._quot_adj != value))
				{
					this._quot_adj = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PM2_ID", DbType="NVarChar(4)")]
		public string PM2_ID
		{
			get
			{
				return this._PM2_ID;
			}
			set
			{
				if ((this._PM2_ID != value))
				{
					this._PM2_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vo_proj_no", DbType="NVarChar(20)")]
		public string vo_proj_no
		{
			get
			{
				return this._vo_proj_no;
			}
			set
			{
				if ((this._vo_proj_no != value))
				{
					this._vo_proj_no = value;
				}
			}
		}
	}
}
#pragma warning restore 1591

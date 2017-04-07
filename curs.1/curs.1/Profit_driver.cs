﻿//using System.Data.Linq;
//using System.Data.Linq.Mapping;
//using System;

//namespace curs._1
//{
//    [Table(Name = "dbo.Profit_driver")]
//    public partial class Profit_driver 
//    {

        
//        private int _id_profit_driver;

//        private int _id_driver;

//        private int _id_order;

//        private DateTime _date;

//        private int _value;

//        private EntityRef<Order> _Order;

        

//        public Profit_driver()
//        {
//            this._Order = default(EntityRef<Order>);
//        }

//        [Column(Storage = "_id_profit_driver", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
//        public int id_profit_driver
//        {
//            get
//            {
//                return this._id_profit_driver;
//            }
//            set
//            {
//                if ((this._id_profit_driver != value))
//                {
//                    this._id_profit_driver = value;
//                }
//            }
//        }

//        [Column(Storage = "_id_driver", DbType = "Int NOT NULL")]
//        public int id_driver
//        {
//            get
//            {
//                return this._id_driver;
//            }
//            set
//            {
//                if ((this._id_driver != value))
//                {
//                    this._id_driver = value;
//                }
//            }
//        }

//        [Column(Storage = "_id_order", DbType = "Int NOT NULL")]
//        public int id_order
//        {
//            get
//            {
//                return this._id_order;
//            }
//            set
//            {
//                if ((this._id_order != value))
//                {
//                    if (this._Order.HasLoadedOrAssignedValue)
//                    {
//                        throw new ForeignKeyReferenceAlreadyHasValueException();
//                    }
//                    this._id_order = value;
//                }
//            }
//        }

//        [Column(Storage = "_date", DbType = "DateTime NOT NULL")]
//        public DateTime date
//        {
//            get
//            {
//                return this._date;
//            }
//            set
//            {
//                if ((this._date != value))
//                {
//                    this._date = value;
//                }
//            }
//        }

//        [Column(Storage = "_value", DbType = "Int NOT NULL")]
//        public int value
//        {
//            get
//            {
//                return this._value;
//            }
//            set
//            {
//                if ((this._value != value))
//                {
//                    this._value = value;
//                }
//            }
//        }

//        [Association(Name = "Order_Profit_driver", Storage = "_Order", ThisKey = "id_order", OtherKey = "id_order", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
//        public Order Order
//        {
//            get
//            {
//                return this._Order.Entity;
//            }
//            set
//            {
//                Order previousValue = this._Order.Entity;
//                if (((previousValue != value)
//                            || (this._Order.HasLoadedOrAssignedValue == false)))
//                {
//                    if ((previousValue != null))
//                    {
//                        this._Order.Entity = null;
//                        previousValue.Profit_driver.Remove(this);
//                    }
//                    this._Order.Entity = value;
//                    if ((value != null))
//                    {
//                        value.Profit_driver.Add(this);
//                        this._id_order = value.id_order;
//                    }
//                    else
//                    {
//                        this._id_order = default(int);
//                    }
//                }
//            }
//        }
        
//    }
//}
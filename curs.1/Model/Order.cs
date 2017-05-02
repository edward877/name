using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System;

namespace Model
{
    [Table(Name = "dbo.[Order]")]
    public partial class Order : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id_order;

        private System.Nullable<int> _id_driver;

        private System.Nullable<int> _id_car;

        private int _id_client;

        private string _point_of_departure;

        private string _point_of_arrival;

        private decimal _weight;

        private System.Nullable<decimal> _width;

        private System.Nullable<decimal> _height;

        private System.Nullable<decimal> _length;

        private bool _express;

        private System.DateTime _reg_date;

        private decimal _cost;

        private decimal _paid;

        private string _status;

        private string _comment;

        private System.Nullable<decimal> _distance;

        private EntitySet<Profit_driver> _Profit_driver;

        private EntityRef<Car> _Car;

        private EntityRef<Client> _Client;

        private EntityRef<Driver> _Driver;
        private DBDataContext db;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void Onid_orderChanging(int value);
        partial void Onid_orderChanged();
        partial void Onid_driverChanging(System.Nullable<int> value);
        partial void Onid_driverChanged();
        partial void Onid_carChanging(System.Nullable<int> value);
        partial void Onid_carChanged();
        partial void Onid_clientChanging(int value);
        partial void Onid_clientChanged();
        partial void Onpoint_of_departureChanging(string value);
        partial void Onpoint_of_departureChanged();
        partial void Onpoint_of_arrivalChanging(string value);
        partial void Onpoint_of_arrivalChanged();
        partial void OnweightChanging(decimal value);
        partial void OnweightChanged();
        partial void OnwidthChanging(System.Nullable<decimal> value);
        partial void OnwidthChanged();
        partial void OnheightChanging(System.Nullable<decimal> value);
        partial void OnheightChanged();
        partial void OnlengthChanging(System.Nullable<decimal> value);
        partial void OnlengthChanged();
        partial void OnexpressChanging(bool value);
        partial void OnexpressChanged();
        partial void Onreg_dateChanging(System.DateTime value);
        partial void Onreg_dateChanged();
        partial void OncostChanging(decimal value);
        partial void OncostChanged();
        partial void OnpaidChanging(decimal value);
        partial void OnpaidChanged();
        partial void OnstatusChanging(string value);
        partial void OnstatusChanged();
        partial void OncommentChanging(string value);
        partial void OncommentChanged();
        partial void OndistanceChanging(System.Nullable<decimal> value);
        partial void OndistanceChanged();
        #endregion

        public Order()
        {
            this._Profit_driver = new EntitySet<Profit_driver>(new Action<Profit_driver>(this.attach_Profit_driver), new Action<Profit_driver>(this.detach_Profit_driver));
            this._Car = default(EntityRef<Car>);
            this._Client = default(EntityRef<Client>);
            this._Driver = default(EntityRef<Driver>);
            OnCreated();
        }

        public Order(DBDataContext db)
        {
            this._Profit_driver = new EntitySet<Profit_driver>(new Action<Profit_driver>(this.attach_Profit_driver), new Action<Profit_driver>(this.detach_Profit_driver));
            this._Car = default(EntityRef<Car>);
            this._Client = default(EntityRef<Client>);
            this._Driver = default(EntityRef<Driver>);
            this.db = db;
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id_order", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_order
        {
            get
            {
                return this._id_order;
            }
            set
            {
                if ((this._id_order != value))
                {
                    this.Onid_orderChanging(value);
                    this.SendPropertyChanging();
                    this._id_order = value;
                    this.SendPropertyChanged("id_order");
                    this.Onid_orderChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id_driver", DbType = "Int")]
        public System.Nullable<int> id_driver
        {
            get
            {
                return this._id_driver;
            }
            set
            {
                if ((this._id_driver != value))
                {
                    if (this._Driver.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.Onid_driverChanging(value);
                    this.SendPropertyChanging();
                    this._id_driver = value;
                    this.SendPropertyChanged("id_driver");
                    this.Onid_driverChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id_car", DbType = "Int")]
        public System.Nullable<int> id_car
        {
            get
            {
                return this._id_car;
            }
            set
            {
                if ((this._id_car != value))
                {
                    if (this._Car.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.Onid_carChanging(value);
                    this.SendPropertyChanging();
                    this._id_car = value;
                    this.SendPropertyChanged("id_car");
                    this.Onid_carChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id_client", DbType = "Int NOT NULL")]
        public int id_client
        {
            get
            {
                return this._id_client;
            }
            set
            {
                if ((this._id_client != value))
                {
                    if (this._Client.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.Onid_clientChanging(value);
                    this.SendPropertyChanging();
                    this._id_client = value;
                    this.SendPropertyChanged("id_client");
                    this.Onid_clientChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_point_of_departure", DbType = "nvarchar(100) NOT NULL", CanBeNull = false)]
        public string point_of_departure
        {
            get
            {
                return this._point_of_departure;
            }
            set
            {
                if ((this._point_of_departure != value))
                {
                    this.Onpoint_of_departureChanging(value);
                    this.SendPropertyChanging();
                    this._point_of_departure = value;
                    this.SendPropertyChanged("point_of_departure");
                    this.Onpoint_of_departureChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_point_of_arrival", DbType = "nvarchar(100) NOT NULL", CanBeNull = false)]
        public string point_of_arrival
        {
            get
            {
                return this._point_of_arrival;
            }
            set
            {
                if ((this._point_of_arrival != value))
                {
                    this.Onpoint_of_arrivalChanging(value);
                    this.SendPropertyChanging();
                    this._point_of_arrival = value;
                    this.SendPropertyChanged("point_of_arrival");
                    this.Onpoint_of_arrivalChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_weight", DbType = "Decimal(10,2) NOT NULL")]
        public decimal weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                if ((this._weight != value))
                {
                    this.OnweightChanging(value);
                    this.SendPropertyChanging();
                    this._weight = value;
                    this.SendPropertyChanged("weight");
                    this.OnweightChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_width", DbType = "Decimal(6,2)")]
        public System.Nullable<decimal> width
        {
            get
            {
                return this._width;
            }
            set
            {
                if ((this._width != value))
                {
                    this.OnwidthChanging(value);
                    this.SendPropertyChanging();
                    this._width = value;
                    this.SendPropertyChanged("width");
                    this.OnwidthChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_height", DbType = "Decimal(6,2)")]
        public System.Nullable<decimal> height
        {
            get
            {
                return this._height;
            }
            set
            {
                if ((this._height != value))
                {
                    this.OnheightChanging(value);
                    this.SendPropertyChanging();
                    this._height = value;
                    this.SendPropertyChanged("height");
                    this.OnheightChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_length", DbType = "Decimal(6,2)")]
        public System.Nullable<decimal> length
        {
            get
            {
                return this._length;
            }
            set
            {
                if ((this._length != value))
                {
                    this.OnlengthChanging(value);
                    this.SendPropertyChanging();
                    this._length = value;
                    this.SendPropertyChanged("length");
                    this.OnlengthChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_express", DbType = "Bit NOT NULL")]
        public bool express
        {
            get
            {
                return this._express;
            }
            set
            {
                if ((this._express != value))
                {
                    this.OnexpressChanging(value);
                    this.SendPropertyChanging();
                    this._express = value;
                    this.SendPropertyChanged("express");
                    this.OnexpressChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_reg_date", DbType = "DateTime NOT NULL")]
        public System.DateTime reg_date
        {
            get
            {
                return this._reg_date;
            }
            set
            {
                if ((this._reg_date != value))
                {
                    this.Onreg_dateChanging(value);
                    this.SendPropertyChanging();
                    this._reg_date = value;
                    this.SendPropertyChanged("reg_date");
                    this.Onreg_dateChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_cost", DbType = "Decimal(10,2) NOT NULL")]
        public decimal cost
        {
            get
            {
                return this._cost;
            }
            set
            {
                if ((this._cost != value))
                {
                    this.OncostChanging(value);
                    this.SendPropertyChanging();
                    this._cost = value;
                    this.SendPropertyChanged("cost");
                    this.OncostChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_paid", DbType = "Decimal(10,2) NOT NULL")]
        public decimal paid
        {
            get
            {
                return this._paid;
            }
            set
            {
                if ((this._paid != value))
                {
                    this.OnpaidChanging(value);
                    this.SendPropertyChanging();
                    this._paid = value;
                    this.SendPropertyChanged("paid");
                    this.OnpaidChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_status", DbType = "nvarchar(30) NOT NULL", CanBeNull = false)]
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
                    this.OnstatusChanging(value);
                    this.SendPropertyChanging();
                    this._status = value;
                    this.SendPropertyChanged("status");
                    this.OnstatusChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_comment", DbType = "nvarchar(255)")]
        public string comment
        {
            get
            {
                return this._comment;
            }
            set
            {
                if ((this._comment != value))
                {
                    this.OncommentChanging(value);
                    this.SendPropertyChanging();
                    this._comment = value;
                    this.SendPropertyChanged("comment");
                    this.OncommentChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_distance", DbType = "Decimal(10,2)")]
        public System.Nullable<decimal> distance
        {
            get
            {
                return this._distance;
            }
            set
            {
                if ((this._distance != value))
                {
                    this.OndistanceChanging(value);
                    this.SendPropertyChanging();
                    this._distance = value;
                    this.SendPropertyChanged("distance");
                    this.OndistanceChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Order_Profit_driver", Storage = "_Profit_driver", ThisKey = "id_order", OtherKey = "id_order")]
        public EntitySet<Profit_driver> Profit_driver
        {
            get
            {
                return this._Profit_driver;
            }
            set
            {
                this._Profit_driver.Assign(value);
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Car_Order", Storage = "_Car", ThisKey = "id_car", OtherKey = "id_car", IsForeignKey = true, DeleteRule = "CASCADE")]
        public Car Car
        {
            get
            {
                return this._Car.Entity;
            }
            set
            {
                Car previousValue = this._Car.Entity;
                if (((previousValue != value)
                            || (this._Car.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Car.Entity = null;
                        previousValue.Order.Remove(this);
                    }
                    this._Car.Entity = value;
                    if ((value != null))
                    {
                        value.Order.Add(this);
                        this._id_car = value.id_car;
                    }
                    else
                    {
                        this._id_car = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("Car");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Client_Order", Storage = "_Client", ThisKey = "id_client", OtherKey = "id_client", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public Client Client
        {
            get
            {
                return this._Client.Entity;
            }
            set
            {
                Client previousValue = this._Client.Entity;
                if (((previousValue != value)
                            || (this._Client.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Client.Entity = null;
                        previousValue.Order.Remove(this);
                    }
                    this._Client.Entity = value;
                    if ((value != null))
                    {
                        value.Order.Add(this);
                        this._id_client = value.id_client;
                    }
                    else
                    {
                        this._id_client = default(int);
                    }
                    this.SendPropertyChanged("Client");
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Driver_Order", Storage = "_Driver", ThisKey = "id_driver", OtherKey = "id_driver", IsForeignKey = true, DeleteRule = "CASCADE")]
        public Driver Driver
        {
            get
            {
                return this._Driver.Entity;
            }
            set
            {
                Driver previousValue = this._Driver.Entity;
                if (((previousValue != value)
                            || (this._Driver.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Driver.Entity = null;
                        previousValue.Order.Remove(this);
                    }
                    this._Driver.Entity = value;
                    if ((value != null))
                    {
                        value.Order.Add(this);
                        this._id_driver = value.id_driver;
                    }
                    else
                    {
                        this._id_driver = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("Driver");
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

        private void attach_Profit_driver(Profit_driver entity)
        {
            this.SendPropertyChanging();
            entity.Order = this;
        }

        private void detach_Profit_driver(Profit_driver entity)
        {
            this.SendPropertyChanging();
            entity.Order = null;
        }
    }


}

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System;
using System.Linq;

namespace Model
{
    [Table(Name = "dbo.Profit_driver")]
    public partial class Profit_driver : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id_profit_driver;

        private int _id_driver;

        private int _id_order;

        private DateTime _date;

        private decimal _value;

        private DBDataContext db;

        private EntityRef<Order> _Order;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void Onid_profit_driverChanging(int value);
        partial void Onid_profit_driverChanged();
        partial void Onid_driverChanging(int value);
        partial void Onid_driverChanged();
        partial void Onid_orderChanging(int value);
        partial void Onid_orderChanged();
        partial void OndateChanging(System.DateTime value);
        partial void OndateChanged();
        partial void OnvalueChanging(decimal value);
        partial void OnvalueChanged();
        #endregion

        public Profit_driver()
        {
            this._Order = default(EntityRef<Order>);
            OnCreated();
        }

        public Profit_driver(DBDataContext db)
        {
            this._Order = default(EntityRef<Order>);
            OnCreated();
            this.db = db;
        }

        [Column(Storage = "_id_profit_driver", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_profit_driver
        {
            get
            {
                return this._id_profit_driver;
            }
            set
            {
                if ((this._id_profit_driver != value))
                {
                    this.Onid_profit_driverChanging(value);
                    this.SendPropertyChanging();
                    this._id_profit_driver = value;
                    this.SendPropertyChanged("id_profit_driver");
                    this.Onid_profit_driverChanged();
                }
            }
        }

        [Column(Storage = "_id_driver", DbType = "Int NOT NULL")]
        public int id_driver
        {
            get
            {
                return this._id_driver;
            }
            set
            {
                if ((this._id_driver != value))
                {
                    this.Onid_driverChanging(value);
                    this.SendPropertyChanging();
                    this._id_driver = value;
                    this.SendPropertyChanged("id_driver");
                    this.Onid_driverChanged();
                }
            }
        }

        [Column(Storage = "_id_order", DbType = "Int NOT NULL")]
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
                    if (this._Order.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.Onid_orderChanging(value);
                    this.SendPropertyChanging();
                    this._id_order = value;
                    this.SendPropertyChanged("id_order");
                    this.Onid_orderChanged();
                }
            }
        }

        [Column(Storage = "_date", DbType = "DateTime NOT NULL")]
        public DateTime date
        {
            get
            {
                return this._date;
            }
            set
            {
                if ((this._date != value))
                {
                    this.OndateChanging(value);
                    this.SendPropertyChanging();
                    this._date = value;
                    this.SendPropertyChanged("date");
                    this.OndateChanged();
                }
            }
        }

        [Column(Storage = "_value", DbType = "Decimal(10,2) NOT NULL")]
        public decimal value
        {
            get
            {
                return this._value;
            }
            set
            {
                if ((this._value != value))
                {
                    this.OnvalueChanging(value);
                    this.SendPropertyChanging();
                    this._value = value;
                    this.SendPropertyChanged("value");
                    this.OnvalueChanged();
                }
            }
        }

        [Association(Name = "Order_Profit_driver", Storage = "_Order", ThisKey = "id_order", OtherKey = "id_order", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public Order Order
        {
            get
            {
                return this._Order.Entity;
            }
            set
            {
                Order previousValue = this._Order.Entity;
                if (((previousValue != value)
                            || (this._Order.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Order.Entity = null;
                        previousValue.Profit_driver.Remove(this);
                    }
                    this._Order.Entity = value;
                    if ((value != null))
                    {
                        value.Profit_driver.Add(this);
                        this._id_order = value.id_order;
                    }
                    else
                    {
                        this._id_order = default(int);
                    }
                    this.SendPropertyChanged("Order");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((PropertyChanging != null))
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
        

        public override string ToString()
        {
            
           // Driver driver = db.Driver.Where(p => p.id_driver == id_driver).First();
            return id_driver + " || " + date.ToString("dd'/'MM'/'yyyy")
                + " || " + value;
        }
    }
}

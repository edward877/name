using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System;

namespace Model
{
    [Table(Name = "dbo.Driver")]
    public partial class Driver : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id_driver;

        private string _full_name;

        private string _phone_number;

        private DateTime _date_of_birth;

        private string _passport_number;

        private string _adress;

        private bool _status;

        private EntitySet<Order> _Order;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void Onid_driverChanging(int value);
        partial void Onid_driverChanged();
        partial void Onfull_nameChanging(string value);
        partial void Onfull_nameChanged();
        partial void Onphone_numberChanging(string value);
        partial void Onphone_numberChanged();
        partial void Ondate_of_birthChanging(DateTime value);
        partial void Ondate_of_birthChanged();
        partial void Onpassport_numberChanging(string value);
        partial void Onpassport_numberChanged();
        partial void OnadressChanging(string value);
        partial void OnadressChanged();
        partial void OnstatusChanging(bool value);
        partial void OnstatusChanged();
        #endregion

        public Driver()
        {
            this._Order = new EntitySet<Order>(new Action<Order>(this.attach_Order), new Action<Order>(this.detach_Order));
            OnCreated();
        }

        [Column(Storage = "_id_driver", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_full_name", DbType = "nvarchar(50) NOT NULL", CanBeNull = false)]
        public string full_name
        {
            get
            {
                return this._full_name;
            }
            set
            {
                if ((this._full_name != value))
                {
                    this.Onfull_nameChanging(value);
                    this.SendPropertyChanging();
                    this._full_name = value;
                    this.SendPropertyChanged("full_name");
                    this.Onfull_nameChanged();
                }
            }
        }

        [Column(Storage = "_phone_number", DbType = "nvarchar(20) NOT NULL", CanBeNull = false)]
        public string phone_number
        {
            get
            {
                return this._phone_number;
            }
            set
            {
                if ((this._phone_number != value))
                {
                    this.Onphone_numberChanging(value);
                    this.SendPropertyChanging();
                    this._phone_number = value;
                    this.SendPropertyChanged("phone_number");
                    this.Onphone_numberChanged();
                }
            }
        }

        [Column(Storage = "_date_of_birth", DbType = "DateTime NOT NULL")]
        public DateTime date_of_birth
        {
            get
            {
                return this._date_of_birth;
            }
            set
            {
                if ((this._date_of_birth != value))
                {
                    this.Ondate_of_birthChanging(value);
                    this.SendPropertyChanging();
                    this._date_of_birth = value;
                    this.SendPropertyChanged("date_of_birth");
                    this.Ondate_of_birthChanged();
                }
            }
        }

        [Column(Storage = "_passport_number", DbType = "nvarchar(10) NOT NULL", CanBeNull = false)]
        public string passport_number
        {
            get
            {
                return this._passport_number;
            }
            set
            {
                if ((this._passport_number != value))
                {
                    this.Onpassport_numberChanging(value);
                    this.SendPropertyChanging();
                    this._passport_number = value;
                    this.SendPropertyChanged("passport_number");
                    this.Onpassport_numberChanged();
                }
            }
        }

        [Column(Storage = "_adress", DbType = "nvarchar(50) NOT NULL", CanBeNull = false)]
        public string adress
        {
            get
            {
                return this._adress;
            }
            set
            {
                if ((this._adress != value))
                {
                    this.OnadressChanging(value);
                    this.SendPropertyChanging();
                    this._adress = value;
                    this.SendPropertyChanged("adress");
                    this.OnadressChanged();
                }
            }
        }

        [Column(Storage = "_status", DbType = "Bit NOT NULL")]
        public bool status
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

        [Association(Name = "Driver_Order", Storage = "_Order", ThisKey = "id_driver", OtherKey = "id_driver")]
        public EntitySet<Order> Order
        {
            get
            {
                return this._Order;
            }
            set
            {
                this._Order.Assign(value);
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

        private void attach_Order(Order entity)
        {
            this.SendPropertyChanging();
            entity.Driver = this;
        }

        private void detach_Order(Order entity)
        {
            this.SendPropertyChanging();
            entity.Driver = null;
        }


        public override string ToString()
        {
            string driver = full_name + " || " + phone_number + " || " + date_of_birth.ToString("dd'/'MM'/'yyyy")
                + " || " + passport_number + " || " + adress + " || ";
            if (status)
            {
                driver += "свободен";
            } else { driver += "занят"; }
            return driver;
        }
    }

}

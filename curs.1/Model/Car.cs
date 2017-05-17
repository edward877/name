using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System;


namespace Model
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Car")]
    public partial class Car : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id_car;

        private string _number;

        private string _brand;

        private decimal _carrying_capacity;

        private decimal _width;

        private decimal _heigth;

        private bool _status;

        private decimal _length;

        private EntitySet<Order> _Order;


        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void Onid_carChanging(int value);
        partial void Onid_carChanged();
        partial void OnnumberChanging(string value);
        partial void OnnumberChanged();
        partial void OnbrandChanging(string value);
        partial void OnbrandChanged();
        partial void Oncarrying_capacityChanging(decimal value);
        partial void Oncarrying_capacityChanged();
        partial void OnwidthChanging(decimal value);
        partial void OnwidthChanged();
        partial void OnheigthChanging(decimal value);
        partial void OnheigthChanged();
        partial void OnstatusChanging(bool value);
        partial void OnstatusChanged();
        partial void OnlengthChanging(System.Nullable<decimal> value);
        partial void OnlengthChanged();
        #endregion

        public Car()
        {
            this._Order = new EntitySet<Order>(new Action<Order>(this.attach_Order), new Action<Order>(this.detach_Order));
            OnCreated();
        }



        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id_car", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id_car
        {
            get
            {
                return this._id_car;
            }
            set
            {
                if ((this._id_car != value))
                {
                    this.Onid_carChanging(value);
                    this.SendPropertyChanging();
                    this._id_car = value;
                    this.SendPropertyChanged("id_car");
                    this.Onid_carChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_number", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string number
        {
            get
            {
                return this._number;
            }
            set
            {
                if ((this._number != value))
                {
                    this.OnnumberChanging(value);
                    this.SendPropertyChanging();
                    this._number = value;
                    this.SendPropertyChanged("number");
                    this.OnnumberChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_brand", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string brand
        {
            get
            {
                return this._brand;
            }
            set
            {
                if ((this._brand != value))
                {
                    this.OnbrandChanging(value);
                    this.SendPropertyChanging();
                    this._brand = value;
                    this.SendPropertyChanged("brand");
                    this.OnbrandChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_carrying_capacity", DbType = "Decimal(10,2) NOT NULL")]
        public decimal carrying_capacity
        {
            get
            {
                return this._carrying_capacity;
            }
            set
            {
                if ((this._carrying_capacity != value))
                {
                    this.Oncarrying_capacityChanging(value);
                    this.SendPropertyChanging();
                    this._carrying_capacity = value;
                    this.SendPropertyChanged("carrying_capacity");
                    this.Oncarrying_capacityChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_width", DbType = "Decimal(10,2) NOT NULL")]
        public decimal width
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_heigth", DbType = "Decimal(10,2) NOT NULL")]
        public decimal heigth
        {
            get
            {
                return this._heigth;
            }
            set
            {
                if ((this._heigth != value))
                {
                    this.OnheigthChanging(value);
                    this.SendPropertyChanging();
                    this._heigth = value;
                    this.SendPropertyChanged("heigth");
                    this.OnheigthChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_status", DbType = "Bit NOT NULL")]
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

        [Column(Storage = "_length", DbType = "Decimal(10,2) NOT NULL")]
        public decimal length
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

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Car_Order", Storage = "_Order", ThisKey = "id_car", OtherKey = "id_car")]
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
            entity.Car = this;
        }

        private void detach_Order(Order entity)
        {
            this.SendPropertyChanging();
            entity.Car = null;
        }
        public override string ToString()
        {
            return number + " || " + brand + " || " + carrying_capacity + " || " + width
                + " || " + heigth + " || "+ length + " || " + " || " + status;
        }
    }


}

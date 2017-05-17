using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System;

namespace Model
{
    [Table(Name = "dbo.Client")]
    public partial class Client : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _id_client;

        private int _id_user;

        private string _full_name;

        private string _phone_number;

        private string _company;

        private string _e_mail;

        private EntitySet<Order> _Order;

        private EntityRef<User> _User;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void Onid_clientChanging(int value);
        partial void Onid_clientChanged();
        partial void Onid_userChanging(int value);
        partial void Onid_userChanged();
        partial void Onfull_nameChanging(string value);
        partial void Onfull_nameChanged();
        partial void Onphone_numberChanging(string value);
        partial void Onphone_numberChanged();
        partial void OncompanyChanging(string value);
        partial void OncompanyChanged();
        partial void One_mailChanging(string value);
        partial void One_mailChanged();
        #endregion

        public Client()
        {
            this._Order = new EntitySet<Order>(new Action<Order>(this.attach_Order), new Action<Order>(this.detach_Order));
            this._User = default(EntityRef<User>);
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id_client", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
                    this.Onid_clientChanging(value);
                    this.SendPropertyChanging();
                    this._id_client = value;
                    this.SendPropertyChanged("id_client");
                    this.Onid_clientChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_id_user", DbType = "Int NOT NULL")]
        public int id_user
        {
            get
            {
                return this._id_user;
            }
            set
            {
                if ((this._id_user != value))
                {
                    if (this._User.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.Onid_userChanging(value);
                    this.SendPropertyChanging();
                    this._id_user = value;
                    this.SendPropertyChanged("id_user");
                    this.Onid_userChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_full_name", DbType = "nvarchar(50) NOT NULL", CanBeNull = false)]
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_phone_number", DbType = "nvarchar(20) NOT NULL", CanBeNull = false)]
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_company", DbType = "nvarchar(30)")]
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
                    this.OncompanyChanging(value);
                    this.SendPropertyChanging();
                    this._company = value;
                    this.SendPropertyChanged("company");
                    this.OncompanyChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Name = "[e-mail]", Storage = "_e_mail", DbType = "nvarchar(50)")]
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
                    this.One_mailChanging(value);
                    this.SendPropertyChanging();
                    this._e_mail = value;
                    this.SendPropertyChanged("e_mail");
                    this.One_mailChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "Client_Order", Storage = "_Order", ThisKey = "id_client", OtherKey = "id_client")]
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

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "User_Client", Storage = "_User", ThisKey = "id_user", OtherKey = "Id_user", IsForeignKey = true, DeleteOnNull = true, DeleteRule = "CASCADE")]
        public User User
        {
            get
            {
                return this._User.Entity;
            }
            set
            {
                User previousValue = this._User.Entity;
                if (((previousValue != value)
                            || (this._User.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._User.Entity = null;
                        previousValue.Client.Remove(this);
                    }
                    this._User.Entity = value;
                    if ((value != null))
                    {
                        value.Client.Add(this);
                        this._id_user = value.Id_user;
                    }
                    else
                    {
                        this._id_user = default(int);
                    }
                    this.SendPropertyChanged("User");
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

        private void attach_Order(Order entity)
        {
            this.SendPropertyChanging();
            entity.Client = this;
        }

        private void detach_Order(Order entity)
        {
            this.SendPropertyChanging();
            entity.Client = null;
        }

        public override string ToString()
        {
            return _id_client + " || " + _full_name + " || " + _phone_number
                + " || " + _company + " || " + _e_mail;
        }
    }

}

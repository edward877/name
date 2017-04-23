using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System;

namespace Model
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.[User]")]
    public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _Id_user;

        private string _login;

        private string _password;

        private string _role;

        private EntitySet<Client> _Client;

        #region Определения метода расширяемости
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnId_userChanging(int value);
        partial void OnId_userChanged();
        partial void OnloginChanging(string value);
        partial void OnloginChanged();
        partial void OnpasswordChanging(string value);
        partial void OnpasswordChanged();
        partial void OnroleChanging(string value);
        partial void OnroleChanged();
        #endregion

        public User()
        {
            this._Client = new EntitySet<Client>(new Action<Client>(this.attach_Client), new Action<Client>(this.detach_Client));
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id_user", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id_user
        {
            get
            {
                return this._Id_user;
            }
            set
            {
                if ((this._Id_user != value))
                {
                    this.OnId_userChanging(value);
                    this.SendPropertyChanging();
                    this._Id_user = value;
                    this.SendPropertyChanged("Id_user");
                    this.OnId_userChanged();
                }
            }
        }

        [Column(Storage = "_login", DbType = "VarChar(16) NOT NULL", CanBeNull = false)]
        public string login
        {
            get
            {
                return this._login;
            }
            set
            {
                if ((this._login != value))
                {
                    this.OnloginChanging(value);
                    this.SendPropertyChanging();
                    this._login = value;
                    this.SendPropertyChanged("login");
                    this.OnloginChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_password", DbType = "VarChar(16) NOT NULL", CanBeNull = false)]
        public string password
        {
            get
            {
                return this._password;
            }
            set
            {
                if ((this._password != value))
                {
                    this.OnpasswordChanging(value);
                    this.SendPropertyChanging();
                    this._password = value;
                    this.SendPropertyChanged("password");
                    this.OnpasswordChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_role", DbType = "VarChar(16) NOT NULL", CanBeNull = false)]
        public string role
        {
            get
            {
                return this._role;
            }
            set
            {
                if ((this._role != value))
                {
                    this.OnroleChanging(value);
                    this.SendPropertyChanging();
                    this._role = value;
                    this.SendPropertyChanged("role");
                    this.OnroleChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name = "User_Client", Storage = "_Client", ThisKey = "Id_user", OtherKey = "id_user")]
        public EntitySet<Client> Client
        {
            get
            {
                return this._Client;
            }
            set
            {
                this._Client.Assign(value);
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

        private void attach_Client(Client entity)
        {
            this.SendPropertyChanging();
            entity.User = this;
        }

        private void detach_Client(Client entity)
        {
            this.SendPropertyChanging();
            entity.User = null;
        }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public  class UserDB
    {

        private DBDataContext db;

        public UserDB(DBDataContext db)
        {
            this.db = db;
        }

        public User Insert(string login,string password, string role)
        {
            User user = new User();
            user.login = login;
            user.password = password;
            user.role = role;
            db.User.InsertOnSubmit(user);
            db.SubmitChanges();
            return user;
        }

        public void Delete(int id_user)
        {
            User user = db.User.Where(cl => cl.Id_user == id_user).FirstOrDefault();
            db.User.DeleteOnSubmit(user);
            db.SubmitChanges();
        }


    }
}

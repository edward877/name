using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   
    public class Visitor
    {
        private DBDataContext db;

        static public User user;

        static public Client client;


        public Visitor(DBDataContext db)
        {
            this.db = db;
        }
        

        public bool Log_in(string login, string password)
        {
            User user;
            user = db.User.Where(u => (u.login == login && u.password == password)).FirstOrDefault();
            if (user != null)
            {
                Visitor.user = user;
                
                client = getClient();

                return true;
            }

            return false;
        }

        Client getClient()
        {
            Client client = db.Client.Where(c => (c.id_user == user.Id_user)).FirstOrDefault();
            return client;
        }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ClientDB
    {
        private DBDataContext db;
        UserDB userdb;
        public ClientDB(DBDataContext db)
        {
            this.db = db;
            userdb = new UserDB(db);
        }

        public void Insert(string login, string password, string full_name, string phone_number, string company)
        {
                User user = userdb.Insert(login, password, "client");

                Client client = new Client();
                client.id_user = user.Id_user;
                client.full_name = full_name;
                client.phone_number = phone_number;
                client.company = company;
                db.Client.InsertOnSubmit(client);
                db.SubmitChanges();


        }


        public void Update(int id_client, string full_name, string phone_number, string company)
        {
            Client client = db.Client.Where(c => c.id_client == id_client).FirstOrDefault();
            client.full_name = full_name;
            client.phone_number = phone_number;
            client.company = company;
            db.SubmitChanges();
        }

        public void Delete(int id_client)
        {
            Client client = db.Client.Where(cl => cl.id_client == id_client).FirstOrDefault();
            userdb.Delete(client.id_user);
            db.Client.DeleteOnSubmit(client);
            db.SubmitChanges();
        }


        public List<Client> Show()
        {
            return db.Client.Where(c => c.id_client >= 0).ToList();
        }


        public bool IsVIPClient(int client_id)
        {
            int count_order;

            count_order = db.Order.Where(o => o.id_client == client_id).Count();

            if (count_order > 5)
            {
                return true;
            }
            return false;
        }
    }
}

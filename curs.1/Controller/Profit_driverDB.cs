using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public  class Profit_driverDB
    {
        private DBDataContext db;

        public Profit_driverDB(DBDataContext db)
        {
            this.db = db;
        }

        public void Insert(int id_driver, int id_order)
        {
            Profit_driver profit = new Profit_driver(db);
            profit.id_driver = id_driver;
            profit.id_order = id_order;
            profit.date = DateTime.Now;
            profit.value = CountValue(profit.id_order); 
            db.Profit_driver.InsertOnSubmit(profit);
            db.SubmitChanges();
        }


        public List<Profit_driver> Show()
        {
            return db.Profit_driver.ToList();
        }

        decimal CountValue(int id_order)
        {
            Order order = db.Order.Where(o => o.id_order == id_order).FirstOrDefault();
            return (order.cost/10);
        }

        public List<Profit_driver> Query(string Fio)
        {

             return db.Profit_driver.Where(p => p.Order.Driver.full_name.Contains(Fio)).ToList();
        }
    }
}

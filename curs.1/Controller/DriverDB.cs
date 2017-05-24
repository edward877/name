using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DriverDB
    {
        private DBDataContext db;
        OrderDB orderdb;

        public DriverDB(DBDataContext db)
        {
            this.db = db;
        }

        public void Insert(string full_name, string phone_number, DateTime date_of_birth,
           string passport_number, string adress, bool status)
        {
            Driver driver = new Driver();
            driver.full_name = full_name;
            driver.phone_number = phone_number;
            driver.date_of_birth = date_of_birth;
            driver.passport_number = passport_number;
            driver.adress = adress;
            driver.status = status;
            db.Driver.InsertOnSubmit(driver);
            db.SubmitChanges();

            orderdb = new OrderDB(db);
            orderdb.SetDriver();
        }

        public void Update(int id_driver, string full_name, string phone_number, DateTime date_of_birth,
            string passport_number, string adress, bool status)
        {
            Driver driver = db.Driver.Where(d => d.id_driver == id_driver).FirstOrDefault();
            driver.full_name = full_name;
            driver.phone_number = phone_number;
            driver.date_of_birth = date_of_birth;
            driver.passport_number = passport_number;
            driver.adress = adress;
            driver.status = status;
            db.SubmitChanges();
        }

        public void Delete(int id_driver)
        {
            Driver driver = db.Driver.Where(d => d.id_driver == id_driver).FirstOrDefault();
            db.Driver.DeleteOnSubmit(driver);
            db.SubmitChanges();
        }

        public List<Driver> Show()
        {
            return db.Driver.ToList();
        }

        public Driver Show(int id_driver)
        {
            return db.Driver.Where(d => d.id_driver == id_driver).FirstOrDefault();
        }

        public int? FindFreeDriver()
        {
            Driver driver = db.Driver.Where(d => d.status).FirstOrDefault();
            if (driver != null)
            {
                driver.status = false;
                return driver.id_driver;
            }
            return null;
            
                
        }

        public void SetFree(int? id_driver)
        {
            Driver driver = db.Driver.Where(c => c.id_driver == id_driver).FirstOrDefault();
            driver.status = true;
        }

        public List<Driver> Query(string full_name, string phone_number, string passport_number)
        {
            List<Driver> listDrivers = null;
            listDrivers = db.Driver.Where(c => 
                 c.full_name.Contains(full_name)
                 && c.phone_number.Contains(phone_number)
                 && c.passport_number.Contains(passport_number)
            ).ToList();

            return listDrivers;
        }

        public List<Driver> QueryStatus(string full_name, string phone_number, string passport_number, bool status)
        {
            List<Driver> listDrivers = null;
            listDrivers = db.Driver.Where(c =>
                 c.full_name.Contains(full_name)
                 && c.phone_number.Contains(phone_number)
                 && c.passport_number.Contains(passport_number)
                 && c.status == status
            ).ToList();

            return listDrivers;
        }

    }
}

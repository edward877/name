﻿using Model;
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
            return db.Driver.Where(d => d.id_driver >= 0).ToList();
        }
    }
}

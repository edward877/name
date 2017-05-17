using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using Model;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    public class ReportProfitController
    {
        DBDataContext db;
        DriverDB driverdb;

        public ReportProfitController(DBDataContext db)
        {
            this.db = db;
        }

        public List<ReportProfit> Money()
        {
            List<ReportProfit> reports = new List<ReportProfit>();

            driverdb = new DriverDB(db);
            DateTime now = DateTime.Now;
            List<Profit_driver> profits = db.Profit_driver.Where(p =>
                    (p.date.Year == now.Year && p.date.Month == now.Month)).ToList();

            foreach (Driver driver in driverdb.Show())
            {
                decimal money = 0;

                for (int i = 0; i < profits.Count; i++)
                {
                    if (driver.id_driver == profits[i].id_driver)
                    {
                        money += profits[i].value;
                    }

                }
                reports.Add(new ReportProfit(driver.id_driver, driver.full_name, money));
            }
            return reports;
        }
    }
}

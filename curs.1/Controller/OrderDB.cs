using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi;
using System.Globalization;

namespace Controller
{
    public class OrderDB
    {

        private DBDataContext db;
        DriverDB driverdb;
        CarDB cardb;
        Profit_driverDB profitdb;
        ClientDB clientdb;

        public OrderDB(DBDataContext db)
        {
            this.db = db;
            driverdb = new DriverDB(db);
            cardb = new CarDB(db);
            profitdb = new Profit_driverDB(db);
            clientdb = new ClientDB(db);
        }


        public void Insert(string point_of_departure, string point_of_arrival, decimal weight,
            decimal? width, decimal? height, decimal? length, bool express,  string comment, double distance, decimal cost, decimal paid)
        {
            Order order = new Order(db);


            order.id_driver = driverdb.FindFreeDriver();

            if (Visitor.client != null)
            {
                order.id_client = Visitor.client.id_client;
            }

            order.point_of_departure = point_of_departure;
            order.point_of_arrival = point_of_arrival;
            order.weight = weight;
            order.width = width;
            order.height = height;
            order.length = length;
            order.express = express;
            order.comment = comment;
            order.id_car = cardb.FindFreeCar(order);
            order.distance = (decimal)distance;
            order.reg_date = DateTime.Now;
            order.cost = cost;
            order.paid = paid;
            order.status = "заказ обрабатывается";
            db.Order.InsertOnSubmit(order);
            db.SubmitChanges();
        }

        public void Update(int id_order, int? id_driver, int? id_car, int id_client,
            string point_of_departure, string point_of_arrival, decimal weight, decimal? width,
            decimal? height, decimal? length, string status, DateTime reg_date, decimal cost,
            decimal paid, bool express, string comment)
        {
            Order order = db.Order.Where(o => o.id_order == id_order).FirstOrDefault();

            order.id_driver = id_driver;
            order.id_car = id_car;
            order.id_client = id_client;
            order.point_of_departure = point_of_departure;
            order.point_of_arrival = point_of_arrival;
            order.weight = weight;
            order.width = width;
            order.height = height;
            order.length = length;
            order.status = status;
            order.reg_date = reg_date;
            order.cost = cost;
            order.paid = paid;
            order.express = express;
            order.comment = comment;

            if (order.status == "готово")
            {
                if (order.id_driver != null)
                    driverdb.SetFree(order.id_driver);

                if (order.id_car != null)
                    cardb.SetFree(order.id_car);
            }

            db.SubmitChanges();

            if (order.status == "готово")
            {
                profitdb.Insert((int)order.id_driver, order.id_order);
            }
            SetDriver();
            SetCar();
        }


        public void PayMoney(int id_order, decimal paid)
        {
            Order order = db.Order.Where(o => o.id_order == id_order).FirstOrDefault();
            order.paid += paid;
            db.SubmitChanges();
        }


        public void Delete(int id_order)
        {
            Order order = db.Order.Where(o => o.id_order == id_order).FirstOrDefault();
            if (order.id_driver != null)
                driverdb.SetFree(order.id_driver);

            if (order.id_car != null)
                cardb.SetFree(order.id_car);
            db.Order.DeleteOnSubmit(order);
            db.SubmitChanges();

            SetDriver();
            SetCar();

        }
        public void Done(int id_order)
        {
            Order order = db.Order.Where(o => o.id_order == id_order).FirstOrDefault();
           
            if (order.id_driver != null)
            {
                driverdb.SetFree(order.id_driver);
                profitdb.Insert((int)order.id_driver, order.id_order);
            }

            if (order.id_car != null)
                cardb.SetFree(order.id_car);

            order.status = "готово";
            SetDriver();
            SetCar();
        }
        public List<Order> Show()
        {
            return db.Order.ToList();
        }

        public List<Order> Show(int id_client)
        {
            return db.Order.Where(o => o.id_client == id_client).ToList();
        }
        public Order GetOrder(int id_order)
        {
            return db.Order.Where(o => o.id_order == id_order).FirstOrDefault();
        }
        public double CountDistantion(string point_of_departure, string point_of_arrival)
        {
            ConnectMaps google = new ConnectMaps(point_of_departure, point_of_arrival);
            Distantion d = new Distantion();
            double distance = 0;
            try
            {
                string distanceStr = d.ReadXml();
                if (distanceStr.Contains("."))
                {
                    CultureInfo c = CultureInfo.CurrentCulture.Clone() as CultureInfo;
                    c.NumberFormat.NumberDecimalSeparator = ".";
                    distance = double.Parse(d.ReadXml(), c);
                }
                else if (distanceStr.Contains(","))
                {
                    distance = double.Parse(distanceStr.Replace(",", ""));
                }
                else if (!distanceStr.Equals("0"))
                {
                    distance = double.Parse(distanceStr.Replace(",", ""));
                }
                else throw new ArgumentException("distance cannot be 0", "original");
            }
            catch { }
            return distance;
        }

        public double CountCost(double distance, double width, bool express, int id)
        {
            ClientDB clientdb = new ClientDB(db);
            double cost = 0;
            if (distance > 100)
            {
                cost += 200 + distance * 15;
            }
            else
            {
                cost += 400 + distance * 20;
            }

            if (width > 500)
                cost += (width - 500) * 2;
            if (express)
                cost *= 1.5;
            if (clientdb.IsVIPClient(id))
            {
                cost *= 0.85;
            }

            return cost;
        }

        public void SetDriver()
        {
            Order order = db.Order.Where(o => o.id_driver == null).FirstOrDefault();
            if (order != null)
            {
                order.Driver = db.Driver.Where(o => o.id_driver == driverdb.FindFreeDriver()).FirstOrDefault();
                
                db.SubmitChanges();
            }
        }

        public void SetCar()
        {
            Order order = db.Order.Where(o => o.id_car == null).FirstOrDefault();
            if (order != null)
            {
                order.id_car = cardb.FindFreeCar(order);
                if (order.id_car != null)
                {
                    db.SubmitChanges();
                }
            }
        }
        

        public List<Order> Query(string full_name, string car, string client, decimal cost, decimal paid)
        {

            List<Order> listOrder = null;
            if (full_name == "" || car == "")
            {
                if (car != "")
                {
                    listOrder = db.Order.Where(
                                     o => o.Car.number.Contains(car) &&
                                     o.Client.full_name.Contains(client) &&
                                     o.cost > cost && (o.paid > paid || o.paid == paid)
                                  ).ToList();
                }
                else if (full_name != "")
                {
                    listOrder = db.Order.Where(
                         o => o.Driver.full_name.Contains(full_name) &&
                         o.Client.full_name.Contains(client) &&
                         o.cost > cost && (o.paid > paid || o.paid == paid)
                    ).ToList();
                }
                else
                {
                    listOrder = db.Order.Where(
                      o => o.Client.full_name.Contains(client) &&
                      o.cost > cost && (o.paid > paid || o.paid == paid)
                 ).ToList();
                }
            }
            else
            {
                listOrder = db.Order.Where(
                 o => o.Driver.full_name.Contains(full_name) &&
                 o.Car.number.Contains(car) &&
                 o.Client.full_name.Contains(client) &&
                 o.cost > cost && (o.paid > paid || o.paid == paid)
              ).ToList();
            }

            return listOrder;
        }

        public List<decimal> getMoney(int day)
        {
            List<decimal> listMoney = new List<decimal>();
            List<Order> orders = db.Order.ToList();
            decimal money;
            int year =  DateTime.Now.Year;
            int dayOfYear = DateTime.Now.DayOfYear;
            int month = DateTime.Now.Month;
            for (int i = day-1; i >= 0; i--)
            {
                money = 0;
                if (day != 12)
                {
                    foreach (Order o in orders)
                    {
                        if (o.reg_date.Year == year && o.reg_date.DayOfYear == dayOfYear-i)
                        {
                            money += o.cost;
                        }
                    }
                }
                else
                {
                    foreach (Order o in orders)
                    {
                        if (o.reg_date.Year == year && o.reg_date.Month == month - i)
                        {
                            money += o.cost;
                        }
                    }
                }
                listMoney.Add(money);
            }
            return listMoney;
        }
        

    }
}

using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class CarDB
    {
        private DBDataContext db;
        OrderDB orderdb;
        public CarDB(DBDataContext db)
        {
            this.db = db;
        }

        public void Insert(string number, string brand, decimal carrying_capacity,
            decimal width, decimal heigth, decimal length, bool status)
        {
            Car car = new Car();
            car.number = number;
            car.brand = brand;
            car.carrying_capacity = carrying_capacity;
            car.width = width;
            car.heigth = heigth;
            car.length = length;
            car.status = status;
            db.Car.InsertOnSubmit(car);
            db.SubmitChanges();

            orderdb = new OrderDB(db);
            orderdb.SetCar();

        }


        public void Update(int id_car, string number, string brand, decimal carrying_capacity,
           decimal width, decimal heigth, decimal length, bool status)
        {
            Car car = db.Car.Where(c => c.id_car == id_car).FirstOrDefault();
            car.number = number;
            car.brand = brand;
            car.carrying_capacity = carrying_capacity;
            car.width = width;
            car.heigth = heigth;
            car.status = status;
            db.SubmitChanges();
        }

        public void Delete(int id_car)
        {
            Car car = db.Car.Where(c => c.id_car == id_car).FirstOrDefault();
            db.Car.DeleteOnSubmit(car);
            db.SubmitChanges();
        }

        public List<Car> Show()
        {
            return db.Car.Where(c => c.id_car >= 0).ToList();
        }

        public int? FindFreeCar(Order order)
        {
            List<Car> cars = db.Car.Where(c => c.status).ToList();
            foreach(var car in cars)
            {
                if (car != null)
                {
                    if (car.carrying_capacity < order.weight) continue;

                    if (order.height != null)
                    {
                        if (car.heigth < order.height) continue;
                    }

                    if (order.width != null)
                    {
                        if (car.width < order.width) continue;
                    }

                    if (order.length != null)
                    {
                        if (car.length < order.length)  continue;
                    }

                    car.status = false;
                    return car.id_car;
                }
            }
            return null;
           
        }

        public void SetFree(int? id_car)
        {
            Car car = db.Car.Where(c => c.id_car == id_car).FirstOrDefault();
            car.status = true;
        }
    }
}

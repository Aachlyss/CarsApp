using CarsApp.Core.Contracts;
using CarsApp.Infrastructure.Data;
using CarsApp.Infrastructure.Data.Domain;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.Core
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string regNumber, string manufacturer, string model, string picture, DateTime yearOfManufacture, double price)
        {
            Car item = new Car
            {
                RegNumber = regNumber,
                Manufacturer = manufacturer,
                Model = model,
                Picture = picture,
                YearOfmanufacture = yearOfManufacture,
                Price = price
            };

            _context.Cars.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Car GetCarById(int carId)
        {
            return _context.Cars.Find(carId);
        }

        public List<Car> GetCars(string searchStringModel, string searchStringPrice)
        {
            List<Car> cars = _context.Cars.ToList();
            if (!String.IsNullOrEmpty(searchStringPrice) && !String.IsNullOrEmpty(searchStringModel))
            {
                cars = cars.Where(d => d.Model.Contains(searchStringModel) && d.Model.Contains(searchStringPrice)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringModel))
            {
                cars = cars.Where(d => d.Model.Contains(searchStringModel)).ToList();
            }
            return cars;
        }

        public List<Car> GetDogs()
        {
            List<Car> cars = _context.Cars.ToList();
            return cars;
        }

        public bool RemoveById(int carId)
        {
            var car = GetCarById(carId);
            if (car == default(Car)) 
            {
                return false;
            }
            _context.Remove(car);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateCar(int carId, string regNumber, string manufacturer, string model, string picture, DateTime yearOfManufacture, double price)
        {
            var car = GetCarById(carId);
            if (car == default(Car))
            {
                return false;
            }
            car.RegNumber = regNumber;
            car.Manufacturer = manufacturer;
            car.Model = model;
            car.Picture = picture;
            car.YearOfmanufacture = yearOfManufacture;
            car.Price = price;
            _context.Update(car);
            return _context.SaveChanges() != 0;
        }
    }
}

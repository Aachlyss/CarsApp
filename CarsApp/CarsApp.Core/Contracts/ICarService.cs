using CarsApp.Infrastructure.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.Core.Contracts
{
    public interface ICarService
    {
        bool Create(string regNumber, string manufacturer, string model, string picture, DateTime yearOfManufacture, double price);
        bool UpdateCar(int carId, string regNumber, string manufacturer, string model, string picture, DateTime yearOfManufacture, double price);
        List<Car> GetDogs();
        Car GetCarById(int carId);
        bool RemoveById(int carId);
        List<Car> GetCars(string searchStringModel, string searchStringPrice);
    }
}

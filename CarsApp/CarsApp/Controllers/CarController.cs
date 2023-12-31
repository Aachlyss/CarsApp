﻿using CarsApp.Core.Contracts;
using CarsApp.Infrastructure.Data;
using CarsApp.Infrastructure.Data.Domain;
using CarsApp.Models.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace CarsApp.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            this._carService = carService;
        }
        // GET: CarController
        public ActionResult Index(string searchStringModel, string searchStringPrice, string sortOrder)
        {
            List<CarAllViewModel> cars = _carService.GetCars(searchStringModel, searchStringPrice)
                .Select(carFromDb => new CarAllViewModel
                {
                    Id = carFromDb.Id,
                    RegNumber = carFromDb.RegNumber,
                    Manufacturer = carFromDb.Manufacturer,
                    Model = carFromDb.Model,
                    Picture = carFromDb.Picture,
                    YearOfmanufacture = carFromDb.YearOfmanufacture,
                    Price = carFromDb.Price
                }).ToList();
            if (!String.IsNullOrEmpty(searchStringPrice) && !String.IsNullOrEmpty(searchStringModel))
            {
                cars = cars.Where(d => d.Model.Contains(searchStringModel) && d.Model.Contains(searchStringPrice)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringModel))
            {
                cars = cars.Where(d => d.Model.Contains(searchStringModel)).ToList();
            }

            ViewData["PriceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            cars = sortOrder switch
            {
                "price_desc" => cars.OrderByDescending(c => c.Price).ToList(),
                _ => cars.OrderBy(c => c.Price).ToList(),
            };


            return this.View(cars);


        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
           
            Car item = _carService.GetCarById(id);
            if (item == null)
            {
                return NotFound();
            }
            CarDetailsViewModel car = new CarDetailsViewModel()
            {
                Id = item.Id,
                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Picture = item.Picture,
                YearOfmanufacture = item.YearOfmanufacture,
                Price = item.Price
            };
            return View(car);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var created = _carService.Create(bindingModel.RegNumber,bindingModel.Manufacturer, bindingModel.Model,bindingModel.Picture,bindingModel.YearOfmanufacture,bindingModel.Price);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
            return this.View();
        }
        public IActionResult Success()
        {
            return this.View();
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            Car item = _carService.GetCarById(id);
            if (item == null)
            {
                return NotFound();
            }
            CarEditViewModel car = new CarEditViewModel()
            {
                Id = item.Id,
                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Picture = item.Picture,
                YearOfmanufacture= item.YearOfmanufacture,
                Price = item.Price
            };
            return View(car);
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarEditViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _carService.UpdateCar(id,bindingModel.RegNumber, bindingModel.Manufacturer, bindingModel.Model, bindingModel.Picture, bindingModel.YearOfmanufacture, bindingModel.Price);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(bindingModel);
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            
            Car item = _carService.GetCarById(id);
            if (item == null)
            {
                return NotFound();
            }
            CarEditViewModel car = new CarEditViewModel()
            {
                Id = item.Id,
                RegNumber = item.RegNumber,
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Picture = item.Picture,
                YearOfmanufacture = item.YearOfmanufacture,
                Price = item.Price
            };
            return View(car);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _carService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Index", "Car");
            }
            else
            {
                return View();
            }
        }
    }
}

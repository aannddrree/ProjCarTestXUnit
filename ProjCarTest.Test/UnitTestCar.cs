using Microsoft.EntityFrameworkCore;
using ProjCarTest.Api.Controllers;
using ProjCarTest.Api.Data;
using ProjCarTest.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProjCarTest.Test
{
    public class UnitTestCar
    {
        private DbContextOptions<ProjCarTestApiContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<ProjCarTestApiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new ProjCarTestApiContext(options))
            {
                context.Car.Add(new Car { Id = 1, Model = "Palio", Brand = "Fiat", Color = "Vermelho"});
                context.Car.Add(new Car { Id = 2, Model = "Gol", Brand ="VW", Color = "Branco"});
                context.Car.Add(new Car { Id = 3, Model = "Ka", Brand = "Ford", Color = "Prata" });
                context.SaveChanges();
            }
        }


        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new ProjCarTestApiContext(options))
            {
                CarsController carsController = new CarsController(context);
                IEnumerable<Car> cars = carsController.GetCar().Result.Value;
                Assert.Equal(3, cars.Count());
            }
        }

        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new ProjCarTestApiContext(options))
            {
                int carId = 2;
                CarsController carsController = new CarsController(context);
                Car car = carsController.GetCar(carId).Result.Value;
                Assert.Equal(2, car.Id);
            }
        }

        [Fact]
        public async void Create()
        {
            InitializeDataBase();

            Car car = new Car()
            {
                Id = 4,
                Model = "Kwid",
                Brand = "Renault",
                Color = "Preto"
            };

            // Use a clean instance of the context to run the test
            using (
                var context = new ProjCarTestApiContext(options))
            {
                CarsController carsController = new CarsController(context);
                await carsController.PostCar(car);
                Car carReturn = carsController.GetCar(4).Result.Value;
                Assert.Equal("Kwid", carReturn.Model);
            }
        }

        [Fact]
        public async void Update()
        {
            InitializeDataBase();

            Car car = new Car()
            {
                Id = 3,
                Model = "Ranger",
                Brand = "Ford",
                Color = "Prata"
            };

            // Use a clean instance of the context to run the test
            using (var context = new ProjCarTestApiContext(options))
            {
                CarsController carsController = new CarsController(context);
                await carsController.PutCar(3, car);
                Car carReturn = carsController.GetCar(3).Result.Value;
                Assert.Equal("Ranger", carReturn.Model);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new ProjCarTestApiContext(options))
            {
                CarsController carsController = new CarsController(context);
                Car car = carsController.DeleteCar(2).Result.Value;
                Assert.Null(car);
            }
        }
    }
}

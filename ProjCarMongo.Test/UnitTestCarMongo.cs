using MongoDB.Driver;
using Moq;
using ProjCarMongo.Api;
using ProjCarMongo.Api.Services;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Xunit;

namespace ProjCarMongo.Test
{
    public class UnitTestCarMongo
    {
        private List<Car> _allCars;

        private void InitializeDataBase()
        {
            _allCars = new List<Car>();
            _allCars.Add(new Car() {Id = "1", Model = "Gol", Brand = "VW", Color = "Azul" });
            _allCars.Add(new Car() { Id = "2", Model = "Uno", Brand = "Fiat", Color = "Branco" });
            _allCars.Add(new Car() { Id = "3", Model = "ka", Brand = "Ford", Color = "Branco" });
        }


        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            var mock = new Mock<ICarService>();

            mock.Setup(x => x.Get()).Returns(_allCars);

            ICarService mongoService = mock.Object;

            var items = mongoService.Get(); //Should call mocked service;
            var count = items.Count;
            Assert.Equal(3, count);
        }
    }
}

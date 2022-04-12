using MongoDB.Driver;
using ProjCarMongo.Api.Config;
using System.Collections.Generic;

namespace ProjCarMongo.Api.Services
{
    public class CarService : ICarService
    {
        private readonly IMongoCollection<Car> _clientes;

        public CarService(IProjMongoDotnetDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clientes = database.GetCollection<Car>(settings.ClienteCollectionName);
        }

        public List<Car> Get() =>
            _clientes.Find(cliente => true).ToList();

        public Car Get(string id) =>
            _clientes.Find<Car>(car => car.Id == id).FirstOrDefault();

        public Car Create(Car car)
        {
            _clientes.InsertOne(car);
            return car;
        }

        public void Update(string id, Car carIn) =>
            _clientes.ReplaceOne(car => car.Id == id, carIn);

        public void Remove(Car carIn) =>
            _clientes.DeleteOne(car => car.Id == carIn.Id);

        public void Remove(string id) =>
            _clientes.DeleteOne(car => car.Id == id);
    }
}

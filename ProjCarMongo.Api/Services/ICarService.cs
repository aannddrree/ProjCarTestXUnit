using System.Collections.Generic;

namespace ProjCarMongo.Api.Services
{
    public interface ICarService
    {
        List<Car> Get();
        Car Get(string id);
        Car Create(Car car);
        void Update(string id, Car carIn);
        void Remove(Car carIn);
        void Remove(string id);

    }
}

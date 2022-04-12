using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjCarMongo.Api
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
    }
}

namespace ProjCarMongo.Api.Config
{
    public class ProjMongoDotnetDatabaseSettings: IProjMongoDotnetDatabaseSettings
    {
        public string ClienteCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

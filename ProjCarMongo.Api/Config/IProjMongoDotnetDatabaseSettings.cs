﻿namespace ProjCarMongo.Api.Config
{
    public interface IProjMongoDotnetDatabaseSettings
    {
        string ClienteCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

﻿namespace Fcx.Library.Infrastructure.MongoDB.Configuration
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}

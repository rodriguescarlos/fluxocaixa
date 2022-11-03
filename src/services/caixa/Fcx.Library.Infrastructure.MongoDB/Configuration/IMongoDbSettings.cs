namespace Fcx.Library.Infrastructure.MongoDB.Configuration
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}

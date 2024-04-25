using ManageStudent.Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ManageStudent.Data.MongoDB.Setting
{
    public class DatabaseSettings : IDatabaseSettings
    {
        private readonly IMongoDatabase _database;
        public DatabaseSettings(IOptions<Settings> options, IMongoClient client)
        {
            _database = client.GetDatabase(options.Value.Database) ;
        }

        public IMongoCollection<Composer> Composers => _database.GetCollection<Composer>("Composers");
    
    }
}

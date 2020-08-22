using MicroService1.Models;
using MongoDB.Driver;
using System.Linq;

namespace MicroService1.Services
{
    public class DatabaseService
    {
        private readonly IMongoCollection<Ms2Configuration> _ms2Configs;

        public DatabaseService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _ms2Configs = database.GetCollection<Ms2Configuration>(settings.Ms2ConfigCollectionName);
        }

        public Ms2Configuration Get() =>
            _ms2Configs.Find(ms2C => true).FirstOrDefault();

        public Ms2Configuration Set(Ms2Configuration ms2Config)
        {
            var existing = Get();
            if(existing == null)
            {
                _ms2Configs.InsertOne(ms2Config);
            }
            else
            {
                ms2Config.Id = existing.Id;
                _ms2Configs.ReplaceOne(x => x.Id == existing.Id, ms2Config);
            }
            return ms2Config;
        }
    }
}
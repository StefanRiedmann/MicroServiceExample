namespace MicroService1.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string Ms2ConfigCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string Ms2ConfigCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroService1.Models
{
    public class Ms2Configuration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; }

        [BsonElement("Secret")]
        public string Secret { get; set; }
    }
}
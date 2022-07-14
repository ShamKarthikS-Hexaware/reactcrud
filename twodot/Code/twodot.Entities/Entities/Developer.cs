using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace twodot.Entities.Entities
{
    [BsonIgnoreExtraElements]
    public class Developer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string name  { get; set; }
        
    }

}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Fcx.Library.Infrastructure.MongoDB
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}

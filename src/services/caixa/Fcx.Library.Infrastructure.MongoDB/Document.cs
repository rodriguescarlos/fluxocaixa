using MongoDB.Bson;

namespace Fcx.Library.Infrastructure.MongoDB
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}

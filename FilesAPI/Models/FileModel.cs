using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FilesAPI.Models
{
    public class FileModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string MimeType { get; set; }
     
        public byte[] Content { get; set; }
    }
}

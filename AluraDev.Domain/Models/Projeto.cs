using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AluraDev.Domain.Models
{
    public class Projeto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Linguagem { get; set; } = null!;
        public string Cor { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public ICollection<string> Likes { get; set; } = new List<string>();
        public Usuario Usuario { get; set; } = null!;
        public ICollection<string> Comentarios { get; set; } = new List<string>();
    }
}

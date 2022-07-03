using MongoDB.Bson.Serialization.Attributes;
using System;

namespace API.WebScraping.Model
{
    public class Noticia
    {
        public Noticia(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        [BsonElement("_id")]
        public Guid Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}

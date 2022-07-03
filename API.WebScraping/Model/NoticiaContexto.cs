using API.WebScraping.DataBase;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API.WebScraping.Model
{
    public class NoticiaContexto
    {
        private readonly IMongoDatabase _mongoDatabase;

        public NoticiaContexto(IOptions<ConfigBD> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);

            if (mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(options.Value.Database);
            }
        }

        public IMongoCollection<Noticia> Noticias
        {
            get
            {
                return _mongoDatabase.GetCollection<Noticia>("Noticia");

            }
        }

    }
}

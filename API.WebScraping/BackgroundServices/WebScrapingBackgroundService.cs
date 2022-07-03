using API.WebScraping.DataBase;
using API.WebScraping.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.WebScraping.BackgroundServices
{
    public class WebScrapingBackgroundService : BackgroundService
    {
        public IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<WebScrapingBackgroundService> _logger;
        private readonly NoticiaContexto _noticiaContexto;

        public WebScrapingBackgroundService(
            IServiceScopeFactory serviceScopeFactory, 
            ILogger<WebScrapingBackgroundService> logger,
            IOptions<ConfigBD> options)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
            _noticiaContexto = new NoticiaContexto(options);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                while (true)
                {
                    try
                    {
                        _logger.LogInformation("## Buscando noticias ##");
                        var webScraping = new WebScraping();
                        var resultado = webScraping.BuscarNoticias();                           

                        foreach (var item in resultado)
                        {
                            _logger.LogInformation($"Titulo: {item.Titulo} - Descrição: {item.Descricao}");
                            var noticiaObjeto = new Noticia(item.Titulo, item.Descricao);
                            await _noticiaContexto.Noticias.InsertOneAsync(noticiaObjeto);
                            _logger.LogInformation("## Efetuada importação de novas noticias ##");
                        }

                        await Task.Delay(60000, stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation("## Não foi possivel efetuar a busca por noticias ##" + ex.Message);
                        throw;
                    }
                }

            }
        }
    }
}

using API.WebScraping.DTO;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace API.WebScraping
{
    public class WebScraping
    {
        public List<NoticiaDTO> BuscarNoticias()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            var dataAtual = DateTime.Now;
            HtmlDocument htmlDocument = htmlWeb.Load($"https://www.curitiba.pr.gov.br/busca/?filtro=2&inicio=01-01-2017&final={dataAtual}");

            var listaNoticias = new List<NoticiaDTO>();
            var tituloNode = htmlDocument.DocumentNode.SelectNodes("//div[@class='tituloDescricao']/h2");
            var descricaoNoticiaNode = htmlDocument.DocumentNode.SelectNodes("//div[@class='tituloDescricao']/p");

            for (int i = 0; i < 5; i++)
            {
                var noticia = new NoticiaDTO
                {
                    Titulo = tituloNode[i].InnerText.Trim(),
                    Descricao = descricaoNoticiaNode[i].InnerText.Trim()
                };
                listaNoticias.Add(noticia);
            }

            return listaNoticias;
        }
    }
}

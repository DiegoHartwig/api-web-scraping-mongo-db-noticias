namespace API.WebScraping.DTO
{
    public class NoticiaDTO
    {
        public NoticiaDTO() { }

        public NoticiaDTO(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}

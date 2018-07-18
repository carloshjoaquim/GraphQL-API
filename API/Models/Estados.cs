namespace API.Models
{
    public class EstadosRoot
    {
        public Estado[] Estados { get; set; }
    }

    public class Estado
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string[] Cidades { get; set; }
    }
}

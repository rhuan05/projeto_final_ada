using System.Globalization;

namespace projeto_modulo4
{
    public class Eventos
    {
        public int IdEvento { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public string Endereco { get; set; }
        public double Preco { get; set; }
        public bool Status { get; set; }
    }
}
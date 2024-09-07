namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(int numero, string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Numero = numero;
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public int Numero { get; set; }
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}
namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            // Modificação de mdlpontual: Garante que a capacidade seja no mínimo 1, permitindo criar a reserva com um titular.
            Capacidade = capacidade <= 0 ? throw new ArgumentException("Número de hóspedes não pode ser menor do que 1.") : capacidade;
            TipoSuite = tipoSuite;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}
namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        private int _capacidade;
        public string TipoSuite { get; set; }
        public int Capacidade
        {
            get => _capacidade; set

            {
                if (value <= 0) throw new Exception("A capacidade não deve ser menor que 1");

                _capacidade = value;
            }
        }
        public decimal ValorDiaria { get; set; }
    }
}
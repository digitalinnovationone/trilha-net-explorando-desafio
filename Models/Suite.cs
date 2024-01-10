namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        private string _tipoSuite;
        private int _capacidade;
        private decimal _valorDiaria;

        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
       

        public string TipoSuite
        {
            get => _tipoSuite;
            set
            {
                // Validar se o tipo da suite não é nulo ou vazio
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O tipo da suíte não pode ser nulo ou vazio.");
                }
                _tipoSuite = value;
            }
        }

        public int Capacidade
        {
            get => _capacidade;
            set
            {
                // Validar se a capacidade é um número positivo
                if (value <= 0)
                {
                    throw new ArgumentException("A capacidade da suíte deve ser um número positivo.");
                }
                _capacidade = value;
            }
        }

        public decimal ValorDiaria
        {
            get => _valorDiaria;
            set
            {
                // Validar se o valor da diária é um número positivo
                if (value <= 0)
                {
                    throw new ArgumentException("O valor da diária deve ser um número positivo.");
                }
                _valorDiaria = value;
            }
        }
    }
}

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            Hospedes = new List<Pessoa>();
            Suite = new Suite();
        }

        public Reserva(int diasReservados) : this()
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            try
            {
                if (Suite.Capacidade < hospedes.Count)
                {
                    throw new InvalidOperationException("O número de hóspedes excedeu a capacidade máxima.");
                }
                else
                {
                    Hospedes = hospedes;
                    Console.WriteLine("Hospedes cadastrados com sucesso!");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro ao cadastrar hóspedes: {ex.Message}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }


        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valorDiaria = Suite.ValorDiaria;
            decimal valorTotal = DiasReservados * valorDiaria;

            if (DiasReservados >= 10)
            {
                valorTotal *= 0.90m; 
            }

            return valorTotal;
        }
    }

}

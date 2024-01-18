namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Hospedes.Capacity >= hospedes.Capacity)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade é menor que o número de hóspedes recebido.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            foreach(var hospede in Hospedes){
                Console.WriteLine(hospede);
            }
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            int TenDays = 10;
            if (DiasReservados >= TenDays)
            {
                valor *= 0.90M;
            }

            return valor;
        }
    }
}
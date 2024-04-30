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
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Essa suite não comporta essa quantidade de hospedes!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            var qtdHospedes = this.Hospedes.Count;

            return qtdHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            decimal totalPagar = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                totalPagar = totalPagar * 0.9M;
            }

            return totalPagar;
        }
    }
}
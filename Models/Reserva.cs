namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public int DiasReservados { get; private set; }
        private Suite Suite { get; set; }
        private List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new Exception("Suite não cadastrada na reserva.");
            }

            if (hospedes.Count > Suite.Capacidade)
            {
                throw new Exception($"Capacidade da suíte insuficiente. Capacidade: {Suite.Capacidade}, Hóspedes informados: {hospedes.Count}");
            }

            Hospedes = hospedes;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new Exception("Suite não cadastrada na reserva.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% se a reserva for por 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // desconto de 10%
            }

            return valor;
        }
    }
}
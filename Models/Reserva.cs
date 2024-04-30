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
            var existemVagas = Suite.Capacidade >= hospedes.Count;
            if (existemVagas)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Limite de hospedes por suíte atingido!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if(Hospedes.Count > 0)
            {
                return Hospedes.Count;
            }
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor -= valor * 10 / 100;
            }

            return valor;
        }
    }
}
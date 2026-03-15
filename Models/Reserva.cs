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

            int capacidade = Suite.Capacidade;
            if (capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {

                throw new Exception("A Capacidade da Suite é menor do que o número de hóspedes");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            _ = Hospedes.Count;
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados > 10)
            {
                valor *= 0.10m;
            }

            return valor;
        }
    }
}
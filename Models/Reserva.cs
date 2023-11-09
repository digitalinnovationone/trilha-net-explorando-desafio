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

            if (Suite.Capacidade >= hospedes.Count())
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Exedeu a capacidade de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {

            return Hospedes.Count();
        }

        public decimal CalcularValorDiaria()
        {

            double valor = 0;


            if (DiasReservados > 0)
            {

                valor = DiasReservados * (double)Suite.ValorDiaria;
            }

            return DiasReservados > 10 ? (decimal)(valor - (valor * 0.10)) : (decimal)valor;
        }
    }
}
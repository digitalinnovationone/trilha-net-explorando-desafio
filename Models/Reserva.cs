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

            bool temCapacidade = Suite.Capacidade >= hospedes.Count();

            if (temCapacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception($"A capacidade da suite é de {Suite.Capacidade} pessoas. Não comporta {hospedes.Count()} pessoas.");
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

        public decimal CalcularValorHospedagem()
        {

            decimal valor = 0;

            valor = Suite.ValorDiaria * DiasReservados;

            if (DiasReservados >= 10)
            {
                valor = valor * 0.9M;
            }

            return valor;
        }
    }
}
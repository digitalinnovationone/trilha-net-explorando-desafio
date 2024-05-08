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
                throw new Exception("[ERRO !] Não é possível cadastrar o número de hóspedes selecionados, pois excede a capacidade");
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
            decimal desconto = Suite.ValorDiaria * 0.1M;
            decimal valor = Suite.ValorDiaria - desconto;

            if (DiasReservados >= 10)
            {
                return valor;
            }
            else
            {
                return (Suite.ValorDiaria * DiasReservados);
            }
        }
    }
}
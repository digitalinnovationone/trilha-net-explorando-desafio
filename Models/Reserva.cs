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
            // Verificar se a quantidade de hóspedes não ultrapassa a capacidade da suíte
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Se ultrapassar a capacidade, lança uma exceção
                throw new Exception("Quantidade de hóspedes maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes cadastrados
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total da reserva
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Se a reserva for de 10 dias ou mais, aplica 10% de desconto
            if (DiasReservados >= 10)
            {
                valor *= 0.90M; // aplica desconto de 10%
            }

            return valor;
        }
    }
}

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
            // Verifica se a capacidade da suíte é suficiente para o número de hóspedes
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException("A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }
            //Cadastra os hospedes
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes cadastrados
            return Hospedes != null ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total da diária
            if (Suite == null)
                throw new InvalidOperationException("Suite não cadastrada.");

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% para reservas de 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;
        }
    }
}
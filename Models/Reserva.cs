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
            // Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes
            if (Suite != null && Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lançar uma exceção caso a capacidade seja insuficiente
                throw new InvalidOperationException("A capacidade da suíte é menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes cadastrados
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Verificar se a suíte foi cadastrada
            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte foi cadastrada.");
            }

            // Calcular o valor total da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplicar desconto de 10% se os dias reservados forem 10 ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica o desconto de 10%
            }

            return valor;
        }
    }
}
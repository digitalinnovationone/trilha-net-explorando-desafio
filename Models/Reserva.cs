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
            if (diasReservados <= 0)
            {
                throw new ArgumentException("O número de dias reservados deve ser maior que zero.");
            }

            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte cadastrada. Cadastre uma suíte antes de adicionar hóspedes.");
            }

            if (hospedes == null || hospedes.Count == 0)
            {
                throw new ArgumentException("A lista de hóspedes não pode ser nula ou vazia.");
            }

            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new InvalidOperationException($"A capacidade da suíte é menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentNullException(nameof(suite), "A suíte não pode ser nula.");
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte cadastrada. Cadastre uma suíte para calcular o valor.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor *= 0.90M; // Aplicar 10% de desconto
            }

            return valor;
        }
    }
}
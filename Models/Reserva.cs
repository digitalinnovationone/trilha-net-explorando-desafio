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

            if (hospedes == null)
            {
                throw new ArgumentNullException(nameof(hospedes));
            }

            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido

            int qtdeHospedes = hospedes.Count;
            int capacidade = Suite?.Capacidade ?? 0;

            if (qtdeHospedes > capacidade)
            {
                throw new InvalidOperationException("A capacidade da suíte é menor que o número de hóspedes.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria

            var valor = DiasReservados * Suite.ValorDiaria;


            if (DiasReservados >= 10)
            {
                decimal desconto = 0.10M * valor;
                valor -= desconto;
            }


            return valor;
        }
    }
}
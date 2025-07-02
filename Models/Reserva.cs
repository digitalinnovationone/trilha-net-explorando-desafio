namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa>? Hospedes { get; set; }
        public Suite? Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            this.DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de adicionar hóspedes.");
            }

            if (hospedes.Count <= Suite.Capacidade)
                Hospedes = hospedes;
            else
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new InvalidOperationException("A quantidade de hóspedes não pode exceder a capacidade da suíte.");
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte não foi cadastrada.");
            }

            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (this.DiasReservados >= 10)
            {
                valorTotal *= 0.90m; // Aplica 10% de desconto
            }

            return valorTotal;
        }
    }
}

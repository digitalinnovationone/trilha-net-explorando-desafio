namespace DesafioProjetoHospedagem.Models
{
    using System.Globalization;
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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*

            if (Suite == null) throw new InvalidOperationException("Nenhuma suíte foi associada à reserva.");

            if (hospedes.Count > Suite.Capacidade)
            {
                throw new InvalidOperationException("A capacidade de hospedes é maior do que a quantidade de quartos disponíveis");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            int quantidadeHospedes = Hospedes.Count;
            return quantidadeHospedes;
        }

        public decimal CalcularValorDiariaTotal()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            if (Suite == null) throw new InvalidOperationException("Nenhuma suíte foi associada à reserva.");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            decimal total = Suite.ValorDiaria * DiasReservados;

            if (DiasReservados >= 10)
            {
                total -= total * 0.10M;
            }
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            return total;
        }
    }
}
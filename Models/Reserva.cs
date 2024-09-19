namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite SuiteReservada { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // CONTAGEM DE HOSPEDES VS CAPACIDADE DA SUITE
            if (hospedes.Count <= SuiteReservada.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new Exception("Número de hóspedes excede a capacidade da suíte");
            }
        }

        // Método para cadastrar a suíte
    public void CadastrarSuite(Suite suite)
    {
        SuiteReservada = suite;
    }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // RETORNA A QUANTIDADE DE HOSPEDES
            return Hospedes.Count;
        }

        public decimal CalcularValorTotal()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valorTotal = DiasReservados * SuiteReservada.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados > 10)
            {
                valorTotal -= valorTotal * 0.10M;
            }

            return valorTotal;
        }
    }
}
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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            try
            {
                var capacidade = Suite.Capacidade;
                var qtdHospedes = hospedes.Count;

                if (qtdHospedes <= capacidade)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    throw new Exception($"A suíte não comporta {qtdHospedes} hóspedes.");
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            var qtdHospedes = Hospedes.Count;

            return qtdHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                double aux = 10.0/100;
                var total = Convert.ToDouble(valor) - (aux * Convert.ToDouble(valor));
                return Convert.ToDecimal(total);
            }
            return 0;
        }
    }
}
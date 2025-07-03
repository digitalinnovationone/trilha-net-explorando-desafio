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
    // Verifica se a lista de hóspedes é nula
    if (hospedes == null)
        throw new ArgumentNullException(nameof(hospedes), "A lista de hóspedes não pode ser nula.");

    // Verifica se a capacidade da suíte é suficiente
    if (hospedes.Count > Suite.Capacidade)
    {
        throw new ArgumentException(
            $"A suíte suporta até {Suite.Capacidade} hóspedes, mas foram recebidos {hospedes.Count}.",
            nameof(hospedes)
        );
    }

    // Se passou nas validações, atribui a lista
    Hospedes = hospedes;
}

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO:(FEITO) Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor *= Convert.ToDecimal(0.90);
            }    



            return valor;
        }
    }
}
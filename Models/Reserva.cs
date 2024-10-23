namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes? { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        public int ValorDesconto {get; set;}

    public Reserva() { }
   {

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            ValorDesconto = 1;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (hospedes.Count > Hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new Exception ("O número de hóspedes é maior do que o quarto pode comportar ")
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
        if (hospedes != null)
        {
            return hospedes.Count();
        }    
            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = Suite.ValorDiaria * DiasReservados;
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >=10)
            {
                 valor *= valorDesconto;
            }

            return valor;
        }
    }
}
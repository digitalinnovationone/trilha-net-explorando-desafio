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
            if (hospedes.Count<=Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(hospedes));
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        } 



        public int ObterQuantidadeHospedes()
        {
            if (!Hospedes.Any())
            {
                return 0;
            }
            else
            {
                return Hospedes.Count;
            }
               
        }

        public decimal CalcularValorTotalDiarias()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valorSemDesconto = 0;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            valorSemDesconto = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados>=10)
            {
                decimal ValorCom10 = valorSemDesconto - (valorSemDesconto * 0.10);

                return ValorCom10;
            } 
            else
            {
                return valorSemDesconto;
            }    
        }
}
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
            // Implementado
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Implementado
                throw new Exception("O número de hóspedes é maior que a capacidade do hotel");
                
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Implementado
            return Hospedes.Count();
        }
        public decimal CalcularValorDiaria()
        {
            // Implementado
            decimal valor = 0;
            decimal percentual = Convert.ToDecimal(10) / Convert.ToDecimal(100);
            valor = DiasReservados * Suite.ValorDiaria;
 
            // Implementado
            if (DiasReservados >= 10)
            {
                valor = valor - (valor * percentual);
            }

            return valor;
        }
    }
}
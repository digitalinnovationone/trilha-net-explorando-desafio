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
            
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                 throw new ArgumentException("A capacidade é insuficiente para o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        { 
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            
            decimal valor = 0;
            
            if (DiasReservados >= 10)
            {
                valor = DiasReservados * Suite.ValorDiaria * 0.9m;
            }
            else
            {
                valor = DiasReservados * Suite.ValorDiaria;
            }

            return valor;
        }
    }
}
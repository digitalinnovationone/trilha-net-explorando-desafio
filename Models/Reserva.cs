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
          
            if (Suite.Capacidade >= hospedes.Count )
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A capacidade de Hospedes é maior que o comportado");
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
         
            decimal valor = DiasReservados * Suite.Capacidade;

                        
            if (DiasReservados >= 10)
            {
                valor = 0.90M;
            }

            return valor;
        }
    }
}
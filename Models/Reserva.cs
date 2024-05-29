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
         
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A capacidade da suite é menor que o número de hóspedes recebidos.");
              
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
        
            Hospedes.Count();  

            return Hospedes.Count();
        }

        public decimal CalcularValorDiaria()
        {
            
            decimal valor = 0;
            valor = DiasReservados * Suite.ValorDiaria;

            
            if (DiasReservados >= 10)
            {
                valor = valor * 0.9m;
            }

            return valor;
        }
    }
}
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
            //IMPLEMENTADO!
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            //IMPLEMENTADO!
            {
                try{
                    throw new Exception("A capacidade da suíte é menor que o número de hóspedes.");
                }
                catch(Exception ex){
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // IMPLEMENTADO!
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            return 0;
    


      
            
        }

        public decimal CalcularValorDiaria()
        {
            // IMPLEMENTADO! 
            if (Suite.ValorDiaria <= 0)
            {
                return 0;
            }
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor = (DiasReservados * Suite.ValorDiaria) * 0.9M;

                
            }

            return valor;
        }
    }
}
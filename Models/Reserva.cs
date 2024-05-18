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
            // *IMPLEMENTADO*
            if (hospedes != null && Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // *IMPLEMENTADO*
                if(hospedes == null)
                    throw new Exception("Não foram informados os hóspedes");
                else if (Suite == null)
                    throw new Exception("Suíte não foi informada");
                else
                    throw new Exception("Número de hóspedes maior que a capacidade do Suíte");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // *IMPLEMENTADO*
            if (Hospedes != null)
                return Hospedes.Count;

            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // *IMPLEMENTADO*
            decimal valor = DiasReservados * Suite.Capacidade;

            // *IMPLEMENTADO*
            if (DiasReservados >= 10)
            {
                valor *= 0.9M;
            }

            return valor;
        }
    }
}
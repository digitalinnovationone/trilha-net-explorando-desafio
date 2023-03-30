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
            if (Suite.Capacidade < hospedes.Count)
                throw new ArgumentException("A capacidade da suíte é menor que a quantidade de hóspedes");

            hospedes.Add(new Pessoa(hospedes));
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }
        
        public int ObterQuantidadeHospedes(List<Pessoa> hospedes)
        {
            return hospedes.Count - 1;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                return DiasReservados >= 10 ? valor * 0.9m : valor;
            }

            return valor;
        }
    }
}
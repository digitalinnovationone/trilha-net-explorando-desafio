namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            DiasReservados = 1;
        }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new Exception("Suite não cadastrada.");
            }

            if (hospedes.Count > Suite.Capacidade)
            {
                throw new Exception("Número de hóspedes excede a capacidade da suíte.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new Exception("Suite não cadastrada.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria; 
            return DiasReservados >= 10
                ? valor * 0.9M
                : valor;
        }
    }
}
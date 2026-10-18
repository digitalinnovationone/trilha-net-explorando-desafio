namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; private set; } = new();
        public Suite Suite { get; private set; }
        public int DiasReservados { get; set; }

        public Reserva(int diasReservados)
        {
            if (diasReservados <= 0)
                throw new ArgumentException("Dias reservados deve ser maior que zero.");
            
            DiasReservados = diasReservados;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentNullException(nameof(suite));
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
                throw new InvalidOperationException("Cadastre a suíte antes dos hóspedes.");
            
            if (hospedes.Count > Suite.Capacidade)
                throw new InvalidOperationException(
                    $"Capacidade da suíte ({Suite.Capacidade}) é menor que o número de hóspedes ({hospedes.Count}).");

            Hospedes = hospedes;
        }

        public int ObterQuantidadeHospedes() => Hospedes?.Count ?? 0;

        public decimal CalcularValorDiaria()
        {
            var valor = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
                valor *= 0.9m;

            return valor;
        }
    }
}
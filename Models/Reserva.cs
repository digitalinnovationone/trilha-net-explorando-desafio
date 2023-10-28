namespace Hotelaria.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados) {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes) {
            if (Suite.Capacidade >= hospedes.Count) {
                Hospedes = hospedes;
            } else {
                throw new Exception("O número de hospedes não pode exceder a capacidade da Suite.");
            }
        }

        public void CadastrarSuite(Suite suite) {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes() {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria() {
            decimal valor = Suite.ValorDiaria;
            if (this.DiasReservados >= 10) {
                valor = valor - (valor/100 * 10);
            }
            valor *= this.DiasReservados;
            return Math.Round(valor, 2);
        }
    }
}
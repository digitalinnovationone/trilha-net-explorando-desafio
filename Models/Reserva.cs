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
            if ((hospedes.Count <= Suite.Capacidade))
            {
                Hospedes = hospedes;
            }
            else
            {
                  throw new Exception("Hóspede não permitido, ultrapassa a capacidade da Suíte!");
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
            valor = Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                valor = valor * 0.9m;
            }

            return valor;
        }
    }
}
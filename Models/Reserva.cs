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

        //Desafio Concluído
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("A quantidade de hóspedes não pode exceder a capacidade da suite!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        //Desafio Concluído
        public int ObterQuantidadeHospedes()
        {
            int quantidade = Hospedes.Count;

            return quantidade;
        }

        //Desafio Concluído
        public decimal CalcularValorDiaria()
        {
            decimal valor;
            decimal desconto = 0.1M;

            if (DiasReservados < 10)
            {
                valor = DiasReservados * Suite.ValorDiaria;
            }
            else
            {
                valor = DiasReservados * Suite.ValorDiaria * desconto;
                Console.WriteLine($"Desconto de 10% do valor pelos {DiasReservados} dias.");
            }

            return valor;
        }
    }
}
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
            int quantidadePessoas = hospedes.Count();
            int capacidadeSuite = Suite.Capacidade;

            if (quantidadePessoas <= capacidadeSuite)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("Quantidade de pessoas não suportada pela capacidade da suíte.");
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
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor = valor - (valor * 0.1M);
            }

            return valor;
        }
    }
}
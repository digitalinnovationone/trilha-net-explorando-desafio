namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            Hospedes = new List<Pessoa>();
        }

        public Reserva(int diasReservados) : this()
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite is null)
            {
                throw new Exception("A suite ainda não foi implementada!");
            }

            int capacidadeSuite = Suite.Capacidade;
            int qtdHospedesJaCadastrados = Hospedes.Count;
            int qtdHospedesParaCadastradar = hospedes.Count;

            if (qtdHospedesJaCadastrados == capacidadeSuite)
            {
                throw new Exception("A suite não suporta mais hospedes!");
            }

            int totalHospedes = qtdHospedesJaCadastrados + qtdHospedesParaCadastradar;

            if (totalHospedes > capacidadeSuite)
            {
                throw new Exception("A suite não suporta todos os hospedes desejados!");
            }

            Hospedes.AddRange(hospedes);
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorHospedagem()
        {
            decimal valor = (DiasReservados * Suite.ValorDiaria);

            if (DiasReservados >= 10)
            {
                valor = (valor * 0.90m);
            }

            return valor;
        }
    }
}
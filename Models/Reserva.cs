using System.Text;

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
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
                //Console.WriteLine("Cadastrou hóspedes!");
            }
            else
                throw new Exception("A quantidade de hóspedes não pode ser maior que a capacidade da suíte!");
            
        }

        public string ListarHospedes()
        {
           StringBuilder listaDeHospedes = new StringBuilder();

           foreach (Pessoa pessoa in Hospedes)
           {
              listaDeHospedes.Append(pessoa.Nome);
              listaDeHospedes.Append(" | ");
           }
           if (Hospedes.Count > 0)
            listaDeHospedes.Remove(listaDeHospedes.Length - 2, 2);
           
           return listaDeHospedes.ToString();
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int qtdHospedes = Hospedes.Count;
            return qtdHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = (DiasReservados * Suite.ValorDiaria);
            if (DiasReservados >= 10)
            {
                valor = valor * 0.90M;
            }
            return valor;
        }
    }
}
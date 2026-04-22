using System.Runtime.ExceptionServices;

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

        public void CadastrarHospedes()
        {
            System.Console.WriteLine("Cadastrando hóspedes :");
            
            List<Pessoa> hospedes = new List<Pessoa>();

            
            do{
                System.Console.WriteLine($"Hóspede {hospedes.Count+1}");
                Pessoa pessoa = new Pessoa();
                pessoa.RecebePessoa();
                hospedes.Add(pessoa);
                System.Console.WriteLine("Digite X para parar : ");
            }while (Console.ReadLine().ToUpper() != "X"  &&  hospedes.Count < Suite.Capacidade);
            

            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                System.Console.WriteLine("Número de hóspedes maior que a capacidade da suite.");
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
                valor = valor*9/10;
            }

            return valor;
        }

        public void MostrarReserva()
        {
            System.Console.WriteLine($"Tipo da suite : {Suite.TipoSuite}");
            System.Console.WriteLine($"{DiasReservados} dias foram reservados.");
            int i=1;
            foreach (var pessoa in Hospedes)
            {
                System.Console.WriteLine($"{i}o hóspede : " + pessoa.NomeCompleto);
                i++;
            }
            System.Console.WriteLine($"E o valor total foi de {CalcularValorDiaria().ToString("C")}.");
        }
    }
}
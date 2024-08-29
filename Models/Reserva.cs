using System.Runtime.ConstrainedExecution;

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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            bool limiteDeCapacidade;
            limiteDeCapacidade = Suite.Capacidade >= hospedes.Count;
            Console.WriteLine($"A Suíte comporta a quantidade de hóspedes que chegaram: " + (limiteDeCapacidade ? "Sim" : "Não"));
            
            if (limiteDeCapacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                try 
                {
                    throw new ArithmeticException("Ação Negada -- Quantidade de Hóspedes acima da Capacidade da Suíte ");
                }
                catch(ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }   
            }
        }
        public void AdicionarHospedes(List<Pessoa> hospede)
        {
            Console.WriteLine("Qual é a quantidade dos hóspedes:");
            // List<string> quantidadeDeHospedes = cliente.ListaDeHospedes;
            // quantidadeDeHospedes.Capacity = Convert.ToInt32(Console.ReadLine());
            int quantidade = Convert.ToInt32(Console.ReadLine());

            
            for(int i = 0; i < quantidade; i++)
            {
                Console.Clear();

                Console.WriteLine("Digite o nome primeiro e depois o sobrenome do hóspede");
                Pessoa nome = new Pessoa(nome: Console.ReadLine(), sobrenome: Console.ReadLine());
                Hospedes = hospede;
                hospede.Add(nome);
            }    
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            int quantidadeDeHospede = 0;
            List<Pessoa> hospedes = Hospedes;

            try
            {
                quantidadeDeHospede = hospedes.Count;
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Não há nenhum hóspede cadastrado\n");
            }
            catch(Exception)
            {
                Console.WriteLine("Erro Génerico na verificação da quantidade\n");
            }

            return quantidadeDeHospede;
        }
  
        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            bool desconto;
            desconto = DiasReservados >= 10;

            if (desconto)
            {
                valor -= DiasReservados * Suite.ValorDiaria * 0.1M ;
            }

            return valor;
        }
    }
}
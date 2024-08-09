namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(int id, string tipoSuite, int capacidade, decimal valorDiaria)
        {
            Id = id;
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
        public int Id { get; set; }
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public string GerarDescricaoSuite()
        {
            return $@"
        Suite n°{Id}: {TipoSuite}
        Valor da Diária: {ValorDiaria:C}
        Capacidade: {Capacidade}
        ";
        }
        public static Suite CadastrarSuite()
        {
            int id;
            string tipoSuite;
            int capacidade;
            decimal valorDiaria;


            Console.Write("Digite o ID da suíte: ");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID inválido. Por favor, digite um número inteiro positivo.");
                Console.Write("Digite o ID da suíte: ");
            }

            Console.Write("Digite o tipo da suíte: ");
            tipoSuite = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(tipoSuite))
            {
                Console.WriteLine("Tipo da suíte não pode ser vazio.");
                Console.Write("Digite o tipo da suíte: ");
                tipoSuite = Console.ReadLine();
            }


            Console.Write("Digite a capacidade da suíte: ");
            while (!int.TryParse(Console.ReadLine(), out capacidade) || capacidade <= 0)
            {
                Console.WriteLine("Capacidade inválida. Por favor, digite um número inteiro positivo.");
                Console.Write("Digite a capacidade da suíte: ");
            }


            Console.Write("Digite o valor da diária: ");
            while (!decimal.TryParse(Console.ReadLine(), out valorDiaria) || valorDiaria <= 0)
            {
                Console.WriteLine("Valor inválido. Por favor, digite um número decimal positivo.");
                Console.Write("Digite o valor da diária: ");
            }
            return new Suite(id, tipoSuite, capacidade, valorDiaria);
        }
    }


}
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;


Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);


Reserva reserva = new Reserva(diasReservados: 1);
reserva.CadastrarSuite(suite);

List<Pessoa> hospedes = new List<Pessoa>();

// Loop principal do menu do programa
while (true)
{
    Console.WriteLine("\n--- Menu ---");
    Console.WriteLine("1 - Cadastrar hóspedes");
    Console.WriteLine("2 - Definir dias de diária");
    Console.WriteLine("3 - Exibir informações da reserva");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    // Opção para cadastrar hóspedes
    if (opcao == "1")
    {
        hospedes.Clear();
        Console.Write("Quantos hóspedes deseja cadastrar? ");
        if (int.TryParse(Console.ReadLine(), out int qtd))
        {
            // Solicita o nome de cada hóspede
            for (int i = 1; i <= qtd; i++)
            {
                Console.Write($"Nome do hóspede {i}: ");
                string nome = Console.ReadLine();
                hospedes.Add(new Pessoa(nome));
            }
            // Cadastra os hóspedes na reserva
            reserva.CadastrarHospedes(hospedes);
            Console.WriteLine("Hóspedes cadastrados com sucesso!");
        }
        else
        {
            Console.WriteLine("Quantidade inválida.");
        }
    }
    // Opção para definir a quantidade de dias da diária
    else if (opcao == "2")
    {
        Console.Write("Quantos dias de diária? ");
        if (int.TryParse(Console.ReadLine(), out int dias))
        {
            reserva.DiasReservados = dias;
            Console.WriteLine("Dias de diária atualizados!");
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }
    }
    // Opção para exibir informações da reserva
    else if (opcao == "3")
    {
        Console.WriteLine($"\nHóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor total da diária: {reserva.CalcularValorDiaria()}");
    }
    else if (opcao == "0")
    {
        Console.WriteLine("Saindo...");
        break;
    }
    else
    {
        Console.WriteLine("Opção inválida.");
    }
}
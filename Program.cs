using System.Text;
using DesafioProjetoHospedagem.Models;
using System.Globalization;

Console.OutputEncoding = Encoding.UTF8;
Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");


List<Pessoa> hospedes = new();
Suite? suite = null;
Reserva? reserva = null;

Menu(); 

void Menu()
{
    bool continuar = true;

    while (continuar)
    {
        Console.Clear();
        Console.WriteLine("Seja bem-vindo ao sistema de hospedagem do hotel.\nDigite uma opção:");
        Console.WriteLine("1 - Cadastrar hóspedes");
        Console.WriteLine("2 - Cadastrar suíte");
        Console.WriteLine("3 - Criar reserva");
        Console.WriteLine("4 - Encerrar");

        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            // Cria os modelos de hóspedes e cadastra na lista de hóspedes
            case "1":
                Console.Clear();
                CadastrarHospedes(hospedes);
                break;

            // Cria a suíte
            case "2":
                Console.Clear();
                suite = CadastrarSuite();
                break;

            // Cria uma nova reserva, passando a suíte e os hóspedes
            case "3":
                Console.Clear();
                CriarReserva(suite, hospedes, out reserva);
                break;

            case "4":
                continuar = false;
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }

        Console.WriteLine("Pressione uma tecla para continuar...");
        Console.ReadLine();
    }
}

static void CadastrarHospedes(List<Pessoa> hospedes)
{
    Console.Write("Quantos hóspedes deseja cadastrar? ");
    if (!int.TryParse(Console.ReadLine(), out int numeroHospedes))
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    for (int i = 1; i <= numeroHospedes; i++)
    {
        Console.WriteLine($"Hóspede {i}:");

        string nome = LerTexto("  Nome: ", "  Nome inválido. Digite apenas letras.");
        string sobrenome = LerTexto("  Sobrenome: ", "  Sobrenome inválido. Digite apenas letras.");

        hospedes.Add(new Pessoa(nome, sobrenome));
    }

    Console.WriteLine("Hóspedes cadastrados com sucesso!");
}

static Suite CadastrarSuite()
{
    Console.Write("Insira o tipo da suíte: ");
    string? tipo = Console.ReadLine();

    int capacidade = LerNumeroInteiro("Qual é a capacidade da suíte? ", "Capacidade inválida. Digite um número inteiro positivo.");
    decimal valorDiaria = LerNumeroDecimal("Qual é o valor da diária: ", "Valor inválido. Digite um valor decimal positivo.");

    Console.WriteLine("Suíte cadastrada com sucesso!");
    return new Suite(tipo ?? "Padrão", capacidade, valorDiaria);
}

static void CriarReserva(Suite? suite, List<Pessoa> hospedes, out Reserva? reserva)
{
    reserva = null;

    if (suite == null)
    {
        Console.WriteLine("Suíte não cadastrada. Cadastre a suíte primeiro.");
        return;
    }

    if (hospedes.Count == 0)
    {
        Console.WriteLine("Nenhum hóspede cadastrado. Cadastre hóspedes primeiro.");
        return;
    }

    Console.Write("Quantos dias de reserva? ");
    if (!int.TryParse(Console.ReadLine(), out int dias))
    {
        Console.WriteLine("Número inválido de dias.");
        return;
    }

    try
    {
        reserva = new Reserva(dias);
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine("Reserva criada com sucesso!");
        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria():C}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Erro ao cadastrar hóspedes: {ex.Message}");
    }
}

static string LerTexto(string prompt, string mensagemErro)
{
    string? input;
    while (true)
    {
        Console.Write(prompt);
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
            return input;
        Console.WriteLine(mensagemErro);
    }
}

static int LerNumeroInteiro(string prompt, string mensagemErro)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0)
            return valor;
        Console.WriteLine(mensagemErro);
    }
}

static decimal LerNumeroDecimal(string prompt, string mensagemErro)
{
    while (true)
    {
        Console.Write(prompt);
        if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
            return valor;
        Console.WriteLine(mensagemErro);
    }
}
namespace DesafioProjetoHospedagem.Utils;

public static class InputUtils
{
    public static int LerInt(string mensagem)
    {
        while (true)
        {
            Console.WriteLine(mensagem);
            if (int.TryParse(Console.ReadLine(), out int valor))
                return valor;

            ConsoleUtils.EscreverLentamente("Valor inválido. Digite novamente.");
            Console.Clear();
        }
    }

    public static decimal LerDecimal(string mensagem)
    {
        while (true)
        {
            Console.WriteLine(mensagem);
            if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                return valor;

            ConsoleUtils.EscreverLentamente("Valor inválido. Digite novamente.");
            Console.Clear();
        }
    }

    public static string LerString(string mensagem, bool obrigatorio = true, bool semNumero = false)
    {
        while (true)
        {
            Console.WriteLine(mensagem);
            string input = Console.ReadLine()?.Trim();

            if ((obrigatorio || !string.IsNullOrEmpty(input)) && semNumero && input.Any(char.IsDigit))
            {
                ConsoleUtils.EscreverLentamente("Não é permitido números.");
                Console.Clear();
                continue;
            }

            if (!obrigatorio || !string.IsNullOrEmpty(input))
                return input ?? string.Empty;

            ConsoleUtils.EscreverLentamente("Entrada inválida. Por favor, digite um valor válido.");
            Console.Clear();
        }
    }

    public static bool Confirmar(string mensagem)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine(mensagem + " (S/N)");
            string input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "S") return true;
            if (input == "N") return false;

            ConsoleUtils.EscreverLentamente("Entrada inválida. Digite 'S' para sim ou 'N' para não.");
            Console.Clear();
        }
    }

    public static string SelecionarTipoSuite()
    {
        int escolha;
        bool condition = false;
        Console.Clear();

        do
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║           Tipos de Suíte             ║");
            Console.WriteLine("╠═══════════╦═══════════╦══════════════╣");
            Console.WriteLine("║ Tipo      ║ Capacidade║ Valor Diária ║");
            Console.WriteLine("╠═══════════╬═══════════╬══════════════╣");
            Console.WriteLine("║ 1. Básico ║ 2 pessoas ║ R$ 100,00    ║");
            Console.WriteLine("║ 2. Médio  ║ 4 pessoas ║ R$ 300,00    ║");
            Console.WriteLine("║ 3. Luxo   ║ 6 pessoas ║ R$ 500,00    ║");
            Console.WriteLine("╚═══════════╩═══════════╩══════════════╝");
            Console.WriteLine("Selecione o tipo da suíte (1-3):");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out escolha) && escolha >= 1 && escolha <= 3)
            {
                condition = true;
            }
            else
            {
                ConsoleUtils.EscreverLentamente("Escolha inválida. Digite um número entre 1 e 3.");
                Console.Clear();
            }
        } while (!condition);

        return escolha switch
        {
            1 => "BÁSICO",
            2 => "MÉDIO",
            3 => "LUXO",
            _ => throw new InvalidOperationException()
        };
    }
}
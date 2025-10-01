using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new();
Suite suite = null;
Reserva reserva = null;

bool executando = true;

while (executando)
{
    Console.Clear();
    Console.WriteLine("===== SISTEMA DE HOSPEDAGEM =====");
    Console.WriteLine("1 - Cadastrar suíte");
    Console.WriteLine("2 - Cadastrar reserva");
    Console.WriteLine("3 - Cadastrar hóspedes");
    Console.WriteLine("4 - Exibir quantidade de hóspedes");
    Console.WriteLine("5 - Calcular valor da diária");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                Console.Write("Informe o tipo da suíte: ");
                string tipo = Console.ReadLine();

                Console.Write("Informe a capacidade da suíte: ");
                int capacidade = int.Parse(Console.ReadLine());

                Console.Write("Informe o valor da diária: ");
                decimal valor = decimal.Parse(Console.ReadLine());

                suite = new Suite(tipo, capacidade, valor);
                Console.WriteLine("Suíte cadastrada com sucesso!");
                break;

            case "2":
                if (suite == null)
                {
                    Console.WriteLine("⚠️ Cadastre uma suíte antes da reserva!");
                }
                else
                {
                    Console.Write("Informe a quantidade de dias reservados: ");
                    int dias = int.Parse(Console.ReadLine());

                    reserva = new Reserva(dias);
                    reserva.CadastrarSuite(suite);

                    Console.WriteLine("Reserva cadastrada com sucesso!");
                }
                break;

            case "3":
                if (reserva == null)
                {
                    Console.WriteLine("⚠️ Cadastre a reserva antes de adicionar hóspedes!");
                }
                else
                {
                    hospedes.Clear();

                    Console.Write("Informe a quantidade de hóspedes: ");
                    int qtd = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= qtd; i++)
                    {
                        Console.Write($"Nome do hóspede {i}: ");
                        string nome = Console.ReadLine();

                        Console.Write($"Sobrenome do hóspede {i} (opcional): ");
                        string sobrenome = Console.ReadLine();

                        hospedes.Add(new Pessoa(nome, sobrenome));
                    }

                    reserva.CadastrarHospedes(hospedes);
                    Console.WriteLine("Hóspedes cadastrados com sucesso!");
                }
                break;

            case "4":
                if (reserva?.Hospedes != null)
                    Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
                else
                    Console.WriteLine("⚠️ Nenhum hóspede cadastrado ainda.");
                break;

            case "5":
                if (reserva != null)
                    Console.WriteLine($"Valor total da diária: R$ {reserva.CalcularValorDiaria():F2}");
                else
                    Console.WriteLine("⚠️ Nenhuma reserva cadastrada ainda.");
                break;

            case "0":
                executando = false;
                Console.WriteLine("Encerrando o sistema...");
                break;

            default:
                Console.WriteLine("⚠️ Opção inválida. Tente novamente.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }

    Console.WriteLine("\nPressione ENTER para continuar...");
    Console.ReadLine();
}

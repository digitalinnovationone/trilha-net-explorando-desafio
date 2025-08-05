using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;
using Newtonsoft.Json;
using System.IO;

Console.OutputEncoding = Encoding.UTF8;

// ---------------------------------------------------------------
// Exemplo de uso das classes Pessoa, Suite e Reserva. Apresentado pelo Instrutor do curso.
// ---------------------------------------------------------------

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> listaHospede = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

listaHospede.Add(p1);
listaHospede.Add(p2);

// Cria a suíte
Suite suite1 = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva1 = new Reserva(diasReservados: 10);
reserva1.CadastrarSuite(suite1);
reserva1.CadastrarHospedes(listaHospede);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine("----------------------------------------------------");
Console.WriteLine($"Resolução do Desafio de Projeto!");
Console.WriteLine($"Hóspedes: {reserva1.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva1.CalcularValorDiaria().ToString("C2")}");
Console.WriteLine("----------------------------------------------------");

// -------------------------------------------------------------------

// Outra ideia pelo usuário, criar um interface de uso para o usuário interagir com o sistema

Console.WriteLine("\nUm Protótipo de um sistema de reservas de hospedagem!");
Console.WriteLine("----------------------------------------------------");
string arquivosDir = "Arquivos";
string hospedesPath = Path.Combine(arquivosDir, "hospedes.json");
string suitesPath = Path.Combine(arquivosDir, "suites.json");
string reservasPath = Path.Combine(arquivosDir, "reservas.json");

// Garante que a pasta Arquivos existe
if (!Directory.Exists(arquivosDir))
    Directory.CreateDirectory(arquivosDir);

// Carrega dados existentes, se houver
List<Pessoa> hospedes = File.Exists(hospedesPath)
    ? JsonConvert.DeserializeObject<List<Pessoa>>(File.ReadAllText(hospedesPath)) ?? new List<Pessoa>()
    : new List<Pessoa>();

List<Suite> suites = File.Exists(suitesPath)
    ? JsonConvert.DeserializeObject<List<Suite>>(File.ReadAllText(suitesPath)) ?? new List<Suite>()
    : new List<Suite>();

List<Reserva> reservas = File.Exists(reservasPath)
    ? JsonConvert.DeserializeObject<List<Reserva>>(File.ReadAllText(reservasPath)) ?? new List<Reserva>()
    : new List<Reserva>();

Suite suite = null;
Reserva reserva = null;

while (true)
{
    Console.WriteLine("Bem-vindo ao sistema de reservas!");
    Console.WriteLine("1. Cadastrar hóspede");
    Console.WriteLine("2. Cadastrar suíte");
    Console.WriteLine("3. Fazer reserva");
    Console.WriteLine("4. Exibir informações da reserva");
    Console.WriteLine("5. Listar hóspedes cadastrados");
    Console.WriteLine("6. Remover hóspede");
    Console.WriteLine("7. Remover suíte");
    Console.WriteLine("8. Remover reserva");
    Console.WriteLine("9. Listar suítes cadastradas");
    Console.WriteLine("10. Listar reservas feitas");
    Console.WriteLine("11. Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Digite o nome do hóspede: ");
            string nomeHospede = Console.ReadLine();
            Console.Write("Digite o sobrenome do hóspede (opcional): ");
            string sobrenomeHospede = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(sobrenomeHospede))
                hospedes.Add(new Pessoa(nomeHospede, sobrenomeHospede));
            else
                hospedes.Add(new Pessoa(nome: nomeHospede));
            File.WriteAllText(hospedesPath, JsonConvert.SerializeObject(hospedes, Formatting.Indented));
            Console.WriteLine("Hóspede cadastrado com sucesso!");
            break;

        case "2":
            Console.Write("Digite o tipo da suíte: ");
            string tipoSuite = Console.ReadLine();
            Console.Write("Digite a capacidade da suíte: ");
            int capacidade = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor da diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            suite = new Suite(tipoSuite: tipoSuite, capacidade: capacidade, valorDiaria: valorDiaria);
            suites.Add(suite);
            File.WriteAllText(suitesPath, JsonConvert.SerializeObject(suites, Formatting.Indented));
            Console.WriteLine("Suíte cadastrada com sucesso!");
            break;

        case "3":
            if (suite == null || hospedes.Count == 0)
            {
                Console.WriteLine("É necessário cadastrar uma suíte e pelo menos um hóspede antes de fazer uma reserva.");
                break;
            }
            Console.Write("Digite a quantidade de dias reservados: ");
            int diasReservados = int.Parse(Console.ReadLine());
            reserva = new Reserva(diasReservados: diasReservados);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);
            reservas.Add(reserva);
            File.WriteAllText(reservasPath, JsonConvert.SerializeObject(reservas, Formatting.Indented));
            Console.WriteLine("Reserva realizada com sucesso!");
            break;

        case "4":
            if (reserva == null)
            {
                Console.WriteLine("Nenhuma reserva foi feita ainda.");
                break;
            }
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria().ToString("C2")}");
            break;

        case "5":
            if (hospedes.Count == 0)
            {
                Console.WriteLine("Nenhum hóspede cadastrado.");
            }
            else
            {
                Console.WriteLine("Hóspedes cadastrados:");
                foreach (var h in hospedes)
                {
                    Console.WriteLine($"- {h.Nome}");
                }
            }
            break;

        case "6":
            if (hospedes.Count == 0)
            {
                Console.WriteLine("Nenhum hóspede cadastrado.");
                break;
            }
            Console.WriteLine("Selecione o hóspede para remover:");
            for (int i = 0; i < hospedes.Count; i++)
                Console.WriteLine($"{i + 1}. {hospedes[i].Nome}");
            Console.Write("Digite o número do hóspede: ");
            if (int.TryParse(Console.ReadLine(), out int idxH) && idxH > 0 && idxH <= hospedes.Count)
            {
                hospedes.RemoveAt(idxH - 1);
                File.WriteAllText(hospedesPath, JsonConvert.SerializeObject(hospedes, Formatting.Indented));
                Console.WriteLine("Hóspede removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
            break;

        case "7":
            if (suites.Count == 0)
            {
                Console.WriteLine("Nenhuma suíte cadastrada.");
                break;
            }
            Console.WriteLine("Selecione a suíte para remover:");
            for (int i = 0; i < suites.Count; i++)
                Console.WriteLine($"{i + 1}. {suites[i].TipoSuite} (Capacidade: {suites[i].Capacidade}, Valor: {suites[i].ValorDiaria})");
            Console.Write("Digite o número da suíte: ");
            if (int.TryParse(Console.ReadLine(), out int idxS) && idxS > 0 && idxS <= suites.Count)
            {
                suites.RemoveAt(idxS - 1);
                File.WriteAllText(suitesPath, JsonConvert.SerializeObject(suites, Formatting.Indented));
                Console.WriteLine("Suíte removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
            break;

        case "8":
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva cadastrada.");
                break;
            }
            Console.WriteLine("Selecione a reserva para remover:");
            for (int i = 0; i < reservas.Count; i++)
            {
                var r = reservas[i];
                string suiteNome = r.Suite != null ? r.Suite.TipoSuite : "Sem suíte";
                int qtdHospedes = r.Hospedes != null ? r.Hospedes.Count : 0;
                Console.WriteLine($"{i + 1}. Dias: {r.DiasReservados}, Suíte: {suiteNome}, Hóspedes: {qtdHospedes}");
            }
            Console.Write("Digite o número da reserva: ");
            if (int.TryParse(Console.ReadLine(), out int idxR) && idxR > 0 && idxR <= reservas.Count)
            {
                reservas.RemoveAt(idxR - 1);
                File.WriteAllText(reservasPath, JsonConvert.SerializeObject(reservas, Formatting.Indented));
                Console.WriteLine("Reserva removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
            break;

        case "9":
            if (suites.Count == 0)
            {
                Console.WriteLine("Nenhuma suíte cadastrada.");
            }
            else
            {
                Console.WriteLine("Suítes cadastradas:");
                for (int i = 0; i < suites.Count; i++)
                {
                    var s = suites[i];
                    Console.WriteLine($"{i + 1}. Tipo: {s.TipoSuite}, Capacidade: {s.Capacidade}, Valor Diária: {s.ValorDiaria.ToString("C2")}");
                }
            }
            break;

        case "10":
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva cadastrada.");
            }
            else
            {
                Console.WriteLine("Reservas feitas:");
                for (int i = 0; i < reservas.Count; i++)
                {
                    var r = reservas[i];
                    string suiteNome = r.Suite != null ? r.Suite.TipoSuite : "Sem suíte";
                    int qtdHospedes = r.Hospedes != null ? r.Hospedes.Count : 0;
                    Console.WriteLine($"{i + 1}. Dias: {r.DiasReservados}, Suíte: {suiteNome}, Hóspedes: {qtdHospedes}, Valor Total: {r.CalcularValorDiaria().ToString("C2")}");
                }
            }
            break;

        case "11":
            Console.WriteLine("Saindo do sistema. Até logo!");
            return;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Console.WriteLine();
}
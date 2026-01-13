using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// --- CORREÇÃO 1: Declare as listas AQUI FORA ---
List<Suite> listaSuites = new List<Suite>();
List<Pessoa> hospedes = new List<Pessoa>(); 

while (true)
{
    Console.Clear(); // Ajuda a não poluir a tela
    Console.WriteLine("gostaria de: \n 1 - Nova Suite \n 2 - Fazer uma nova reserva \n 3 - Cadastrar um usuário \n 4 - Listar Suites \n 5 - Listar usuarios \n 6 - Sair");
    string? resposta = Console.ReadLine();
    
    switch (resposta.ToLower())
    {
        case "1":
            Console.WriteLine("Nova Suite: \n");

            Console.WriteLine("Tipo da nova suite: ");
            string tipoSuite = Console.ReadLine();
            Console.WriteLine("Capacidade da nova suite: ");
            int capacidade = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor da diária da nova suite: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            // --- CORREÇÃO 2: Não crie a lista aqui (new List). Apenas adicione na lista que já existe lá fora ---
            // Mudei o nome para 'listaSuites' para ficar mais claro que é uma lista, não uma suite só
            Suite novaSuite = new Suite(tipoSuite: tipoSuite, capacidade: capacidade, valorDiaria: valorDiaria);
            listaSuites.Add(novaSuite);

            Console.WriteLine($"Suite {tipoSuite} criada com sucesso!\n");
            
            // Dica: Esse continue volta para o MENU PRINCIPAL, não para criar outra suite.
            // Para ficar repetindo cadastro, precisaria de outro while aqui dentro.
            Console.WriteLine("Pressione enter para voltar ao menu...");
            Console.ReadLine();
            break;

        case "2":
        if(listaSuites.Count == 0 || hospedes.Count == 0)
        {
            Console.WriteLine("Para fazer uma reserva, é necessário ter pelo menos uma suíte e um hóspede cadastrado.");
            Console.WriteLine("Pressione enter para voltar ao menu...");
            Console.ReadLine();
            break;
        }
            Console.WriteLine("Fazer nova reserva: \n");
            Console.WriteLine("Escolha uma suíte disponível: ");
            for (int i = 0; i < listaSuites.Count; i++)
            {
                var item = listaSuites[i];
                Console.WriteLine($"{i + 1} - Tipo: {item.TipoSuite} | Capacidade: {item.Capacidade} | Valor: {item.ValorDiaria:C}");
            }
            int escolhaSuite = int.Parse(Console.ReadLine()) - 1;
            Suite suiteEscolhida = listaSuites[escolhaSuite];

            Console.WriteLine("Quantos dias deseja reservar? ");

            int diasReservados = int.Parse(Console.ReadLine());

            Reserva novaReserva = new Reserva(diasReservados: diasReservados);
            novaReserva.CadastrarSuite(suiteEscolhida);
            novaReserva.CadastrarHospedes(hospedes);
            Console.WriteLine($"Quantidade de hóspedes na reserva: {novaReserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor total da diária: {novaReserva.CalcularValorDiaria():C}");
            Console.WriteLine($"Reserva para a suíte {suiteEscolhida.TipoSuite} feita com sucesso!\n");


            Console.WriteLine("Pressione enter para voltar ao menu...");
            Console.ReadLine();
            break;

        case "3":
            // ... (seu código de cadastro de usuário) ...
            Console.WriteLine("Cadastro de usuário: \n");
            Console.WriteLine("Nome do novo usuário: ");
            string nomeUsuario = Console.ReadLine();

            Console.WriteLine("Sobrenome do novo usuário: ");
            string sobrenomeUsuario = Console.ReadLine();
            Pessoa novoUsuario = new Pessoa(nome: nomeUsuario, sobrenome: sobrenomeUsuario);
            hospedes.Add(novoUsuario);
            Console.WriteLine($"Usuário {novoUsuario.NomeCompleto} cadastrado com sucesso!\n");
            Console.WriteLine("Pressione enter para voltar ao menu...");
            Console.ReadLine();
            
            
            break;

        case "4":
            Console.WriteLine("Listar Suites: \n");

            // --- CORREÇÃO 3: Agora o case 4 consegue enxergar a 'listaSuites' ---
            // Verifica se a lista não está vazia antes
            if (listaSuites.Count > 0)
            {
                foreach (var item in listaSuites)
                {
                    Console.WriteLine($"Tipo: {item.TipoSuite} | Capacidade: {item.Capacidade} | Valor: {item.ValorDiaria:C}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma suíte cadastrada.");
            }
            
            Console.WriteLine("\nPressione enter para continuar...");
            Console.ReadLine();
            break;

        case "5":
             if (hospedes.Count > 0)
            {
                Console.WriteLine("Listar Usuários: \n");
                foreach (var hospede in hospedes)
                {
                    Console.WriteLine($"Nome: {hospede.NomeCompleto}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum hóspede cadastrado.");
            }
            Console.WriteLine("\nPressione enter para voltar ao menu...");
            Console.ReadLine(); // Isso segura a tela até você apertar Enter
            break;
             
             
        case "6":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
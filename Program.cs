using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos 
List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = new Suite();
Reserva reserva = new Reserva();

// Exibição de Menu
string opcao = string.Empty;
bool exibirMenu = true;

// Loop do Menu
while(exibirMenu)
{
    Console.Clear();

    Console.WriteLine("A -- Criar a Suíte");
    Console.WriteLine("B -- Cadastrar Hóspede");
    Console.WriteLine("C -- Criar uma reserva");
    Console.WriteLine("D -- Exibir o valor da diária");
    Console.WriteLine("E -- Finalizar o programa");

    switch(Console.ReadLine().ToUpper())
    {
        case "A":
                 Console.WriteLine("Tipo da Suíte:");

                    Console.WriteLine("Executivo");
                    Console.WriteLine("Premium");
                    Console.WriteLine("Classic");

                 suite.TipoSuite = Console.ReadLine();
                 string tipo = suite.TipoSuite;

                 switch(tipo)
                 {
                    case "Executivo":
                           suite.Capacidade = 12;
                           suite.ValorDiaria = 122.56M;
                           break;
                    case "Premium":
                           suite.Capacidade = 7;
                           suite.ValorDiaria = 67.42M;
                           break;
                    case "Classic":
                           suite.Capacidade = 4;
                           suite.ValorDiaria = 32.79M;
                           break;
                    default:
                            Console.WriteLine("Opção Inválida");
                            break;
                 }

                 break;
        case "B":
                reserva.AdicionarHospedes(hospedes);
                break;
        case "C":
                // Cria uma nova reserva, passando a suíte e os hóspedes
                Console.WriteLine("Quantos dias serão para reservar a suíte:");
                reserva = new Reserva(diasReservados: Convert.ToInt32(Console.ReadLine()));
                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);
                break;
        case "D":
               // Exibe a quantidade de hóspedes e o valor da diária
                Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
                break;
        case "E":
                exibirMenu = false;
                break;
        default:
                Console.WriteLine("Opção inválida");
                break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();

    
}

Console.WriteLine("O Programa Finalizou");
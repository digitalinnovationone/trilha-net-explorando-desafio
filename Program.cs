using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

bool exibirMenu = true;
string nomeHospede = null;
string sobrenomeHospede = null;
string opcao = string.Empty;


Console.OutputEncoding = Encoding.UTF8;

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

Console.WriteLine("Seja bem vindo ao Hotel!\n");

while(exibirMenu){
    Console.WriteLine("Menu");
    Console.WriteLine("1 - Cadastrar hospede");
    Console.WriteLine("2 - Cadastrar reserva");
    Console.WriteLine("3 - Encerrar cadastro");
    Console.Write("Digite sua opçõa: ");
    opcao = Console.ReadLine();
    Console.Clear();
    switch(opcao)
    {
        case "1":
            Console.WriteLine("---------------------------------------- ");
            Console.Write("Digite o nome: ");
            nomeHospede = Console.ReadLine();
            Console.Write("Digite o sobrenome do hospede: ");
            sobrenomeHospede = Console.ReadLine();
            Pessoa p = new Pessoa(nome: nomeHospede, sobrenome: sobrenomeHospede);
            hospedes.Add(p);
            Console.Clear();
            Console.WriteLine($"Cadastro realizado com sucesso! {nomeHospede} {sobrenomeHospede}\n");
            break;
        case "2":
            Console.WriteLine("---------------------------------------- ");
            Console.WriteLine("Cadastrar Reserva");
            Console.Write("Digite a quantidade de dias para reserva: "); 

            int qtdeDiasReserva;

            while(!int.TryParse(Console.ReadLine(), out qtdeDiasReserva)){
                Console.WriteLine("Entrada Inválida! Por favor, digite um número válido.");
                Console.Write("Digite a quantidade de dias para reserva: "); 
            }
            
            // Cria uma nova reserva, passando a suíte e os hóspedes
            Reserva reserva = new Reserva(diasReservados: qtdeDiasReserva);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            // Exibe a quantidade de hóspedes e o valor da diária
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            Console.WriteLine("Reserva Concluída com sucesso");
            Console.WriteLine("----------------------------------------------");
            break;
        case "3":
            exibirMenu = false;
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
}


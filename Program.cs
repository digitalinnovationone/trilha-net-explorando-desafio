using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;
// Cria a suíte
Suite suite = new Suite();
Console.WriteLine("Digite o tipo da suíte:");
suite.TipoSuite = Console.ReadLine();
Console.WriteLine("Digite a capacidade da suíte:");
suite.Capacidade = int.Parse(Console.ReadLine());
Console.WriteLine("Digite o valor da diária:");
suite.ValorDiaria = decimal.Parse(Console.ReadLine());

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("Quantos hóspedes irão se hospedar?");
int qtdHospedes = int.Parse(Console.ReadLine());

    for (int x = 0; x < qtdHospedes; x++ ) {
        Pessoa p = new Pessoa();
        Console.WriteLine($"Digite o nome do {x+1}º hóspede:");
        p.Nome = Console.ReadLine();
        Console.WriteLine($"Digite o sobrenome do {x+1}º hóspede:");
        p.Sobrenome = Console.ReadLine();
        hospedes.Add(p);
    }

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva();
Console.WriteLine("Por quantos dias você deseja se hospedar?");
reserva.DiasReservados = int.Parse(Console.ReadLine());
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor final: R$ {reserva.CalcularValorDiaria()}");

using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("Quantas pessoas irão se hospedar?");
int quantidadeHospedes = int.Parse(Console.ReadLine());

// Adiciona os hóspedes
for (int i = 0; i < quantidadeHospedes; i++)
{
    // Solicitar o Nome e Sobrenome do hóspede
    Console.WriteLine($"Digite o nome do hóspede {i + 1}:");
    string nome = Console.ReadLine();

    Console.WriteLine($"Digite o sobrenome do hóspede {i + 1}:");
    string sobrenome = Console.ReadLine();

    // Adicionar o hóspede com Nome e Sobrenome na lista de hóspedes
    hospedes.Add(new Pessoa(nome, sobrenome)); 
}

// Coletar informações da suíte
Console.WriteLine("Digite o tipo de suíte (Ex: Standard, Luxo, Premium):");
string tipoSuite = Console.ReadLine();

Console.WriteLine("Digite o valor da diária da suíte:");
decimal valorDiaria;
while (!decimal.TryParse(Console.ReadLine(), out valorDiaria))
{
    Console.WriteLine("Valor inválido. Por favor, insira um número decimal válido.");
}

// Coletar a capacidade da suíte
Console.WriteLine("Digite a capacidade de pessoas da suíte:");
int capacidadeSuite;
while (!int.TryParse(Console.ReadLine(), out capacidadeSuite))
{
    Console.WriteLine("Valor inválido. Por favor, insira um número inteiro válido.");
}

// Cria a suíte
Suite suite = new Suite(tipoSuite, capacidadeSuite, valorDiaria);

// Coletar informações da reserva
Console.WriteLine("Digite a quantidade de dias da reserva:");
int diasReservados;
while (!int.TryParse(Console.ReadLine(), out diasReservados) || diasReservados <= 0)
{
    Console.WriteLine("Valor inválido. Por favor, insira um número inteiro positivo para os dias reservados:");
}

// Cria a reserva
Reserva reserva = new Reserva(diasReservados);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);


// Exibe a quantidade de hóspedes e o valor total da reserva APÓS coletar todas as informações
try
{
    Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor total da reserva: R$ {reserva.CalcularValorTotal():F2}");
}  
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


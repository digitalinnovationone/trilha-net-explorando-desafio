using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.Write("Informar quantidade de hóspedes: ");
int n = int.Parse(Console.ReadLine());
for (int i = 1; i <= n; i++)
{
    Console.WriteLine();
    Console.WriteLine($"Hóspede #{i}:");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Sobrenome: ");
    string sobrenome = Console.ReadLine();
    hospedes.Add(new Pessoa(nome, sobrenome));
}

// Cria a suíte
Console.Write("Informe o tipo da suíte: ");
string tipoSuite = Console.ReadLine();
Console.Write("Informe a capacidade da suíte: ");
int capacidade = int.Parse(Console.ReadLine());
Console.Write("Informe o valor da suíte: ");
decimal valorDiaria = decimal.Parse(Console.ReadLine());
Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);

// Cria uma nova reserva, passando a suíte e os hóspedes
Console.Write("Informe quantos dias de reserva: ");
int diasReservados = int.Parse(Console.ReadLine());
Reserva reserva = new Reserva(diasReservados);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine("# Informação sobre sua hospedagem #");
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
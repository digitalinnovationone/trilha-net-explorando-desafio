using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes

Console.Write("Digite o número de hóspedes: ");
int quantidadeHospedes = int.Parse(Console.ReadLine());

List<Pessoa> hospedes = new List<Pessoa>();

// Loop para adicionar cada hóspede com entrada de nome
for (int i = 1; i <= quantidadeHospedes; i++)
{
    Console.Write($"Digite o nome do hóspede {i}: ");
    string nomeHospede = Console.ReadLine();
    hospedes.Add(new Pessoa(nome: nomeHospede));
}

// Cria a suíte
Console.Write("Digite a capacidade da suíte: ");
int capacidadeSuite = int.Parse(Console.ReadLine());

Console.Write("Digite o valor da diária da suíte: ");
decimal valorDiaria = decimal.Parse(Console.ReadLine());

Suite suite = new Suite(tipoSuite: "Premium", capacidade: capacidadeSuite, valorDiaria: valorDiaria);

// Cria uma nova reserva, passando a suíte e os hóspedes
Console.Write("Digite a quantidade de dias reservados: ");
int diasReservados = int.Parse(Console.ReadLine());

if (diasReservados <= 0)
{
    throw new ArgumentException("O número de dias reservados deve ser maior que zero.");
}

Reserva reserva = new Reserva(diasReservados: diasReservados);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine("\n");
Console.WriteLine($"Suíte escolhida: {suite.TipoSuite}");
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");

Console.WriteLine("Lista de hóspedes:");
foreach (var hospede in hospedes)
{
    Console.WriteLine($" -  {hospede.Nome}");
}

Console.WriteLine($"Total a pagar por {reserva.DiasReservados} dias: {reserva.CalcularValorDiaria():C}");
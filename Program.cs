using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Solicita a quantidade de hospedes, seus nomes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.Write("Quantos hóspedes deseja cadastrar? ");
int quantidade = int.Parse(Console.ReadLine());

for (int i = 1; i <= quantidade; i++)
{
    Console.Write($"Digite o nome do hóspede {i}: ");
    string nome = Console.ReadLine();
    Console.Write($"Digite o sobrenome do hóspede {i}: ");
    string sobrenome = Console.ReadLine();
    hospedes.Add(new Pessoa(nome: nome, sobrenome: sobrenome));
}

// Solicita a quantidade de dias para a reserva
Console.Write("Quantos dias deseja reservar? ");
int diasReservados = int.Parse(Console.ReadLine());

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: diasReservados);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Nome dos hóspedes: {string.Join(", ", hospedes.Select(h => h.NomeCompleto))}");
Console.WriteLine($"Valor diária: R$ {reserva.CalcularValorDiaria()}");
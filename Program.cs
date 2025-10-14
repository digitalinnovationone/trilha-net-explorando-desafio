using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

// ======== MENU DE CADASTRO DE HÓSPEDES E DIAS ========
Console.WriteLine("=== SISTEMA DE RESERVAS ===");
Console.Write("Informe a quantidade de hóspedes: ");
int qtdHospedes = int.Parse(Console.ReadLine()!);

// Cadastra cada hóspede de acordo com o número informado
for (int i = 1; i <= qtdHospedes; i++)
{
    Console.Write($"Digite o nome do hóspede {i}: ");
    string nomeHospede = Console.ReadLine()!;
    hospedes.Add(new Pessoa(nome: nomeHospede));
}

// Pergunta a quantidade de dias
Console.Write("Informe o número de dias da reserva: ");
int dias = int.Parse(Console.ReadLine()!);

// =====================================================

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: dias);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria():C}");

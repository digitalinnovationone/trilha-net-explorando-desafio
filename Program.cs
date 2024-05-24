using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// IMPLEMENTADO !!!!!
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Henrique", sobrenome: "Albuquerque");
Pessoa p2 = new Pessoa(nome: "Herminiá", sobrenome: "Santiago");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 15);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e os nomes deles
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");

foreach (var hospede in reserva.Hospedes)
{
    Console.WriteLine($"Hospede: {hospede.Nome} {hospede.Sobrenome}");
}

// Exibe o valor da diária
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

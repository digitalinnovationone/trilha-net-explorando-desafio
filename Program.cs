using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;


// Cria os modelos de hóspedes e cadastra na lista de hóspedes
 
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Maycon", "Souza");
Pessoa p2 = new Pessoa(nome: "Kattlyn", "Souza");

hospedes.Add(p1);
hospedes.Add(p2);


//Cria a suíte

Suite SuitePremium = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 230);
Suite SuiteEconomica = new Suite(tipoSuite: "Economica", capacidade: 1, valorDiaria: 100);
Suite SuiteStandard = new Suite(tipoSuite: "Standard", capacidade: 2, valorDiaria: 150);
Suite SuiteFamiliar = new Suite(tipoSuite: "Familia", capacidade: 4, valorDiaria: 250);

//Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 11);
reserva.CadastrarSuite(SuitePremium);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e os nomes e o valor da diária

Console.WriteLine($"Hóspedes:{reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Nome hóspedes: {p1.NomeCompleto} e {p2.NomeCompleto}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
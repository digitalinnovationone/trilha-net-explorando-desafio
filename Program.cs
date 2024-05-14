using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("Caso 1 - qtd de hospedes menor que capacidade");
Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);
//hospedes.Add(p3);
//hospedes.Add(p4);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");


List<Pessoa> hospedes2 = new List<Pessoa>();

Console.WriteLine("\nCaso 2 - dias reservados maior ou igual a 10 dias");
Pessoa p3 = new Pessoa(nome: "Hóspede 3");
Pessoa p4 = new Pessoa(nome: "Hóspede 4");

hospedes2.Add(p3);
hospedes2.Add(p4);


// Cria a suíte
Suite suite2 = new Suite(tipoSuite: "Deluxe", capacidade: 3, valorDiaria: 60);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva2 = new Reserva(diasReservados: 11);
reserva2.CadastrarSuite(suite2);
reserva2.CadastrarHospedes(hospedes2);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva2.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor total: {reserva2.CalcularValorDiariaSemDesconto()}");
Console.WriteLine($"Valor do desconto: {reserva2.CalcularDesconto()}");
Console.WriteLine($"Valor diária com desconto: {reserva2.CalcularValorDiaria()}");

Console.WriteLine("\nCaso 3 - qtd de hospedes maior que permitido");

List<Pessoa> hospedes3 = new List<Pessoa>();

Pessoa p5 = new Pessoa(nome: "Hóspede 5");
Pessoa p6 = new Pessoa(nome: "Hóspede 6");

hospedes3.Add(p3);
hospedes3.Add(p4);


// Cria a suíte
Suite suite3 = new Suite(tipoSuite: "Basic", capacidade: 1, valorDiaria: 20);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva3 = new Reserva(diasReservados: 3);
reserva3.CadastrarSuite(suite3);
reserva3.CadastrarHospedes(hospedes3);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva3.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva3.CalcularValorDiaria()}");
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "João Victor");
Pessoa p2 = new Pessoa(nome: "Pri Moura");
Pessoa p3 = new Pessoa(nome: "Levi Cordeiro");

hospedes.Add(p1);
hospedes.Add(p2);
hospedes.Add(p3);


// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 5, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 10);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Quandtidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Hóspedes: {reserva.ListarHospedes()}");
Console.WriteLine($"Valor diária: R${reserva.CalcularValorDiaria()}");
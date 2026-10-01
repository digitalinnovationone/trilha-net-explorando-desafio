using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Julio Manuel");
Pessoa p2 = new Pessoa(nome: "Herm[inio da Silva]");
Pessoa p3 = new Pessoa(nome: "Mesach Zua");

hospedes.Add(p1);
hospedes.Add(p2);
hospedes.Add(p3);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Presidencial", capacidade: 4, valorDiaria: 200000);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 14);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Número de hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Total a pagar: AKz {reserva.CalcularValorDiaria()}");
DateTime data = DateTime.Now;
Console.WriteLine($"Data e hora de registro: {data.ToString("yyyy-MM-dd HH:mm")}");
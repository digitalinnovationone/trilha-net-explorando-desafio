using System.Text;
using System.Globalization;
using DesafioProjetoHospedagem.Models;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new (nome: "Hóspede 1");
Pessoa p2 = new (nome: "Hóspede 2");
Pessoa p3 = new (nome: "Hóspede 3");

hospedes.Add(p1);
hospedes.Add(p2);
hospedes.Add(p3);

// Cria a suíte
Suite suite = new (tipoSuite: "Premium", capacidade: 2, valorDiaria: 120);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new (diasReservados: 20);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria():C}");
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Thifany Prates");
Pessoa p2 = new Pessoa(nome: "Leandro Damasceno");

hospedes.Add(p1);
hospedes.Add(p2);


Suite suite = new Suite(tipoSuite: "Premium", capacidade: 5, valorDiaria: 100);

Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
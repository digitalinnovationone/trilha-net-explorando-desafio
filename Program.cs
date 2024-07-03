using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;
 
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Felipe", sobrenome: "Alves");
Pessoa p2 = new Pessoa(nome: "Pedor", sobrenome: "Costa");

hospedes.Add(p1);
hospedes.Add(p2);

 
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);


Reserva reserva = new Reserva(diasReservados: 11);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

 
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
 
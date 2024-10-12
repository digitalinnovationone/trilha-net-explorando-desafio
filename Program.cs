using DesafioProjetoHospedagem.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);

try
{
    reserva.CadastrarHospedes(hospedes);
}
catch (Exception ex)
{
    Console.WriteLine($"Não foi possível realizar a operação: {ex.Message}");
}

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {suite.ValorDiaria} | Qtd dias: {reserva.DiasReservados} | Valor hospedagem: {reserva.CalcularValorHospedagem()}");
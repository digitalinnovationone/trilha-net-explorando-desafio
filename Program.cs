using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

try
{
    // Inicialização limpa - padrão C# moderno
    List<Pessoa> hospedes = new()
    {
        new Pessoa(nome: "Leonardo"),
        new Pessoa(nome: "Ana"),
        new Pessoa(nome: "Carlos"),
        new Pessoa(nome: "Beatriz"),
        new Pessoa(nome: "Daniel"),
        new Pessoa(nome: "Fernanda"),
        new Pessoa(nome: "Gabriel"),
    };

    Suite suite = new(tipoSuite: "Premium", capacidade: 10, valorDiaria: 1000);

    Reserva reserva = new(diasReservados: 12); // 12 dias para testar o desconto
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor total com desconto: {reserva.CalcularValorDiaria():C}"); // :C formata como moeda
}
catch (Exception ex)
{
    Console.WriteLine($"Erro na reserva: {ex.Message}");
}
using System.Text;
using DesafioProjetoHospedagem.Models;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Cria os modelos de hóspedes e cadastra na lista de hóspedes
        List<Pessoa> hospedes = new()
        {
            new(nome: "Hóspede 1"),
            new(nome: "Hóspede 2")
        };

        // Cria a suíte
        Suite suite = new(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

        // Cria uma nova reserva, passando a suíte e os hóspedes
        Reserva reserva = new(diasReservados: 5);
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine($"Número de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor da Diária: {reserva.CalcularValorDiaria():C2}");
    }
}

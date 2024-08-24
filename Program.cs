using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

string premium = "Premium";
string luxo = "Luxo";

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");
Pessoa p3 = new Pessoa(nome: "Hóspede 3");

hospedes.Add(p1);
hospedes.Add(p2);
hospedes.Add(p3);

// Cria a suíte
Suite suitePremium = new Suite(tipoSuite: premium, capacidade: 5, valorDiaria: 30);
Suite suiteLuxo = new Suite(tipoSuite: luxo, capacidade: 2, valorDiaria: 15);
Suite[] suites = {suiteLuxo, suitePremium};

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva1 = new Reserva(diasReservados: 5);
Reserva reserva2 = new Reserva(diasReservados: 10);
Reserva[] reservas = {reserva1, reserva2};

for(int i = 0; i < reservas.Count(); i++)
{
    try
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"Reserva {i+1}");
        Console.WriteLine($"\nSuite: {suites[i].TipoSuite}");
        Console.WriteLine($"Capacidade: {suites[i].Capacidade} hóspedes");
        reservas[i].CadastrarSuite(suites[i]);
        reservas[i].CadastrarHospedes(hospedes);
    
        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine($"Hóspedes: {reservas[i].ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor total da diária: {reservas[i].CalcularValorDiaria():C}");

        Console.WriteLine("Reserva realizada com sucesso!");
    } 
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Reserva cancelada!");
    }
    finally
    {
        Console.WriteLine("\nObrigado por usar nossos serviços!");
    }
}
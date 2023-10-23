using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("\n *** ADICIONE UM NOVO HOSPEDE *** \n");

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

bool addMore = true;

while (addMore)
{

    Pessoa p1 = Pessoa.adicionarHospede();

    hospedes.Add(p1);

    Console.WriteLine("Deseja Adicionar outro hóspede? Sim = S / Não = 0");

    String resposta = Console.ReadLine();

    if (resposta == "0")
    {
        addMore = false;
    }

}

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Console.Write("Quantos dias deseja Reservar?");

int DiasReserva;

bool addDays = int.TryParse(Console.ReadLine(), out DiasReserva);

if (addDays)
{
    Reserva reserva = new Reserva(diasReservados: DiasReserva);
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    // Exibe a quantidade de hóspedes e o valor da diária
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
}
else
{
 Console.WriteLine("Não foi possível continuar a reserva.");
}

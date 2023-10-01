using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// agilizando testes quantidade de pessoas
for (int i = 0; i <= 1; i++)
{
    hospedes.Add(new Pessoa(nome: $"Hóspede {i}"));
}


// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);

(bool sucesso, string resultado) = reserva.CadastrarHospedes(hospedes);

// Se a operação estiver dentro dos parâmetros, exibe a quantidade de hóspedes e o valor da diária
Console.Clear();
Console.WriteLine($"Mensagem: {resultado}\n");
if(sucesso)
{
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes(hospedes)}");
    Console.WriteLine($"Valor diária R$: {reserva.CalcularValorDiaria():0.00}");
}
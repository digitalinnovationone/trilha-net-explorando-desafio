using System.Text;
using DesafioProjetoHospedagem.Models;

/*
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
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
*/
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        bool programa = true;
        while (programa == true)
        {
            Console.WriteLine("-=- Cadastro no Hotel -=-\n1 - Cadastrar Suite Nova\n2 - Reservar Suite\n3 - Ver Reserva\n0 - Sair do Programa\nEscolha sua opção:");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Tipo da Suite: ");
                    string Tipo = Console.ReadLine();
                    Console.WriteLine("Valor da Diaria: ");
                    int ValorDiaria = int.Parse(Console.ReadLine());
                    Console.WriteLine("Tamanho da Suite: ");
                    int Tamanho = int.Parse(Console.ReadLine());
                    Suite suite = new Suite(Tipo, Tamanho, ValorDiaria);
                    Console.WriteLine($"Suite Cadastrada do tipo: {suite.TipoSuite},de capacidade: {suite.Capacidade} e valor por dia: {suite.ValorDiaria}");
                    break;
                case 2:
                    break;
                case 0:
                    programa = false;
                    break;
            }
        }
    }
}
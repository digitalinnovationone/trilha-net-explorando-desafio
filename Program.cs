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
        List<Suite> suites = new List<Suite>();
        List<Pessoa> hospedes = new List<Pessoa>();
        List<Reserva> reservas = new List<Reserva>();
        Suite suiteNormal = new Suite("Normal", 2, 30);
        Suite suitePremium = new Suite("Premium", 4, 70);
        suites.Add(suiteNormal);
        suites.Add(suitePremium);
        Console.OutputEncoding = Encoding.UTF8;
        bool programa = true;
        while (programa == true)
        {
            Console.WriteLine("-=- Cadastro no Hotel -=-\n1 - Cadastrar Suite Nova\n2 - Ver Suites\n3 - Reservar Suite\n4 - Ver Reserva\n0 - Sair do Programa\nEscolha sua opção:");
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
                    Suite suiteNova = new Suite(Tipo, Tamanho, ValorDiaria);
                    suites.Add(suiteNova);
                    Console.WriteLine($"Suite Cadastrada do tipo: {suiteNova.TipoSuite},de capacidade: {suiteNova.Capacidade} e valor por dia: {suiteNova.ValorDiaria}");
                    break;
                case 2:
                    Console.WriteLine("Nossas suites:");
                    foreach (Suite suite in suites)
                    {
                        Console.WriteLine($"Tipo: {suite.TipoSuite}, Capacidade: {suite.Capacidade} e Valor Diaria: {suite.ValorDiaria}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Faça Sua Reserva\nQuantas pessoas na suite?");
                    int Quantitade = int.Parse(Console.ReadLine());
                    if (Quantitade >= 1)
                    {
                        for (int i = 0; i < Quantitade; i++)
                        {
                            Pessoa p = new Pessoa(nome: $"Hóspede {i}");
                            hospedes.Add(p);
                        }
                        Console.WriteLine("Quantos dias deseja ficar?");
                        int diasReservados = int.Parse(Console.ReadLine());
                        Reserva reserva = new Reserva(diasReservados);
                        Console.WriteLine("Qual suite deseja ficar?");
                        int Contador = 0;
                        foreach (Suite suite in suites)
                        {
                            Console.WriteLine($"Suite {Contador} - Tipo: {suite.TipoSuite}, Capacidade: {suite.Capacidade} e Valor Diaria: {suite.ValorDiaria}");
                            Contador += 1;
                        }
                        int escolha = int.Parse(Console.ReadLine());
                        for (int i = 0; i < suites.Count(); i++)
                        {
                            if (escolha == i)
                            {
                                reserva.CadastrarSuite(suites[i]);
                            }
                        }
                        reserva.CadastrarHospedes(hospedes);
                        reservas.Add(reserva);
                        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de Pessoas Invalidas");
                    }
                    break;
                case 4:
                    if (reservas.Count() > 0)
                    {
                        int Contador = 0;
                        foreach (Reserva reserva in reservas)
                        {
                            Console.WriteLine($"Reserva {Contador} - Tipo de Suite: {reserva.ObterTipoSuite()}, Quantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                            Contador += 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nenhuma reserva feita");
                    }
                    break;
                case 0:
                    programa = false;
                    break;
            }
        }
    }
}
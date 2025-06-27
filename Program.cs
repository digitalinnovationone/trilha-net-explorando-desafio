using System;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");
Pessoa p3 = new Pessoa(nome: "Hóspede 3");

bool menu = true;
Reserva reserva = null; // Corrigido: reserva declarada fora do loop

while (menu)
{
    Console.Clear();
    Console.WriteLine("Seja bem-vindos ao Hotel Dev!");
    Console.WriteLine("1 - Hospedar uma Suite");
    Console.WriteLine("2 - Descobrir o valor da entrada");
    Console.WriteLine("3 - Listar Quantidade de hospedes na suite reservada");
    Console.WriteLine("4 - Sair");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Hospedando uma suíte...");
            hospedes.Clear(); // Corrigido: limpa a lista antes de adicionar
            hospedes.Add(p1);
            hospedes.Add(p2);
            hospedes.Add(p3);
            Suite suite = new Suite(tipoSuite: "Master", capacidade: 3, valorDiaria: 45);
            reserva = new Reserva(diasReservados: 12);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);
            Console.WriteLine("Reserva realizada com sucesso!");
            Console.ReadLine();
            break;
        case "2":
            if (reserva != null)
                Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            else
                Console.WriteLine("Nenhuma reserva cadastrada.");
            Console.ReadLine();
            break;
        case "3":
            if (reserva != null)
                Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            else
                Console.WriteLine("Nenhuma reserva cadastrada.");
            Console.ReadLine();
            break;
        case "4":
            menu = false;
            continue;
        default:
            Console.WriteLine("Opção inválida, tente novamente.");
            Console.ReadLine();
            continue;
    }
}

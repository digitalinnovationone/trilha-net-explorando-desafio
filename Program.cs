using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;
using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagem
{

    class Program
    {

        static void Main(string[] args)
        {

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
            reserva.CadastrarHospedes(hospedes);

            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("==========================");
                Console.WriteLine("===== MENU PRINCIPAL =====");
                Console.WriteLine($"==========================\n");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Ver quantidade de hóspedes: ");
                Console.WriteLine("2 - Ver valor da diária: ");
                Console.WriteLine("3 - Sair: ");


                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                        break;
                    case "2":
                        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
                        break;
                    case "3":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine($"Opção inválida. Tente novamente.");
                        break;
                }

            }

        }

    }
}



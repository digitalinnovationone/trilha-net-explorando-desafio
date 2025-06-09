using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;

namespace trilha_net_explorando_desafio2.Services.SuiteServices
{
    public class SuiteUtilities
    {
        public static Suite CadastrarSuite()
        {
            Console.WriteLine("Tipo da Suite: ");
            string tipo = Console.ReadLine();

            Console.WriteLine("Capacidade da Suite: ");
            int capacidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Valor diária da Suite: ");
            decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());

            return new Suite(tipo, capacidade, valorDiaria);
        }

        public static void ListarSuite(List<Suite> suites)
        {
            int i = 0;
            foreach (Suite suite in suites)
            {
                Console.WriteLine($"===== Id: {i++} =====");
                Console.WriteLine($"Tipo: {suite.TipoSuite}");
                Console.WriteLine($"Capacidade: {suite.Capacidade}");
                Console.WriteLine($"Valor da diária: {suite.ValorDiaria}");
            }
        }

        public static void AlterarDados(List<Suite> suites)
        {
            if (suites.Count == 0)
            {
                Console.WriteLine("Não há suítes cadastradas!");
                Thread.Sleep(2000);

                return;
            }

            ListarSuite(suites);

            Console.WriteLine("\nInsira o Id da suíte que deseja alterar o dado:");
            int id = Convert.ToInt32(Console.ReadLine());

            bool verificacao;
            int opcao = 0;
            do
            {
                Console.Clear();

                Console.WriteLine($"Suíte selecionado - Id : {id}");
                Console.WriteLine(suites[id].TipoSuite);
                Console.WriteLine(suites[id].Capacidade);
                Console.WriteLine(suites[id].ValorDiaria);

                Console.WriteLine("[1] - Tipo da suite\n[2] - Capacidade\n[3] - Valor da diária\n[0] - Encerrar\n:");
                verificacao = int.TryParse(Console.ReadLine(), out opcao);

                if (verificacao != true)
                {
                    Console.WriteLine("Entrada inválida!");
                    verificacao = true;
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Insira novo tipo: ");
                        suites[id].TipoSuite = Console.ReadLine();

                        verificacao = true;
                        break;
                    case 2:
                        Console.WriteLine("Insira nova capacidade: ");
                        int.TryParse(Console.ReadLine(), out int capacidade);

                        suites[id].Capacidade = capacidade;

                        verificacao = true;
                        break;
                    case 3:
                        Console.WriteLine("Insira novo valor da diária: ");
                        decimal.TryParse(Console.ReadLine(), out decimal valorDiaria);

                        suites[id].ValorDiaria = valorDiaria;

                        verificacao = true;
                        break;
                    case 0:
                        verificacao = false;
                        break;
                    default:
                        Console.WriteLine("Entrada inválida!");
                        verificacao = true;
                        break;
                }

            } while (verificacao);
        }

        public static void RemoverSuite(List<Suite> suites)
        {
            if (suites.Count == 0)
            {
                Console.WriteLine("Não há suítes cadastradas!");
                Thread.Sleep(2000);

                return;
            }

            ListarSuite(suites);

            Console.WriteLine("Insira o Id da suíte que deseja remover: ");
            bool verificacao = int.TryParse(Console.ReadLine(), out int id);

            if (verificacao != true || id < 0 || id > suites.Count)
            {
                Console.WriteLine("Entrada inválida!");
                Thread.Sleep(2000);
            }
            else
            {
                suites.Remove(suites[id]);

                Console.WriteLine("Suíte removida com sucesso!");
                Thread.Sleep(2000);
            }
        }
    }
}
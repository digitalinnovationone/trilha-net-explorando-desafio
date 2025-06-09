using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;

namespace trilha_net_explorando_desafio2.Services.PessoaServices
{
    public class PessoaUtilities
    {
        public static Pessoa CadastrarPessoa()
        {
            Console.WriteLine("Insira o nome da pessoa: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira o sobrenome da pessoa");
            string sobrenome = Console.ReadLine();

            return new Pessoa(nome, sobrenome);
        }

        public static void ListarPessoa(List<Pessoa> pessoas)
        {
            int i = 0;
            foreach (Pessoa pessoa in pessoas)
            {
                Console.WriteLine($"Id: {i++} - {pessoa.NomeCompleto}");
            }
        }

        public static void AlterarDados(List<Pessoa> pessoas)
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Não há pessoas cadastradas!");
                Thread.Sleep(2000);

                return;
            }

            ListarPessoa(pessoas);

            Console.WriteLine("Insira o Id da pessoa que deseja alterar o dado:");
            int id = Convert.ToInt32(Console.ReadLine());

            bool verificacao;
            int opcao = 0;
            do
            {
                Console.Clear();

                Console.WriteLine($"Pessoa selecionado: {pessoas[id].NomeCompleto}");

                Console.WriteLine("[1] - Nome\n[2] - Sobrenome\n[0] - Encerrar\n:");
                verificacao = int.TryParse(Console.ReadLine(), out opcao);

                if (verificacao != true)
                {
                    Console.WriteLine("Entrada inválida!");
                    verificacao = true;
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Insira novo nome:");
                        pessoas[id].Nome = Console.ReadLine();

                        verificacao = true;
                        break;
                    case 2:
                        Console.WriteLine("Insira novo sobrenome:");
                        pessoas[id].Sobrenome = Console.ReadLine();

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

        public static void RemoverPessoa(List<Pessoa> pessoas)
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Não há pessoas cadastradas!");
                Thread.Sleep(2000);

                return;
            }

            ListarPessoa(pessoas);

            Console.WriteLine("\nInsira o Id da pessoa que deseja remover: ");
            bool verificacao = int.TryParse(Console.ReadLine(), out int id);

            if (verificacao != true || id < 0 || id > pessoas.Count)
            {
                Console.WriteLine("Entrada inválida!");
                Thread.Sleep(2000);
            }
            else
            {
                pessoas.Remove(pessoas[id]);

                Console.WriteLine("Pessoa removida com sucesso!");
                Thread.Sleep(2000);
            }           
        }
    }
}
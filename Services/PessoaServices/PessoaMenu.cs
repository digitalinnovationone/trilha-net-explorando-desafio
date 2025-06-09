using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;
using trilha_net_explorando_desafio2.Services.PessoaServices;

namespace trilha_net_explorando_desafio2.Services
{
    public class PessoaMenu
    {
        public static void Menu(List<Pessoa> pessoas)
        {
            bool verificacao;
            int opcao = 0;
            do
            {
                Console.Clear();

                Console.WriteLine("===== Menu de Pessoas =====");
                Console.WriteLine("[1] - Cadastrar pessoa\n[2] - Alterar dados\n[3] - Excluir Pessoa\n[0] - Voltar ao menu principal\n:");
                verificacao = int.TryParse(Console.ReadLine(), out opcao);

                // Para quando meu ReadLine obter um caracter que não seja int
                if (verificacao == false)
                {
                    Console.WriteLine("Insira uma entrada válida!");
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        pessoas.Add(PessoaUtilities.CadastrarPessoa());
                        break;
                    case 2:
                        PessoaUtilities.AlterarDados(pessoas);
                        break;
                    case 3:
                        PessoaUtilities.RemoverPessoa(pessoas);
                        break;    
                    case 0:
                        verificacao = false;
                        break;
                    default:
                        Console.WriteLine("Insira uma entrada válida!");
                        verificacao = true;
                        break;
                }

            } while (verificacao);
        }
    }
}
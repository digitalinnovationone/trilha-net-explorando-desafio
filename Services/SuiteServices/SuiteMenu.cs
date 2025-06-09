using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;

namespace trilha_net_explorando_desafio2.Services.SuiteServices
{
    public class SuiteMenu
    {
        public static void Menu(List<Suite> suites)
        {
            bool verificacao;
            int opcao = 0;
            do
            {
                Console.Clear();

                Console.WriteLine("===== Menu de Suites =====");
                Console.WriteLine("[1] - Cadastrar Suite\n[2] - Alterar dados\n[3] - Excluir Suite\n[0] - Voltar ao menu principal\n:");
                verificacao = int.TryParse(Console.ReadLine(), out opcao);

                // Para quando meu ReadLine obter um caracter que não seja int
                if (verificacao == false)
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        suites.Add(SuiteUtilities.CadastrarSuite());
                        break;
                    case 2:
                        SuiteUtilities.AlterarDados(suites);
                        break;
                    case 3:
                        SuiteUtilities.RemoverSuite(suites);
                        break;    
                    case 0:
                        verificacao = false;
                        break;
                    default:
                        verificacao = true;
                        break;
                }

            } while (verificacao);
        }
    }
}
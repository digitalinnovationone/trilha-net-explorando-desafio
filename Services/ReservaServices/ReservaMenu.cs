using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;

namespace trilha_net_explorando_desafio2.Services.ReservaServices
{
    public class ReservaMenu
    {
        public static void Menu(List<Reserva> reservas, List<Pessoa> pessoas, List<Suite> suites)
        {
            if (suites.Count == 0)
            {
                Console.WriteLine($"Necessário cadastrar suítes antes! Quantidade de suítes cadastradas: {suites.Count}");
                Thread.Sleep(2500);

                return;
            }

            if (pessoas.Count == 0)
            {
                Console.WriteLine($"Não há pessoas cadastradas! Quantidade de pessoas cadastradas: {pessoas.Count}");
                Thread.Sleep(2500);

                return;
            }


            bool verificacao;
            int opcao = 0;
            do
            {
                Console.Clear();

                Console.WriteLine("===== Menu de Reservas =====");
                Console.WriteLine("[1] - Cadastrar reserva\n[2] - Alterar dados\n[3] - Excluir Reserva\n[4] - Listar reservas"
                + "\n[0] - Voltar ao menu principal\n:");
                verificacao = int.TryParse(Console.ReadLine(), out opcao);

                // Para quando meu ReadLine obter um caracter que não seja int
                if (verificacao == false)
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        reservas.Add(ReservaUtilities.CadastrarReserva(pessoas, suites));
                        break;
                    case 2:
                        ReservaUtilities.AlterarDados(reservas, pessoas);
                        break;
                    case 3:
                        ReservaUtilities.RemoverReserva(reservas);
                        break;    
                    case 4:
                        ReservaUtilities.ExibirReservas(reservas);
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
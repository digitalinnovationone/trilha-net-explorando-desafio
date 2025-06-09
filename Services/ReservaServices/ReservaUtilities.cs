using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;
using trilha_net_explorando_desafio2.Services.PessoaServices;
using trilha_net_explorando_desafio2.Services.SuiteServices;

namespace trilha_net_explorando_desafio2.Services.ReservaServices
{
    public class ReservaUtilities
    {
        private static void CadastrarHospedes(Reserva reserva, List<Pessoa> pessoas)
        {
            List<Pessoa> hospedes = new List<Pessoa>();
            bool verificacao;

            if (reserva.Hospedes != null)
            {
                if (reserva.Hospedes.Count > 0)
                {
                    hospedes = reserva.Hospedes;
                }
            }

            do
            {
                Console.Clear();


                Console.WriteLine($"Hospedes cadastrados: {hospedes.Count}");
                foreach (Pessoa hospede in hospedes)
                {
                    Console.WriteLine(hospede.NomeCompleto);
                }

                Console.WriteLine($"Capacidade da suíte: {reserva.Suite.Capacidade}\n");

                /*
                    Verificação se hospedes vai ultrapassar a capacidade da suite
                    e já retorna os hospedes que puderam ser cadastrados
                */
                if (hospedes.Count == reserva.Suite.Capacidade)
                {
                    Console.WriteLine("Suite não comporta mais hospedes!");
                    Thread.Sleep(2000);

                    reserva.CadastrarHospedes(hospedes);
                    return;
                }

                Console.WriteLine("Deseja cadastrar hospedes para a reserva?\n[1] - Sim\n[0] - Não\n: ");
                verificacao = int.TryParse(Console.ReadLine(), out int opcao);

                if (verificacao == false)
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        PessoaUtilities.ListarPessoa(pessoas);

                        Console.WriteLine("\nInsira o Id da pessoa que deseja adicionar: ");
                        int.TryParse(Console.ReadLine(), out int id);

                        hospedes.Add(pessoas[id]);

                        break;
                    case 0:
                        reserva.CadastrarHospedes(hospedes);
                        verificacao = false;

                        break;
                    default:
                        verificacao = true;

                        break;
                }

            } while (verificacao);
        }

        private static void CadastrarSuite(Reserva reserva, List<Suite> suites)
        {
            SuiteUtilities.ListarSuite(suites);

            Console.WriteLine("\nInsira o Id da suíte que deseja cadastrar na reserva: ");
            int.TryParse(Console.ReadLine(), out int id);

            reserva.CadastrarSuite(suites[id]);

        }

        private static void RemoverHospede(Reserva reserva)
        {
            if (reserva.Hospedes.Count == 0)
            {
                Console.WriteLine("Não há hospedes cadastrados!");
                Thread.Sleep(2000);

                return ;
            }

            for (int i = 0; i < reserva.ObterQuantidadeHospedes(); i++)
            {
                Console.WriteLine($"=== Id: {i} ===");
                Console.WriteLine($"Hospede: {reserva.Hospedes[i].NomeCompleto}");
            }

            Console.WriteLine("Insira o Id do hospede que deseja remover: ");
            int.TryParse(Console.ReadLine(), out int id);

            reserva.Hospedes.Remove(reserva.Hospedes[id]);

            Console.WriteLine($"Hospede removido com sucesso!");
            Thread.Sleep(2000);            
        }

        public static Reserva CadastrarReserva(List<Pessoa> pessoas, List<Suite> suites)
        {
            Console.WriteLine("Insira quantos dias de alojamneto: ");
            int.TryParse(Console.ReadLine(), out int diasReservados);

            Reserva reserva = new Reserva(diasReservados);

            CadastrarSuite(reserva, suites);
            CadastrarHospedes(reserva, pessoas);

            return reserva;
        }

        public static void ExibirReservas(List<Reserva> reservas)
        {
            if (reservas.Count == 0)
            {
                Console.WriteLine("Não há reservas cadastradas!");
                Thread.Sleep(2000);
            }
            else
            {
                ListarReservas(reservas);

                Console.WriteLine("\nAperte qualquer tecla para continuar...");
                Console.ReadLine();
            }
        }

        private static void ListarReservas(List<Reserva> reservas)
        {
            int i = 0;
            foreach (Reserva reserva in reservas)
            {
                Console.WriteLine($"===== Id: {i++} =====");
                Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
                Console.WriteLine($"Tipo da suíte: {reserva.Suite.TipoSuite}");
                Console.WriteLine($"Quantidade de hospedes: {reserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria():C}");
            }
        }

        public static void AlterarDados(List<Reserva> reservas, List<Pessoa> pessoas)
        {
            if (reservas.Count == 0)
            {
                Console.WriteLine("Não há reservas cadastradas!");
                Thread.Sleep(2000);

                return;
            }

            ListarReservas(reservas);

            Console.WriteLine("\nInsira o Id da reserva que deseja alterar dados: ");
            int.TryParse(Console.ReadLine(), out int id);

            bool verificacao;
            do
            {
                Console.Clear();

                Console.WriteLine($"==== Id: {id} ====");
                Console.WriteLine($"Dias reservados: {reservas[id].DiasReservados}");
                Console.WriteLine($"Quantidade de hospedes: {reservas[id].ObterQuantidadeHospedes()}");

                Console.WriteLine("\nO que deseja alterar?");
                Console.WriteLine("[1] - Alterar dias da reserva");
                Console.WriteLine("[2] - Adicionar hospedes");
                Console.WriteLine("[3] - Remover hospedes");
                Console.WriteLine("[0] - Encerrar\n: ");
                verificacao = int.TryParse(Console.ReadLine(), out int opcao);

                if (verificacao == false)
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Insira a nova quantia de dias: ");
                        int.TryParse(Console.ReadLine(), out int dias);

                        reservas[id].DiasReservados = dias;
                        break;
                    case 2:                           
                        CadastrarHospedes(reservas[id], pessoas);
                        break;
                    case 3:
                        RemoverHospede(reservas[id]);
                        break;
                    case 0:
                        return ;
                    default:
                        verificacao = true;
                        break;
                }

            } while (verificacao);            
        }

        public static void RemoverReserva(List<Reserva> reservas)
        {
            if (reservas.Count == 0)
            {
                Console.WriteLine("Não há reservas cadastradas!");
                Thread.Sleep(2000);

                return;
            }

            ListarReservas(reservas);

            Console.WriteLine("Insira o Id da suíte que deseja remover: ");
            bool verificacao = int.TryParse(Console.ReadLine(), out int id);

            if (verificacao != true || id < 0 || id > reservas.Count)
            {
                Console.WriteLine("Entrada inválida!");
                Thread.Sleep(2000);
            }
            else
            {
                reservas.Remove(reservas[id]);

                Console.WriteLine("Reserva removida com sucesso!");
                Thread.Sleep(2000);
            }
        }
    }
}
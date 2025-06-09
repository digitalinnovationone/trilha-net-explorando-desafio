using DesafioProjetoHospedagem.Models;
using trilha_net_explorando_desafio2.Services;
using trilha_net_explorando_desafio2.Services.ReservaServices;
using trilha_net_explorando_desafio2.Services.SuiteServices;

public class Program
{
    public static void Main(string[] args)
    {
        List<Pessoa> pessoas = new List<Pessoa>();
        List<Reserva> reservas = new List<Reserva>();
        List<Suite> suites = new List<Suite>();
        
        bool verificacao;
        int opcao = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("Qual dos menus deseja acessar?");
            Console.WriteLine("[1] - Pessoa\n[2] - Reserva\n[3] - Suite\n[0] - Encerrar\n:");
            verificacao = int.TryParse(Console.ReadLine(), out opcao);

            if (verificacao == false)
            {
                opcao = -1;
            }

            switch (opcao)
            {
                case 1:
                    PessoaMenu.Menu(pessoas);
                    break;
                case 2:
                    ReservaMenu.Menu(reservas, pessoas, suites);
                    break;
                case 3:
                    SuiteMenu.Menu(suites);
                    break;
                case 0:
                    verificacao = false;
                    break;
                default:
                    verificacao = true;
                    break;
            }
        } while (verificacao);

        Console.WriteLine("Programa finalizado!");
    }
}

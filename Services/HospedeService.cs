using System.Globalization;
using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.Utils;

namespace DesafioProjetoHospedagem.Services;

public class HospedeService
{
    private readonly Reserva _reserva;

    public HospedeService(Reserva reserva)
    {
        _reserva = reserva;
    }

    private string NameOrPosition { get; set; }

    public void CadastrarHospede()
    {
        bool condition;
        do
        {
            string nomeCompleto = InputUtils.LerString("Digite o nome e/ou sobrenome do hóspede\n" +
                                                       "Cada virgula adiciona um hóspede:\n", obrigatorio: true,
                semNumero: true);

            List<string> hospedes = nomeCompleto.Split(',')
                .Select(n => n.Trim())
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(n => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(n.ToLower())).ToList();
            foreach (Pessoa p in hospedes.Select(Pessoa.Criar))
            {
                _reserva.CadastrarHospede(p);
            }

            condition = InputUtils.Confirmar("Deseja cadastrar mais hóspedes?");
            Console.Clear();
        } while (condition);
    }

    public void ListaHospedes()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║       Lista de Hóspedes      ║");
        Console.WriteLine("╠════╦═════════════════════════╣");
        Console.WriteLine("║ #  ║ Nome Completo           ║");
        Console.WriteLine("╠════╬═════════════════════════╣");
        for (int i = 0; i < _reserva.GetQuantidadeHospedes(); i++)
        {
            var hospede = _reserva.GetHospedeByIndex(i);
            Console.WriteLine($"║ {i + 1,-2} ║ {hospede.NomeCompleto,-23} ║");
        }

        Console.WriteLine("╚════╩═════════════════════════╝");

        bool changeConfirm = InputUtils.Confirmar("Deseja alterar a lista de hóspedes?");
        if (changeConfirm)
        {
            ChangeHospede();
        }
    }

    void ChangeHospede()
    {
        bool sair = false;

        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║   Alterar Hóspede      ║");
            Console.WriteLine("╠════════════════════════╣");
            Console.WriteLine("║ 1 ║ Adicionar          ║");
            Console.WriteLine("║ 2 ║ Editar             ║");
            Console.WriteLine("║ 3 ║ Remover            ║");
            Console.WriteLine("║ 4 ║ Listar             ║");
            Console.WriteLine("║ 5 ║ Sair               ║");
            Console.WriteLine("╚════════════════════════╝");

            int select = InputUtils.LerInt("Escolha uma opção (1-5):");

            switch (select)
            {
                case 1:
                    CadastrarHospede();
                    break;
                case 2:
                    NameOrPosition = InputUtils.LerString("Digite o nome ou posição do hóspede:");
                    EditarHospede(NameOrPosition);
                    break;
                case 3:
                    NameOrPosition = InputUtils.LerString("Digite o nome ou posição do hóspede:");
                    RemoverHospede(NameOrPosition);
                    break;
                case 4:
                    ListaHospedes();
                    break;
                case 5:
                    sair = true;
                    ConsoleUtils.EscreverLentamente("Saindo do menu...");
                    break;
                default:
                    ConsoleUtils.EscreverLentamente("Opção inválida! Tente novamente.");
                    break;
            }

            if (!sair)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
        }
    }


    void EditarHospede(string nomeOrPosition)
    {
        Pessoa hospede = _reserva.GetHospede(nomeOrPosition);

        if (hospede == null)
        {
            ConsoleUtils.EscreverLentamente("Hóspede não encontrado!");
            return;
        }

        string newName = InputUtils.LerString("Digite o nome do hóspede novo:", obrigatorio: true, semNumero: true);
        Reserva.AtualizarHospede(hospede, newName);
    }

    private void RemoverHospede(string nomeOrPosition)
    {
        Pessoa hospede = _reserva.GetHospede(nomeOrPosition);
        if (hospede == null)
        {
            ConsoleUtils.EscreverLentamente("Hóspede não encontrado!");
            return;
        }

        _reserva.RemoverHospede(hospede);
    }
    
}
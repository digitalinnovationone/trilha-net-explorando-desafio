using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Hotel hotel = Hotel.GerarHotelInicial();
hotel.GerarSuitesIniciais();

bool menu = true;

while (menu)
{
    hotel.DisplayMenu();
    switch (Console.ReadLine())
    {
        case "1":
            hotel.CadastrarHospedagem();
            break;

        case "2":
            hotel.CadastrarNovaSuite();
            break;

        case "3":
            hotel.ExibirReservas();
            break;

        case "4":
            hotel.ListarSuites();
            break;

        case "5":
            hotel.ListarSuitesOcupadas();
            break;

        case "6":
            menu = false;
            break;

        default:
            Console.WriteLine("Opção Invalida");
            break;
    }
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

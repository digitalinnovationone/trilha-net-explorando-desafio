using System.Text;
using DesafioProjetoHospedagem.Models;
using Models;

Console.OutputEncoding = Encoding.UTF8;

int op = -1;
Hotel hotel = new Hotel();

while (op!=0)
{
    op = -1;
    System.Console.Write(" \n\n\n\n\n\n\n[1] - Nova Suite\n[2] - Nova Reserva \n[3] - Ver Reservas e Suites \n[0] - sair \n Opção - > ");

    if (!int.TryParse(Console.ReadLine(), out op))
    {
        op = -1;
    }

    switch (op)
    {
        case 0:
            break;
        case 1:
            hotel.AddSuite();
            break;
        case 2:
            hotel.AddReserva();
            break;
        case 3:
            hotel.Mostrar();
            break;
        default:
            System.Console.WriteLine("Opção inválida!");
            break;
    }
    
}
using System.Globalization;
using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.Utils;

namespace DesafioProjetoHospedagem.Services;

public class ReservaService
{
    private readonly Reserva _reserva;

    public ReservaService(Reserva reserva, Suite suite)
    {
        _reserva = reserva;
    }
    
    public string CalcularValorDiaria()
    {
        CultureInfo brasil = new CultureInfo("pt-BR");
        decimal valor = _reserva.ValorTotal();

        if (_reserva.GetQuantidadeDias() >= 10)
        {
            decimal desconto = valor * 0.1m;
            Console.WriteLine();
            Console.WriteLine("Desconto de 10%");
            Console.WriteLine($"Economizou {desconto.ToString("C", brasil)}!");
            valor *= 0.9m;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Sem desconto");
        }

        return $"Valor final: {valor.ToString("C", brasil)}";
    }

    
}
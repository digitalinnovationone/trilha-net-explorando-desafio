using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.Utils;

namespace DesafioProjetoHospedagem.Services;

public class SuiteService
{
    private readonly Reserva _reserva;

    public SuiteService(Reserva reserva)
    {
        _reserva = reserva;
    }

    public void CadastrarSuite()
    {
        var suite = new Suite();
        var tipoSuite = InputUtils.SelecionarTipoSuite();
        suite.TipoSuite = tipoSuite;
        _reserva.CadastrarSuite(suite);
        _reserva.DiasReservados =
            InputUtils.LerInt("Quantidade de dias hospedado (10 dias ou mais aplica desconto de 10%):");
        Console.Clear();
    }

}
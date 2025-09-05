using System.Text;
using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.Services;

Console.OutputEncoding = Encoding.UTF8;

Reserva reserva = new Reserva();
Suite suite = new Suite();

ReservaService reservaService = new ReservaService(reserva, suite);
SuiteService suiteService = new SuiteService(reserva);
HospedeService hospedeService = new HospedeService(reserva);
suiteService.CadastrarSuite();
hospedeService.CadastrarHospede();
hospedeService.ListaHospedes();
reservaService.CalcularValorDiaria();

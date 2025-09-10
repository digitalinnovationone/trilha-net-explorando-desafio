using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

Console.OutputEncoding = Encoding.UTF8;

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 30);

// Modificação de mdlpontual: Cria um hóspede titular para impedir que a reserva seja criada sem hóspedes iniciais.
Pessoa pTitular = new Pessoa(nome: "Hóspede Titular");

// Modificação de mdlpontual: Variável específica para os dias a serem reservados.
int diasReservados = 20;

// Modificação de mdlpontual: Para criar a reserva, agora é obrigatório informar um hóspede titular e uma suíte já existente (ex.: selecionada de um banco de dados).
Reserva reserva = new Reserva(suite, pTitular, diasReservados);

// Modificação de mdlpontual: CadastrarHospedes() agora apenas acrescenta hóspedes extras que acompanham o titular.
List<Pessoa> hospedes = new List<Pessoa>();
Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");
Pessoa p3 = new Pessoa(nome: "Hóspede 3");
hospedes.Add(p1);
hospedes.Add(p2);
hospedes.Add(p3);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
// Modificação de mdlpontual: Mostrar o valor do desconto com ajuda de uma tupla.
var (valor, valorDoDesconto) = reserva.CalcularValorDiaria();

Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {valor:C}");
Console.WriteLine($"Valor do desconto: {valorDoDesconto:C}");



// Codigo original modificado:
/* 
using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 15);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
// Modificação de mdlpontual: mostrar o valor do desconto com ajdua de uma tupla
var (valor, valorDoDesconto) = reserva.CalcularValorDiaria();

Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {valor:C}");
Console.WriteLine($"Valor do desconto: {valorDoDesconto:C}"); 
*/
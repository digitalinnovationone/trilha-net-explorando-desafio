using System.Text;
using DesafioProjetoHospedagem.Models;
using Terminal.Gui;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = new Suite();


Application.Init();
var top = Application.Top;

// Creates the top-level window to show
var win = new Window(new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1), "Sistema de Hospedagem");
top.Add(win);

// Creates a menubar, the item "New" has a help menu.
var menu = new MenuBar(new MenuBarItem[] {
    new MenuBarItem ("_Cadastros", new MenuItem [] {
        new MenuItem ("_Hóspedes", "Nova pessoa", ()=> { cadastrar_Hospedes(); }),
        new MenuItem ("_Suite", "Novo quarto", () => { criar_suite(); }),
        new MenuItem ("Sai_r", "Fechar", () => { sair(); })
    }),
    new MenuBarItem ("R_eservas", new MenuItem [] {
        new MenuItem ("Re_gistrar", "Criar reserva", ()=>{ fazer_reservas(); }),
    })
});
top.Add(menu);

// Add some controls
win.Add(
    new Label(9, 2, "-------------BEM-VINDO(A)--------------"),
    new Label(9, 4, "Atalhos do sistema:"),
    new Label(9, 5, "Menu: ALT+C - Cadastros"),
    new Label(9, 6, "    : ALT+H - hóspedes"),
    new Label(9, 7, "    : ALT+S - suite"),
    new Label(9, 8, "    : ALT+R - sair"),
    new Label(9, 9, "Menu: ALT+E - Reservas"),
    new Label(9, 10, "    : ALT+G - registrar"),

    new Label(3, 25, "Press Ctrl + Q para sair!"));

Application.Run();
//MessageBox.Query("Hello", "Hello There!", "Ok");

void sair()
{
    MessageBox.Query("Desfio DIO - .NET", "Obrigado por usar!", "Ok");
    top.Running = false;
}
// Cria os modelos de hóspedes e cadastra na lista de hóspedes
void cadastrar_Hospedes()
{
    // Create input components and labels
    var hospede1lbl = new Label(3, 12, "Nome do hóspede 1:");

    var hospede1Text = new TextField(25, 12, 30, "");

    var hospede2lbl = new Label(3, 13, "Nome do hóspede 2:");

    var hospede2Text = new TextField(25, 13, 30, "");

    // Create  button
    var btnSalvarHospede = new Button()
    {
        Text = "Salvar",
        Y = Pos.Bottom(hospede2lbl) + 1,
        // center the  button horizontally
        X = Pos.Left(hospede2Text),
        IsDefault = true,
    };

    // When button is clicked display a message popup
    btnSalvarHospede.Clicked += () =>
    {
        if (hospede1Text.Text != "" && hospede2Text.Text != "")
        {
            Pessoa p1 = new Pessoa(nome: hospede1Text.Text.ToString());
            Pessoa p2 = new Pessoa(nome: hospede2Text.Text.ToString());
            hospedes.Add(p1);
            hospedes.Add(p2);
            win.Remove(hospede1lbl);
            win.Remove(hospede1Text);
            win.Remove(hospede2lbl);
            win.Remove(hospede2Text);
            win.Remove(btnSalvarHospede);
            MessageBox.Query("Aviso", "Registrao salvo com sucesso", "Ok");
            exibeDados();
        }
        else
        {
            MessageBox.ErrorQuery("Atenção", "Dados informados são inválidos", "Ok");
        }
    };

    win.Add(hospede1lbl, hospede1Text, hospede2lbl, hospede2Text, btnSalvarHospede);

}

// Cria a suíte
void criar_suite()
{
    var tipoSuitelbl = new Label(3, 12, "Tipo de Suite:");

    var tipoSuiteText = new TextField(25, 12, 30, "");

    var capacidadelbl = new Label(3, 13, "Sua capacidade:");

    var capacidadeText = new TextField(25, 13, 30, "");

    var valorDiarialbl = new Label(3, 14, "Valor da Diaria:");

    var valorDiariaText = new TextField(25, 14, 30, "");

    // Create login button
    var btnSalvarSuite = new Button()
    {
        Text = "Salvar",
        Y = Pos.Bottom(valorDiarialbl) + 1,
        // center the login button horizontally
        X = Pos.Left(valorDiariaText),
        IsDefault = true,
    };
    btnSalvarSuite.Clicked += () =>
    {
        if (tipoSuiteText.Text != "" && capacidadeText.Text != "" && valorDiariaText.Text != "")
        {
            suite = new Suite(tipoSuite: tipoSuiteText.Text.ToString(), capacidade: int.Parse(capacidadeText.Text.ToString()), valorDiaria: decimal.Parse(valorDiariaText.Text.ToString()));

            win.Remove(tipoSuitelbl);
            win.Remove(tipoSuiteText);
            win.Remove(capacidadelbl);
            win.Remove(capacidadeText);
            win.Remove(btnSalvarSuite);
            win.Remove(valorDiarialbl);
            win.Remove(valorDiariaText);
            MessageBox.Query("Aviso", "Registrao salvo com sucesso", "Ok");
            exibeDados();
        }
        else
        {
            MessageBox.ErrorQuery("Atenção", "Dados informados são inválidos", "Ok");
        }
    };

    win.Add(tipoSuitelbl, tipoSuiteText, capacidadelbl, capacidadeText, valorDiarialbl, valorDiariaText, btnSalvarSuite);

}


// Cria uma nova reserva, passando a suíte e os hóspedes
void fazer_reservas()
{
    var erro = false;
    if (suite.Capacidade.ToString() == "")
    {
        erro = true;
        MessageBox.ErrorQuery("Atenção", "Precisa cadastra um Suite antes de continuar", "Ok");
    }
    if (hospedes.Count <= 0)
    {
        erro = true;
        MessageBox.ErrorQuery("Atenção", "Precisa cadastra hóspdedes antes de continuar", "Ok");
    }
    if (!erro)
    {
        var diaReservadosLbl = new Label(3, 12, "Qtde dias Reservados:");

        var diaReservadosText = new TextField(25, 12, 30, "");
        // Create  button
        var btnSaveReservas = new Button()
        {
            Text = "Salvar",
            Y = Pos.Bottom(diaReservadosLbl) + 1,
            // center the  button horizontally
            X = Pos.Left(diaReservadosText),
            IsDefault = true,
        };

        // When button is clicked display a message popup
        btnSaveReservas.Clicked += () =>
        {
            if (diaReservadosText.Text != "")
            {
                Reserva reserva = new Reserva(diasReservados: int.Parse(diaReservadosText.Text.ToString()));
                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);

                // Exibe a quantidade de hóspedes e o valor da diária
                var hospedesLbl = new Label(3, 17, $"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                var valordiariaLbl = new Label(3, 18, $"Valor total diária R$: {reserva.CalcularValorDiaria()}");

                // Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                // Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

                win.Remove(diaReservadosLbl);
                win.Remove(diaReservadosText);
                win.Remove(btnSaveReservas);
                win.Add(hospedesLbl, valordiariaLbl);
                exibeDados();
                MessageBox.Query("Aviso", "Registrao salvo com sucesso", "Ok");
                exibeDados();
            }
            else
            {
                MessageBox.ErrorQuery("Atenção", "Dados informados são inválidos", "Ok");
            }
        };

        win.Add(diaReservadosLbl, diaReservadosText, btnSaveReservas);

    }

}


void exibeDados()
{
    var suiteLbl = new Label(3, 20, $"Nome da Suite: {suite.TipoSuite}");
    var valorLbl = new Label(3, 21, $"Diária R$: {suite.ValorDiaria}");
    var capcidadeLbl = new Label(3, 22, $"Max Capacidade: {suite.Capacidade}");

    win.Add(suiteLbl, valorLbl, capcidadeLbl);

}
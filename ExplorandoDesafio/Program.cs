using ExplorandoDesafio.Models;

List<Reserva> reservas = new List<Reserva>();

Suite suite1 = new Suite(01, "Padrão", 02, 180m, true);
Suite suite2 = new Suite(02, "Premiun", 01, 180m, true);
Suite suite3 = new Suite(03, "Padrão", 04, 320m, true);
Suite suite4 = new Suite(04, "Padrão", 02, 180m, true);
Suite suite5 = new Suite(04, "Premiun", 02, 2500m, true);

Dictionary<Suite, object> quartosDict = new Dictionary<Suite, object>
{
    {suite1, suite1.Status},
    {suite2, suite2.Status},
    {suite3, suite3.Status},
    {suite4, suite4.Status},
    {suite5, suite5.Status}

};

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar Hospede");
    Console.WriteLine("2 - Listar Suites");
    Console.WriteLine("3 - Listar Hospedes");
    Console.WriteLine("4 - Encerrar Reserva");
    

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Número da Suite a ser reservada: ");
            int numeroQuarto = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Dias locados: ");
            int diasDaReserva = Convert.ToInt16(Console.ReadLine());

            Suite quartoReservado = null;

            foreach (var item in quartosDict)
            {
                if (item.Key.NumeroQuarto == numeroQuarto && (bool)item.Value)
                {
                    quartoReservado = item.Key;
                    break;
                }
            }

            if (quartoReservado == null)
            {
                Console.WriteLine("Suíte não disponível ou inexistente.");
                break;
            }

            Console.WriteLine("Número de hóspedes: ");
            int numHospedes = Convert.ToInt16(Console.ReadLine());

            if (numHospedes > quartoReservado.Capacidade)
            {
                Console.WriteLine("O número de hóspedes excede a capacidade da suíte.");
                break;
            }

            List<Pessoa> hospedesList = new List<Pessoa>();
            for (int i = 0; i < numHospedes; i++)
            {
                Console.WriteLine($"Nome do hóspede {i + 1}:");
                string nomeHospede = Console.ReadLine();

                Console.WriteLine($"Sobrenome do hóspede {i + 1}:");
                string sobrenomeHospede = Console.ReadLine();

                hospedesList.Add(new Pessoa(nomeHospede, sobrenomeHospede));
            }

            Reserva reserva = new Reserva(diasDaReserva, quartoReservado);
            reserva.CadastrarHospesdes(hospedesList);
            reserva.ReservandoQuarto(quartosDict);

            reservas.Add(reserva);

            break;

        case "2":
            foreach (var suite in quartosDict)
            {   
                string status = ((bool)suite.Value) ? "Disponivel" : "Ocupada";
                Console.WriteLine($"Suite: {suite.Key.PadraoSuite} Capacidade: {suite.Key.Capacidade} pessoas, Está: {status}, Diaria: {suite.Key.ValorDiaria}");
            }
            break;

         case "3":
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
            }
            else
            {
                foreach (var res in reservas)
                {
                    var valorEstadia = res.CalcularValorDiaria();
                    Console.WriteLine($"Reserva para a suíte {res.Suite.NumeroQuarto}:");
                    foreach (var hospede in res.Hospedes)
                    {
                        Console.WriteLine($"  Hospede - {hospede.NomeCompleto}");
                        Console.WriteLine($"  Total da Estadia - {valorEstadia}");
                        Console.WriteLine($"  Dias reservados - {res.DiasReservados}");
                    }
                }
            }
            break;
        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
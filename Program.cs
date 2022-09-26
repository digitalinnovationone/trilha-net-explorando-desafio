using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;
            List<Pessoa> hospedes = new List<Pessoa>();
            Pessoa p1 = new Pessoa(nome: "Hóspede 1");
            Pessoa p2 = new Pessoa(nome: "Hóspede 2");

            hospedes.Add(p1);
            hospedes.Add(p2);

            // Cria a suíte
            Console.Write("Qual será o tipo da Suíte? ");
            string tipoSuite = Console.ReadLine();
            Console.Write("Qual a capacidade da Suíte? ");
            int capacidade = int.Parse(Console.ReadLine());
            Console.Write("Qual a diária da Suíte escolhida? ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Suite suite = new Suite(tipoSuite: tipoSuite, capacidade: capacidade, valorDiaria: valorDiaria);

            // Cria uma nova reserva, passando a suíte e os hóspedes
            Reserva reserva = new Reserva(diasReservados: 10);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            // Exibe a quantidade de hóspedes e o valor da diária
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
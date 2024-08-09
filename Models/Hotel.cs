
using DesafioProjetoHospedagem.Exception;
using Newtonsoft.Json;

namespace DesafioProjetoHospedagem.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Suite> Suites { get; set; } = new List<Suite>();
        public List<Suite> SuitesOcupadas { get; set; } = new List<Suite>();
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public Hotel() { }
        public Hotel(int id, string nome, string endereco)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            SuitesOcupadas = new List<Suite>();
        }
        public static Hotel GerarHotelInicial()
        {
            string caminhoArquivo = File.ReadAllText("./Arquivos/hotel.json");
            Hotel hotel = JsonConvert.DeserializeObject<Hotel>(caminhoArquivo);
            return hotel;
        }
        public void GerarSuitesIniciais()
        {
            string caminhoArquivo = File.ReadAllText("./Arquivos/suite.json");
            List<Suite> suites = JsonConvert.DeserializeObject<List<Suite>>(caminhoArquivo);
            Suites.AddRange(suites);
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine($"Bem vindo ao Sistema de Hospedagem da {Nome}");
            Console.WriteLine("1-Cadastrar Hospedagem");
            Console.WriteLine("2-Cadastrar Suite");
            Console.WriteLine("3-Exibir Reservas");
            Console.WriteLine("4-Suites Disponíveis");
            Console.WriteLine("5-Suites Ocupadas");
            Console.WriteLine("6-Encerrar");
        }

        public void CadastrarHospedagem()
        {
            List<Pessoa> hospedes = new();
            int diasReservado;

            Console.Write("Quantos dias será a reserva: ");
            diasReservado = int.Parse(Console.ReadLine());
            try
            {
                Reserva reserva = Reserva.CriarReserva(diasReservado);
                Suite suite = EscolherSuite();

                if (suite == null)
                {
                    Console.WriteLine("Suite Indisponnível");
                    return;
                }

                int idSuite = reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);
                Reservas.Add(reserva);
                ReservarSuite(idSuite);
                string comprovante = reserva.GerarComprovanteReserva();
                Console.WriteLine(comprovante);
            }
            catch (CapacidadeExcedidaException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CapacidadeInvalidaException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CadastrarNovaSuite()
        {
            Suite suite = Suite.CadastrarSuite();
            Suites.Add(suite);
        }

        public void ExibirReservas()
        {
            if (Reservas == null || Reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
                return;
            }

            foreach (var reserva in Reservas)
            {
                string descricaoReserva = reserva.GerarComprovanteReserva();
                Console.WriteLine(descricaoReserva);
            }
        }

        public Suite EscolherSuite()
        {
            string numeroSuite;

            ListarSuites();

            Console.Write("\nQual será a suite escolhida: ");
            numeroSuite = Console.ReadLine();

            if (!int.TryParse(numeroSuite, out int id))
            {
                Console.WriteLine("Número da suite inválido");
                return null;
            }
            Suite suiteEscolhida = Suites.FirstOrDefault(e => e.Id == id);

            return suiteEscolhida;
        }

        private void ReservarSuite(int id)
        {
            Suite suite = Suites.SingleOrDefault(e => e.Id == id);
            Suites.Remove(suite);
            SuitesOcupadas.Add(suite);
        }

        public void ListarSuites()
        {

            if (Suites.Count == 0)
            {
                Console.WriteLine("Nenhuma suíte disponível.");
                return;
            }

            Console.WriteLine("\n----------Suites disponíveis----------- \n");

            foreach (var suite in Suites)
            {
                Console.WriteLine(suite.GerarDescricaoSuite());
            }

        }
        public void ListarSuitesOcupadas()
        {
            foreach (var suite in SuitesOcupadas)
            {
                Console.WriteLine(suite.GerarDescricaoSuite());
            }
        }
    }
}
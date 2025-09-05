using DesafioProjetoHospedagem.Models

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sistema de Hospedagem de Hotel");
        Console.WriteLine("==============================");
        
        try
        {
            // Criar suítes disponíveis
            var suitePremium = new Suite("Premium", 2, 250.00m);
            var suiteLuxo = new Suite("Luxo", 4, 400.00m);
            var suiteFamilia = new Suite("Família", 6, 550.00m);
            
            // Criar hóspedes
            var hospede1 = new Pessoa("João", "Silva");
            var hospede2 = new Pessoa("Maria", "Santos");
            var hospede3 = new Pessoa("Pedro", "Costa");
            
            // Criar reserva
            var reserva = new Reserva(12); // 12 dias de reserva
            
            // Cadastrar suíte
            reserva.CadastrarSuite(suiteLuxo);
            
            // Cadastrar hóspedes
            var hospedes = new List<Pessoa> { hospede1, hospede2, hospede3 };
            reserva.CadastrarHospedes(hospedes);
            
            // Exibir informações da reserva
            Console.WriteLine("\nReserva criada com sucesso!");
            Console.WriteLine($"Suíte: {reserva.Suite.TipoSuite}");
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
            Console.WriteLine($"Valor total: R$ {reserva.CalcularValorDiaria():F2}");
            
            // Exibir lista de hóspedes
            Console.WriteLine("\nLista de Hóspedes:");
            foreach (var hospede in reserva.Hospedes)
            {
                Console.WriteLine($"- {hospede.NomeCompleto}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
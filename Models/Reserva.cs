using System.Drawing;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void ValorDiaria()
        {
            Console.WriteLine($"Diária: {Suite.ValorDiaria}");

        }

        public void DiasDeReserva()
        {
            Console.WriteLine($"Dias Reservados: {DiasReservados}");

        }

        public decimal valorTotal()
        { 
            return DiasReservados * Suite.ValorDiaria;
        }

        public void DescontoValor()
        {
            bool totalDiasReservados = DiasReservados >= 10;

            if (totalDiasReservados)
            {
                Console.WriteLine($"Desconto de 10% sobre o valor total {valorTotal()}. Pois a reserva foi igual/acima de 10 dias ");
                Console.WriteLine("------------------------------------"); 
            }
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*

            var capacidade = hospedes.Count <= Suite.Capacidade; 

            if (capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*         

                throw new Exception($"Capacidade não permitida, somente acima de {Suite.Capacidade}.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*

            foreach (var hospede in Hospedes)
            {
                Console.WriteLine($"Hospede: {hospede.NomeCompleto}" );
            }

            Console.WriteLine($"Total Hospedes: { Hospedes.Count }");
            Console.WriteLine("------------------------------------");

            return 0;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = valorTotal();

            decimal desconto =  (0.1M * valor) ;

            bool totalDiasReservados = DiasReservados >= 10;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (totalDiasReservados)
            {
                valor = valor - desconto;
            }

            return valor;
        }
    }
}
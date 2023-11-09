using DesafioProjetoHospedagem.Models;

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

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            Suite suite = new Suite();
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (suite.Capacidade < hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                Console.WriteLine("Quantidade de hóspede maior que a capacidade da suite");
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return 0;
        }

        public decimal CalcularValorDiaria()
        {

            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = 0;
            decimal diasReservados = 0;
            decimal valortotal = valor * diasReservados;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (diasReservados >= 10)
            {
                valortotal = (valortotal - ((valortotal * 10) / 100));
            }

            return valor;
        }
    }
}
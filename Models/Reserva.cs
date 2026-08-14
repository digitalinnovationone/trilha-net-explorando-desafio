using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            Hospedes = hospedes;
            if (Suite.Capacidade >= hospedes.Count )
            {
                Console.WriteLine("Reserva realizada");
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
            throw new ArgumentException("Reserva bloqueada, O número de hospedes é maior que a capacidade da suíte");
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
            return Hospedes.Count;
        }
        private int array;
        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = Suite.ValorDiaria;
            decimal dias = DiasReservados;
            decimal valordesconto;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (dias >= 10)
            {
                valordesconto = valor * 0.90m;
                Console.WriteLine($"Valor com desconto: {valordesconto * dias}");
            }
            else
            {
                Console.WriteLine($"Valor total: {valor * DiasReservados}");
            }

            return valor;
        }
    }
}
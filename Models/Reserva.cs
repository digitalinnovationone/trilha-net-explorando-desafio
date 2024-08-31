using System.Diagnostics.Metrics;

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
            // IMPLEMENTADO

            if (hospedes.Count <= 4)
            {
                Hospedes = hospedes;
            }
            else
            {
                // IMPLEMENTADO
                throw new InvalidOperationException("A capacidade da suíte suporta apenas 4 hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // IMPLEMENTADO
            
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // IMPLEMENTADO
            decimal valor = DiasReservados * Suite.ValorDiaria;
            
            // IMPLEMENTADO
            if (DiasReservados >= 10)
            {
                valor = valor * 0.90m;
            }

            return valor;
        }
    }
}
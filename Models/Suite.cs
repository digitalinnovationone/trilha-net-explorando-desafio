using System.Diagnostics;

namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public void RecebeSuite()
        {
            System.Console.Write("Tipo de suite : ");
            TipoSuite = Console.ReadLine();
            int capacidade = 0;
            decimal diaria= 0.00M;
            System.Console.Write("Capacidade de hóspedes : ");
            while (!int.TryParse(Console.ReadLine(), out capacidade)  ||  capacidade < 1)// caber pelo menos 1
            {
                System.Console.WriteLine("VALOR INVÁLIDO!");
                System.Console.Write("Capacidade de hóspedes : ");
            }
            Capacidade = capacidade;
            System.Console.Write("Valor da diária : ");
            while (!decimal.TryParse(Console.ReadLine(), out diaria))
            {
                System.Console.WriteLine("VALOR INVÁLIDO!");
                System.Console.Write("Valor da diária : ");
            }
            ValorDiaria = diaria;
        }

        public void MostrarSuite()
        {
            System.Console.WriteLine($"Tipo : {TipoSuite}, capacidade : {Capacidade}, valor da diária : {ValorDiaria.ToString("C")}.");
        }

    }
}
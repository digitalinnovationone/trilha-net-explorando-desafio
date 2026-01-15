namespace DesafioProjetoHospedagem.Models
{
    using System.Globalization;

    public class SuiteInfo { public decimal ValorDiaria { get; set; } public int Disponiveis { get; set; } }
    public class Suite
    {
        public Suite(string tipoSuite)
        {
            if (!CatalogoSuites.ContainsKey(tipoSuite))
            {
                throw new ArgumentException("Não encontrado a suíte pesquisada");
            }
            TipoSuite = tipoSuite;
            Capacidade = CatalogoSuites[tipoSuite].Disponiveis;
            ValorDiaria = CatalogoSuites[tipoSuite].ValorDiaria;
        }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite; 
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        private static readonly Dictionary<string, SuiteInfo> CatalogoSuites =
        new()
        {
            { "Premium", new SuiteInfo { ValorDiaria = 2800M, Disponiveis = 4 } },
            { "Master Pluss", new SuiteInfo { ValorDiaria = 1300M, Disponiveis = 7 } },
            { "Pluss", new SuiteInfo { ValorDiaria = 500M,  Disponiveis = 14 } },
            { "Moderna", new SuiteInfo { ValorDiaria = 230M,  Disponiveis = 23 } },
            { "Simples", new SuiteInfo { ValorDiaria = 120M,  Disponiveis = 11 } }
        };

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
    }
}
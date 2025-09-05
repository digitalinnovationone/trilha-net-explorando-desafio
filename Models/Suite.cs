using System.Diagnostics;

namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        private string _tipoSuite;
        private int _capacidade;
        private decimal _valorDiaria;

        public Suite()
        {
        }

        private static readonly string[] TiposValidos = { "BÁSICO", "MÉDIO", "LUXO" };
        public string TipoSuite 
        { 
            get => _tipoSuite;
            set
            {
                if (string.IsNullOrEmpty(value) || !TiposValidos.Contains(value.ToUpper()))
                    throw new ArgumentException("Tipo de suíte inválido.");
                _tipoSuite = value.ToUpper();
                _valorDiaria = _tipoSuite switch
                {
                    "BÁSICO" => 100m,
                    "MÉDIO"  => 300m,
                    "LUXO"   => 500m,
                    _ => throw new ArgumentException("Tipo de suíte inválido.")
                };
                
                _capacidade = _tipoSuite switch
                {
                    "BÁSICO" => 2,
                    "MÉDIO"  => 4,
                    "LUXO"   => 6,
                    _ => throw new ArgumentException("Tipo de suíte inválido.")
                };
            }
        }

        public int Capacidade
        {
            get => _capacidade;
        }

        public decimal ValorDiaria
        {
            get => _valorDiaria;
        }
    }
}
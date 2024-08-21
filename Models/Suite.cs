namespace DesafioProjetoHospedagem.Models
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    enum TipoSuite
    {
        [Description("Premium")]
        PREMIUM,
        [Description("Super")]
        SUPER,
        [Description("Standard")]
        STANDARD
    }

    /// <summary>
    /// Classe que representa uma suíte do hotel
    /// </summary>
    /// <param name="tipoSuite">Tipo de suíte</param>
    /// <param name="capacidade">Quantidade de hóspedes da suíte</param>
    /// <param name="valorDiaria">Valor da diária</param>
    public class Suite(String tipoSuite, Int32 capacidade, Decimal valorDiaria)
    {

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public Suite() : this(String.Empty, 0, Decimal.Zero)
        { 
        }

        /// <summary>
        /// Tipo de suíte
        /// </summary>
        public String TipoSuite { get; set; } = tipoSuite;

        /// <summary>
        /// Quantidade de hóspedes da suíte
        /// </summary>
        public Int32 Capacidade { get; set; } = capacidade;

        /// <summary>
        /// Valor da diária
        /// </summary>
        public Decimal ValorDiaria { get; set; } = valorDiaria;

        /// <summary>
        /// Retorna uma representação da classe utilizando uma estrutura específica
        /// </summary>
        /// <returns>Uma String com os valores da classe interpolados</returns>
        public override String ToString()
        {
            return $"Tipo de suíte: {TipoSuite} - Capacidade: {Capacidade} pessoas - Valor da diária: {ValorDiaria.ToString("C2", CultureInfo.CurrentCulture)}";
        }
    }
}
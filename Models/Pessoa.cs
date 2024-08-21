namespace DesafioProjetoHospedagem.Models
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Classe que representa uma pessoa
    /// </summary>
    /// <param name="nome">Nome da pessoa</param>
    /// <param name="sobrenome">Sobrenome da pessoa</param>
    /// <param name="idade">Idade da pessoa</param>
    public class Pessoa(String nome, String sobrenome, Int32 idade)
    {

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        /// <param name="nome">Nome da pessoa</param>
        public Pessoa(String nome) : this(nome, String.Empty, 0)
        {
        }

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public Pessoa() : this(String.Empty, String.Empty, 0)
        {
        }

        /// <summary>
        /// Nome da pessoa
        /// </summary>
        public String Nome { get; set; } = nome;

        /// <summary>
        /// Sobrenome da pessoa
        /// </summary>
        public String Sobrenome { get; set; } = sobrenome;

        /// <summary>
        /// Nome completo da pessoa
        /// </summary>
        public String NomeCompleto => $"{Nome} {Sobrenome}".ToUpper(CultureInfo.CurrentCulture);

        /// <summary>
        /// Idade da pessoa
        /// </summary>
        public Int32 Idade { get; set; } = idade;

        /// <summary>
        /// Retorna uma representação da classe utilizando uma estrutura específica
        /// </summary>
        /// <returns>Uma String com os valores da classe interpolados</returns>
        public override String ToString()
        {
            return $"Nome: {NomeCompleto} - idade: {Idade}";
        }
    }
}

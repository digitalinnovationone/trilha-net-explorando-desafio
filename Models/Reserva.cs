namespace DesafioProjetoHospedagem.Models
{
    using DesafioProjetoHospedagem.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Classe que representa uma reserva feita por uma pessoa
    /// </summary>
    /// <param name="diasReservados">Quantidade de dias que a pessoa irá ficar hospedado.</param>
    public class Reserva(Int32 diasReservados)
    {

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public Reserva() : this(0)
        { 
        }

        /// <summary>
        /// Quantidade de pessoas que irão utilizar a suíte do hotel
        /// </summary>
        public IEnumerable<Pessoa> Hospedes { get; private set; }

        /// <summary>
        /// Suite escolhida pela pessoa
        /// </summary>
        public Suite Suite { get; private set; }

        /// <summary>
        /// Quantidade de dias que a pessoa irá ficar hospedado.
        /// </summary>
        public Int32 DiasReservados { get; set; } = diasReservados;

        /// <summary>
        /// Método que cadastra os hóspedes
        /// </summary>
        /// <param name="hospedes">Hóspedes que serão cadastrados</param>
        public void CadastrarHospedes(Pessoa[] hospedes)
        {
            ArgumentNullException.ThrowIfNull(hospedes);
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (Suite.Capacidade > (hospedes.Length-1))
            {
                Hospedes = [.. hospedes];
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new CadastrarHospedesException($"A suite escolhida não tem capacidade suficiente para hospedar todos os hóspedes.\nCapacidade da suíte: {Suite.Capacidade}\nTotal de hóspedes: {hospedes.Length}");
            }
        }

        /// <summary>
        /// Cadastra a suíte escolhida pela pessoa
        /// </summary>
        /// <param name="suite">Suíte escolhida pela pessoa</param>
        public void CadastrarSuite(Suite suite)
        {
            ArgumentNullException.ThrowIfNull(suite);
            Suite = suite;
        }

        /// <summary>
        /// Retorna a quantidade de pessoas cadastradas
        /// </summary>
        /// <returns></returns>
        public Int32 ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            return Hospedes.Count();
        }

        /// <summary>
        /// Calcula o valor da diária
        /// </summary>
        /// <returns>Retorna o valor da diária</returns>
        public Decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            Decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados > 9)
            {
                valor = valor - (valor * 0.10M);
            }

            return valor;
        }

        /// <summary>
        /// Retorna uma representação da classe utilizando uma estrutura específica
        /// </summary>
        /// <returns>Uma String com os valores da classe interpolados</returns>
        public override String ToString()
        {
            return $"Hóspedes: {ObterQuantidadeHospedes()}\nDias reservados: {DiasReservados}\nValor diária: {CalcularValorDiaria()}";
        }
    }
}
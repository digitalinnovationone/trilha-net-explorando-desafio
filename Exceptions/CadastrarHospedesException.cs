namespace DesafioProjetoHospedagem.Exceptions
{
    using System;
    /// <summary>
    /// Classe que representa um erro ao tentar cadastrar uma determinada quantidade de hóspedes em uma suíte 
    /// </summary>
    public sealed class CadastrarHospedesException : Exception
    {
        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public CadastrarHospedesException() : base()
        {

        }
 
        /// <summary>
        /// Método construtor da classe
        /// </summary>
        /// <param name="message">Mensagem que será exibida ao usuário</param>
        public CadastrarHospedesException(String message) : base(message)
        {
        }

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        /// <param name="message">Mensagem que será exibida ao usuário</param>
        /// <param name="innerException">Pilha contendo mais detalhes sobre a exceção</param>
        public CadastrarHospedesException(String message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

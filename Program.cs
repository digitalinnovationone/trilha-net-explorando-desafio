namespace DesafioProjetoHospedagem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DesafioProjetoHospedagem.Extensions;
    using DesafioProjetoHospedagem.Models;

    /// <summary>
    /// Classe que representa o programa
    /// </summary>
    public partial class Program : IDisposable
    {
        //Mensagens utilizadas na classe
        private readonly String _inicioProgramaMessage = "Sistema de hotel";
        private readonly String _dadosReserva = "Dados da reserva:";
        private readonly String _pessoasUtilizandoReserva = "Pessoas que farão parte da reserva:";
        private readonly String _finalizacaoPrograma = "Pressione uma tecla para poder finalizar o programa...";

        private Boolean _disposable;

        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public Program()
        {
            _disposable = true;
        }

        /// <summary>
        /// Método destrutor da classe
        /// </summary>
        /// <param name="disposing">Executa rotinas adicionais</param>
        protected virtual void Dispose(Boolean disposing)
        {
            if (_disposable && disposing)
            {
                _disposable = false;
            }
        }

        /// <summary>
        /// Método destrutor da classe
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Método destrutor da classe
        /// </summary>
        ~Program()
        {
            Dispose(false);
        }

        /// <summary>
        /// Método de execução do programa
        /// </summary>
        public void Execute()
        {
            Console.OutputEncoding = Encoding.UTF8;
                
            // Cria os modelos de hóspedes e cadastra na lista de hóspedes
            List<Pessoa> hospedes = [];
            var newLine = new String('=', 50);
            var total = Faker.RandomNumber.Next(1,10);
            var pos = 0;
            while(pos < total)
            {
                hospedes.Add(new Pessoa(nome: Faker.Name.First(), sobrenome: Faker.Name.Last(), idade: Faker.RandomNumber.Next(total < 2 ? 18 : 0, 100)));
                pos++;
            }

            // Cria a suíte
            var suite = new Suite(tipoSuite: Faker.Enum.Random<TipoSuite>().GetDescription(), 
                                  capacidade: Faker.RandomNumber.Next(2, 10), 
                                  valorDiaria: Faker.RandomNumber.Next(20, 50));

            // Cria uma nova reserva, passando a suíte e os hóspedes
            var reserva = new Reserva(diasReservados: Faker.RandomNumber.Next(2,15));
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes([.. hospedes]);

            // Exibe a quantidade de hóspedes e o valor da diária
            Console.WriteLine(newLine);
            Console.WriteLine(_inicioProgramaMessage);
            Console.WriteLine(newLine);
            Console.WriteLine($"Suíte selecionada: {suite}");
            Console.WriteLine(newLine);
            Console.WriteLine(_dadosReserva);
            Console.WriteLine($"{reserva}");
            Console.WriteLine(newLine);
            Console.WriteLine(_pessoasUtilizandoReserva);
            foreach(var pessoa in hospedes)
            {
                Console.WriteLine(pessoa);
            }
            Console.WriteLine(newLine);
            Console.WriteLine(_finalizacaoPrograma);
            Console.ReadKey();
        }

        /// <summary>
        /// Método de inicialização do programa
        /// </summary>
        /// <param name="_">Parãmetros iniciais de execução do programa - não utilizado</param>
        public static void Main(String[] _)
        {
            var program = new Program();
            try
            {
                program.Execute();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            finally
            {
                program.Dispose();
            }
        }
    }
}

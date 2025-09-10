namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public Suite Suite { get; set; }
        public List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
        public int DiasReservados { get; set; }

        // Modificação de mdlpontual: O construtor agora exige todos os parâmetros para criar o objeto.
        public Reserva(Suite suite, Pessoa titular, int diasReservados)
        {
            
            Suite = suite;
            Hospedes.Add(titular); // Adiciona o hóspede titular como instancia mínima para criação da reserva (toda suíte aceita ao menos 1 hóspede).
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // Modificação de mdlpontual: Compara a capacidade da suíte com a soma dos hóspedes atuais e dos novos a serem cadastrados.
            bool capacidadeCheck = hospedes.Count + Hospedes.Count <= Suite.Capacidade;

            if (capacidadeCheck)
            {
                Hospedes.AddRange(hospedes);
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new ArgumentException("Número de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        // Modificação mdlpontual: Retorna uma tupla com o valor e o valor do desconto.
        public (decimal valor, decimal valorDoDesconto) CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            decimal valorDoDesconto = valor * 10 / 100;

            // mdlpontual: Usei operadores ternários para prática, embora um if/else pudesse ser mais adequado.
            valor = DiasReservados >= 10 ? valor - valorDoDesconto : valor;
            valorDoDesconto = DiasReservados < 10 ? valorDoDesconto = 0 : valorDoDesconto;

            (decimal valor, decimal valorDoDesconto) tupla = (valor, valorDoDesconto);

            return tupla;

        }
    }
}


// Codigo original modificado:
/* 
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
            bool capacidadeCheck = hospedes.Count <= Suite.Capacidade;

            if (capacidadeCheck)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new ArgumentException("Número de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        // Modificação mdlpontual: alterei o retorno para uma tupla, permitindo retornar duas variáveis — o valor e o valor do desconto.
        public (decimal valor, decimal valorDoDesconto) CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            decimal valorDoDesconto = valor * 10 / 100;

            // mdlpontual: Usei ternários aqui com a intenção de praticar, mesmo que um if/else fosse mais adequado.
            valor = DiasReservados >= 10 ? valor - valorDoDesconto : valor;
            valorDoDesconto = DiasReservados < 10 ? valorDoDesconto = 0 : valorDoDesconto;

            (decimal valor, decimal valorDoDesconto) tupla = (valor, valorDoDesconto);

            return tupla;

        }
    }
} 
*/
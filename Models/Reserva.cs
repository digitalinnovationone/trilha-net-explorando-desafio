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

        public (bool, string) CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            bool sucesso = hospedes.Count <= Suite.Capacidade ? true : false;
            string[] mensagem = {$"Reserva realizada com sucesso!",$"Lamento, a suite seleciona pode acomodar apenas {Suite.Capacidade} pessoas.\nReserva para {hospedes.Count} pessoas não foi realizada!"};
            if (sucesso)
            {
                Hospedes = hospedes;
                return (sucesso, mensagem[0]);
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                return (sucesso, mensagem[1]);
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes(List<Pessoa> hospedes)
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria

            decimal valor = Suite.ValorDiaria * DiasReservados; 

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%

            if (DiasReservados >= 10) 
            {
                valor *= 0.9m; 
            } 

            return valor;
        }
    }
}
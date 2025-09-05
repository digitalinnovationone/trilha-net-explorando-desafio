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
            Hospedes = new List<Pessoa>();
        }
        
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
                throw new Exception("Suite não foi definida para a reserva");
                
            if (hospedes.Count > Suite.Capacidade)
                throw new Exception($"Capacidade excedida. A suíte suporta {Suite.Capacidade} hóspedes");
                
            Hospedes = hospedes;
        }
        
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }
        
        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }
        
        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
                throw new Exception("Suite não foi definida para a reserva");
                
            decimal valor = DiasReservados * Suite.ValorDiaria;
            
            // Aplica desconto de 10% para reservas com mais de 10 dias
            if (DiasReservados > 10)
            {
                valor *= 0.9m; // 10% de desconto
            }
            
            return valor;
        }
    }
}
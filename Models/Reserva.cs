namespace DesafioProjetoHospedagem.Models 
{ 
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        
        public Reserva(){ }
        public Reserva(int diasReservados)
        
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }
        public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
        if (hospedes.Count <= Suite.Capacidade) 
        {
            Hospedes = hospedes;;
        }
        else
        { 
            // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
            
            throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
        }
    }
        //CadastrarSuite(Suite suite)
    
        public void CadastrarSuite(Suite suite) 
        {
            Suite = suite;
        } 
        public int ObterQuantidadeHospedes() 
        
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            Console.WriteLine($"Quantidade de hóspedes: {Hospedes.Count}"); 
            return Hospedes.Count; 
        }
        
        public decimal CalcularValorDiaria() 
        { 
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria

            decimal valor = 0;
            decimal valordiaria = Suite.ValorDiaria;
            decimal total = DiasReservados * Suite.ValorDiaria;
            
            Console.WriteLine($"Valor total: {total}");

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if(DiasReservados >= 10)
            {
                valor = total - (total * 0.10M);
                Console.WriteLine($"Valor com desconto: {valor}");
            }

            return valordiaria;
        }
    }
}
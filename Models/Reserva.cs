using System.Globalization;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
        private Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospede(Pessoa hospede) => Hospedes.Add(hospede);

        public void CadastrarSuite(Suite suite) => Suite = suite;

        public int GetQuantidadeDias() => DiasReservados;
        public int GetQuantidadeHospedes() => Hospedes.Count;


        public Pessoa GetHospede(string nomeOrPosition)
        {
            if(int.TryParse(nomeOrPosition, out int n)) return GetHospedeByIndex(n-1);
            
            return GetHospedeByName(nomeOrPosition);
        }

        public Pessoa GetHospedeByName(string nome)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            nome = ti.ToTitleCase(nome); 
            return Hospedes.FirstOrDefault(p =>
                p.NomeCompleto.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
        
        public Pessoa GetHospedeByIndex(int index)
        {
            if (index < 0 || index >= Hospedes.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Índice inválido de hóspede.");
    
            return Hospedes[index];
        }

        
        public void RemoverHospede(Pessoa hospede) => Hospedes.Remove(hospede);
        
        public decimal ValorTotal() => Suite.ValorDiaria * DiasReservados;

        public static bool AtualizarHospede(Pessoa hospede, string newName)
        {
            if (hospede == null) return false;

            hospede.NomeCompleto = newName;
            return true;
        }
    }
}
namespace DesafioProjetoHospedagem.Models;

{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
        public Pessoa() { }

        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        
        public string NomeCompleto => $"{Nome} {Sobrenome}";
    }
}
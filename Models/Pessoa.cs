namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio.", nameof(nome));
        
        Nome = nome;
    }

    public Pessoa(string nome, string sobrenome) : this(nome)
    {
        Sobrenome = sobrenome;
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; } = string.Empty;

    // Agora não deixa espaço extra e não quebra se não tiver sobrenome
    public string NomeCompleto => string.IsNullOrWhiteSpace(Sobrenome) 
        ? Nome.ToUpper() 
        : $"{Nome} {Sobrenome}".ToUpper();
}
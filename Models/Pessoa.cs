namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa() { }

    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();

    public void RecebePessoa()
    {
        System.Console.Write("Nome : ");
        Nome = Console.ReadLine();
        System.Console.Write("Sobrenome : ");
        Sobrenome = Console.ReadLine();
    }

}
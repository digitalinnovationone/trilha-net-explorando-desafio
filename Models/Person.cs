namespace DesafioProjetoHospedagem.Models;

public class Person
{
    public Person() { }

    public Person(string nome)
    {
        Nome = nome;
    }

    public Person(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
}
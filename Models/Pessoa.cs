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

    public static Pessoa adicionarHospede() {

        Pessoa person = new Pessoa();

        Console.WriteLine("Nome do Hóspede: ");

        person.Nome = Console.ReadLine();
        
        return person;

    }

}
namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

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
    public string NomeCompletoFormatado()
    {
        string nomeCompleto = Nome + ' ' + Sobrenome;
        string[] nomes = nomeCompleto.Split(' ');

        for (int i = 0; i < nomes.Length; i++)
        {
            if (!string.IsNullOrEmpty(nomes[i]))
            {
                nomes[i] = char.ToUpper(nomes[i][0]) + nomes[i][1..].ToLower();

            }
        }
        return string.Join(' ', nomes);
    }

    public static Pessoa CriarPessoa(string nome, string sobrenome)
    {
        return new Pessoa
        {
            Nome = nome,
            Sobrenome = sobrenome
        };
    }
}
using DesafioProjetoHospedagem.Utils;

namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa()
    {
    }

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

    public string NomeCompleto
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Sobrenome))
                return Nome;
            return $"{Nome} {Sobrenome}";
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var partes = NameUtils.Formatar(value);
                Nome = partes[0];
                Sobrenome = partes.Count > 1 ? string.Join(" ", partes.Skip(1)) : string.Empty;
            }
        }
    }

    public static Pessoa Criar(string nomeCompleto)
    {
        if (nomeCompleto.Contains(' '))
        {
            var partes = NameUtils.Formatar(nomeCompleto);
            return new Pessoa(partes[0], partes[1]);
        }
        else
        {
            var nomeUnico = NameUtils.FormatarUnico(nomeCompleto);
            return new Pessoa(nomeUnico);
        }
    }
}
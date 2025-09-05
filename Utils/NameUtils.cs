using System.Globalization;

namespace DesafioProjetoHospedagem.Utils;

public static class NameUtils
{
    public static List<string> Formatar(string nomeCompleto)
    {
        nomeCompleto = nomeCompleto.Trim();

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        nomeCompleto = ti.ToTitleCase(nomeCompleto.ToLower());

        var partes = nomeCompleto.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return partes.ToList();
    }

    public static string FormatarUnico(string nome)
    {
        nome = nome.Trim();

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        return ti.ToTitleCase(nome.ToLower());
    }
}
namespace DesafioProjetoHospedagem.Utils;

public static class ConsoleUtils
{
    public static void EscreverLentamente(string mensagem, int tempoDeEspera = 30)
    {
        Console.WriteLine();
        foreach (char c in mensagem)
        {
            Console.Write(c);
            Thread.Sleep(tempoDeEspera);
        }
        Thread.Sleep(1000);
    }
}
namespace DesafioProjetoHospedagem.Models;

public class Reserva
{
    private const int MinimoDiasParaDesconto = 10;
    private const decimal PorcentagemDesconto = 0.10M;

    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count > Suite.Capacidade)
        {
            throw new InvalidOperationException("A quantidade de hospedes excede a capacidade da suíte.");
        }
        else
        {
            Hospedes = hospedes;
        }
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
        decimal valor = DiasReservados * Suite.ValorDiaria;

        if (AplicarDesconto())
        {
            valor = CalcularValorDesconto(valor);
        }

        return valor;
    }

    private bool AplicarDesconto()
    {
        return DiasReservados >= MinimoDiasParaDesconto;
    }

    private decimal CalcularValorDesconto(decimal valor)
    {
        return valor * (1 - PorcentagemDesconto);
    }
}
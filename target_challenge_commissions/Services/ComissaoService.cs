namespace DesafioTarget.Services;

public static class ComissaoService
{
    public static decimal CalcularComissao(decimal valor)
    {
        if (valor < 100)
        {
            return 0;
        }
        else if (valor < 500)
        {
            return valor * 0.01m;
        }
        else
        {
            return valor * 0.05m;
        }
    }

    public static void AdicionarComissao(
        Dictionary<string, decimal> comissoes,
        string vendedor,
        decimal comissao
    )
    {
        if (comissoes.ContainsKey(vendedor))
        {
            comissoes[vendedor] = comissoes[vendedor] + comissao;
        }
        else
        {
            comissoes[vendedor] = comissao;
        }
    }

    public static void ExibirComissoes(Dictionary<string, decimal> comissoes)
    {
        foreach (var item in comissoes)
        {
            Console.WriteLine(
                $"{item.Key} - Comissão total: R$ {item.Value:F2}"
            );
        }
    }
}

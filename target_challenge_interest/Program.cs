decimal? valor = LerValor();

if (valor == null)
{
    return;
}

DateTime? dataVencimento = LerDataVencimento();

if (dataVencimento == null)
{
    return;
}

decimal juros = CalcularJuros(
    valor.Value,
    dataVencimento.Value
);

decimal valorAtualizado = valor.Value + juros;

Console.WriteLine();
Console.WriteLine($"Valor original: R$ {valor.Value:F2}");
Console.WriteLine($"Juros: R$ {juros:F2}");
Console.WriteLine($"Valor atualizado: R$ {valorAtualizado:F2}");

static decimal? LerValor()
{
    Console.Write("Digite o valor: R$ ");
    string? entrada = Console.ReadLine();

    if (!decimal.TryParse(entrada, out decimal valor) || valor <= 0)
    {
        Console.WriteLine("Valor inválido.");
        return null;
    }

    return valor;
}

static DateTime? LerDataVencimento()
{
    Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
    string? entrada = Console.ReadLine();

    if (!DateTime.TryParse(entrada, out DateTime dataVencimento))
    {
        Console.WriteLine("Data inválida.");
        return null;
    }

    return dataVencimento;
}

static decimal CalcularJuros(decimal valor, DateTime dataVencimento)
{
    DateTime hoje = DateTime.Today;

    if (dataVencimento >= hoje)
    {
        return 0;
    }

    int diasAtraso = (hoje - dataVencimento).Days;

    decimal jurosPorDia = valor * 0.025m;

    decimal jurosTotal = jurosPorDia * diasAtraso;

    return jurosTotal;
}

using System.Text.Json;
using DesafioTarget_Questao2.Models;
using DesafioTarget_Questao2.Services;

string json = File.ReadAllText("Data/estoque.json");

var dadosEstoque = JsonSerializer.Deserialize<DadosEstoque>(
    json,
    new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    }
);

if (dadosEstoque == null)
{
    Console.WriteLine("Erro ao carregar os dados de estoque.");
    return;
}

int? codigoInformado = LerCodigoProduto();

if (codigoInformado == null)
{
    return;
}

Produto? produtoEncontrado = BuscarProdutoPorCodigo(
    dadosEstoque.Estoque,
    codigoInformado.Value
);

if (produtoEncontrado == null)
{
    Console.WriteLine("Erro: Produto inexistente.");
    return;
}

TipoMovimentacao? tipoMovimentacao = LerTipoMovimentacao();

if (tipoMovimentacao == null)
{
    return;
}

int? quantidade = LerQuantidade();

if (quantidade == null)
{
    return;
}

var movimentacao = new Movimentacao
{
    CodigoProduto = produtoEncontrado.CodigoProduto,
    Tipo = tipoMovimentacao.Value,
    Quantidade = quantidade.Value
};

var resultado = EstoqueService.ProcessarMovimentacao(
    produtoEncontrado,
    movimentacao
);

ExibirResultado(resultado, movimentacao, produtoEncontrado);

static int? LerCodigoProduto()
{
    Console.Write("Digite o código do produto: ");
    string? entrada = Console.ReadLine();

    if (!int.TryParse(entrada, out int codigo))
    {
        Console.WriteLine("Código inválido.");
        return null;
    }

    return codigo;
}

static Produto? BuscarProdutoPorCodigo(List<Produto> produtos, int codigo)
{
    foreach (var produto in produtos)
    {
        if (produto.CodigoProduto == codigo)
        {
            return produto;
        }
    }

    return null;
}

static TipoMovimentacao? LerTipoMovimentacao()
{
    Console.Write("Tipo da movimentação (Entrada/Saida): ");
    string? entrada = Console.ReadLine();

    if (!Enum.TryParse<TipoMovimentacao>(
            entrada,
            true,
            out TipoMovimentacao tipo
        ))
    {
        Console.WriteLine("Tipo de movimentação inválido.");
        return null;
    }

    return tipo;
}

static int? LerQuantidade()
{
    Console.Write("Quantidade: ");
    string? entrada = Console.ReadLine();

    if (!int.TryParse(entrada, out int quantidade))
    {
        Console.WriteLine("Quantidade inválida.");
        return null;
    }

    return quantidade;
}

static void ExibirResultado(
    (bool Sucesso, int EstoqueFinal, string Mensagem) resultado,
    Movimentacao movimentacao,
    Produto produto
)
{
    Console.WriteLine();
    Console.WriteLine(resultado.Mensagem);
    Console.WriteLine($"Produto: {produto.DescricaoProduto}");
    Console.WriteLine($"Código: {produto.CodigoProduto}");
    Console.WriteLine($"Tipo: {movimentacao.Tipo}");
    Console.WriteLine($"Quantidade movimentada: {movimentacao.Quantidade}");
    Console.WriteLine($"Estoque final: {resultado.EstoqueFinal}");
    Console.WriteLine($"ID da movimentação: {movimentacao.Id}");
}

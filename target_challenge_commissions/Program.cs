using System.Text.Json;
using DesafioTarget.Models;
using DesafioTarget.Services;

string json = File.ReadAllText("Data/vendas.json");

var dados = JsonSerializer.Deserialize<DadosVendas>(
    json,
    new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    }
);

if (dados == null)
{
    Console.WriteLine("Erro: Dado inexistente.");
    return;
} else if(dados.Vendas == null)
{
     Console.WriteLine("Erro: Lista de vendas inexistente.");
    return;
}

Dictionary<string, decimal> comissoes = new Dictionary<string, decimal>();

foreach (var venda in dados.Vendas)
{
    decimal comissao = ComissaoService.CalcularComissao(venda.Valor);

    ComissaoService.AdicionarComissao(
        comissoes,
        venda.Vendedor,
        comissao
    );
}

ComissaoService.ExibirComissoes(comissoes);

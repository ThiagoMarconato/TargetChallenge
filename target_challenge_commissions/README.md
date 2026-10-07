# Desafio Target - Questão 1

Implementação em C# da questão de cálculo de comissão por vendedor.

## Executar

Requer o SDK do .NET 8. Na raiz do projeto, onde está `DesafioTarget.csproj`, execute:

```bash
dotnet run
```

O programa lê `Data/vendas.json` a partir dessa pasta.

## Estrutura

- `Program.cs`: fluxo principal
- `Services/ComissaoService.cs`: cálculo, acumulação e exibição das comissões
- `Models/Venda.cs`: representa uma venda
- `Models/DadosVendas.cs`: representa o JSON com a lista de vendas
- `Data/vendas.json`: dados fornecidos no desafio
- `Data/vendas-teste.json`: exemplo de entrada inválida (`vendas` nula) para teste manual; não é usado na execução normal

# Desafio Target - Questão 2

Implementação em C# para movimentação de estoque com entrada e saída de produtos.

## O que foi implementado

- Leitura do estoque a partir de JSON
- Busca de produto por código
- Movimentações de entrada e saída
- Identificador único com `Guid`
- Validação de quantidade
- Bloqueio de saída acima do estoque disponível
- Retorno com sucesso, estoque final e mensagem
- Métodos separados para leitura, busca e exibição

## Executar

```bash
dotnet run
```

## Estrutura

```text
DesafioTarget_Questao2/
├── Data/
│   └── estoque.json
├── Models/
│   ├── Produto.cs
│   ├── DadosEstoque.cs
│   ├── Movimentacao.cs
│   └── TipoMovimentacao.cs
├── Services/
│   └── EstoqueService.cs
├── Program.cs
├── DesafioTarget_Questao2.csproj
└── README.md
```

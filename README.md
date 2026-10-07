# TargetChallenge

Repositório com as soluções desenvolvidas em C#.

O desafio foi dividido em três projetos independentes, cada um responsável por uma questão específica.

## Tecnologias utilizadas

- C#
- .NET 8
- System.Text.Json
- Git

## Estrutura do repositório

```text
TargetChallenge/
├── target_challenge_commissions/
├── target_challenge_stock/
├── target_challenge_interest/
├── .gitignore
└── README.md
```

## 1. target_challenge_commissions

Projeto responsável pelo cálculo de comissões de vendedores a partir de um arquivo JSON contendo registros de vendas.

### Regras

- Vendas abaixo de R$ 100,00 não geram comissão
- Vendas de R$ 100,00 até abaixo de R$ 500,00 geram 1% de comissão
- Vendas a partir de R$ 500,00 geram 5% de comissão

A comissão é calculada individualmente para cada venda e acumulada por vendedor.

### Conceitos utilizados

- Leitura e desserialização de JSON
- Classes e objetos
- `Dictionary<string, decimal>`
- Métodos auxiliares
- Estruturas condicionais
- `foreach`
- Uso de `decimal` para valores monetários

---

## 2. target_challenge_stock

Projeto responsável por movimentações de entrada e saída de produtos em estoque.

### Funcionalidades

- Busca de produto pelo código
- Entrada de mercadoria
- Saída de mercadoria
- Validação de quantidade
- Bloqueio de estoque negativo
- Identificador único por movimentação utilizando `Guid`
- Retorno da quantidade final em estoque

### Validações

O programa impede:

- movimentações com quantidade igual ou inferior a zero
- saída superior ao estoque disponível
- movimentação de produto inexistente
- tipos de movimentação inválidos

### Conceitos utilizados

- Classes e objetos
- `enum`
- `Guid`
- Tuplas
- Nullable types
- `TryParse`
- Leitura de JSON
- Separação da regra de negócio em service

---

## 3. target_challenge_interest

Projeto responsável pelo cálculo de juros com base em um valor e em uma data de vencimento.

### Regras

- Considera taxa de 2,5% ao dia de atraso
- Se a data de vencimento for hoje ou futura, não há juros
- O cálculo considera os dias de atraso entre o vencimento e a data atual

O programa apresenta:

- valor original
- valor dos juros
- valor atualizado

### Conceitos utilizados

- `DateTime`
- `TimeSpan`
- `decimal`
- `TryParse`
- Métodos auxiliares
- Validação de entrada

---

## Como executar

É necessário ter o SDK do .NET instalado.

Para executar uma questão, acesse a pasta correspondente.

### Comissões

```bash
cd target_challenge_commissions
dotnet run
```

### Estoque

```bash
cd target_challenge_stock
dotnet run
```

### Juros

```bash
cd target_challenge_interest
dotnet run
```

## Autor

Thiago Pereira Marconato

using DesafioTarget_Questao2.Models;

namespace DesafioTarget_Questao2.Services;

public static class EstoqueService
{
    public static (bool Sucesso, int EstoqueFinal, string Mensagem)
        ProcessarMovimentacao(Produto produto, Movimentacao movimentacao)
    {
        if (movimentacao.Quantidade <= 0)
        {
            return (
                false,
                produto.Estoque,
                "Quantidade inválida."
            );
        }

        if (
            movimentacao.Tipo == TipoMovimentacao.Saida &&
            movimentacao.Quantidade > produto.Estoque
        )
        {
            return (
                false,
                produto.Estoque,
                $"Estoque insuficiente. Disponível: {produto.Estoque}"
            );
        }

        if (movimentacao.Tipo == TipoMovimentacao.Entrada)
        {
            produto.Estoque += movimentacao.Quantidade;

            return (
                true,
                produto.Estoque,
                $"Entrada realizada. Estoque atual: {produto.Estoque}"
            );
        }

        if (movimentacao.Tipo == TipoMovimentacao.Saida)
        {
            produto.Estoque -= movimentacao.Quantidade;

            return (
                true,
                produto.Estoque,
                $"Saída realizada. Estoque atual: {produto.Estoque}"
            );
        }

        return (
            false,
            produto.Estoque,
            "Tipo de movimentação inválida."
        );
    }
}

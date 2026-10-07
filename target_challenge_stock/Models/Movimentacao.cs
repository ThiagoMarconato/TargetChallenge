namespace DesafioTarget_Questao2.Models;

public class Movimentacao
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int CodigoProduto { get; set; }
    public TipoMovimentacao Tipo { get; set; }
    public int Quantidade { get; set; }
}

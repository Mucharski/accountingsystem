using System.ComponentModel.DataAnnotations.Schema;

namespace SistemasCorporativos.Models;

[Table("movimentacoes")]
public class Movimentacao
{
    [Column("id")] public int MovimentacaoId { get; set; }

    [Column("data_movimento")] public DateTime DataMovimento { get; set; }

    [Column("valor_movimentacao", TypeName = "decimal(10,2)")] public decimal ValorMovimentacao { get; set; }

    [Column("fk_conta_id")] public int ContaId { get; set; }
    public Conta? Conta { get; set; }

    [Column("fk_tipo_movimentacao_id")] public int TipoMovimentacaoId { get; set; }
    public TipoMovimentacao? TipoMovimentacao { get; set; }
}
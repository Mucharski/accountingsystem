using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemasCorporativos.Models;

[Table("tipo_movimentacao")]
public class TipoMovimentacao
{
    [Column("id")] public int TipoMovimentacaoId { get; set; }
    [Column("nome")] public string Nome { get; set; }
    
    [JsonIgnore]
    public List<Movimentacao>? Movimentacoes { get; set; }
}
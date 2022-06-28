using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemasCorporativos.Models;

[Table("contratos")]
public class Contrato
{
    [Column("id")] public int ContratoId { get; set; }

    [Column("nome")] public string Nome { get; set; }

    [Column("descricao")] public string? Descricao { get; set; }

    [Column("quantidade_parcelas")] public int QuantidadeParcelas { get; set; }

    [Column("data_inicio")] public DateTime DataInicio { get; set; }

    [Column("multa_diaria")] public decimal? MultaDiaria { get; set; }
    
    [Column("valor_total", TypeName = "decimal(10,2)")] public decimal ValorTotal { get; set; }

    // RELAÇÃO
    [Column("fk_situacao_id")] public int SituacaoId { get; set; }
    public Situacao? Situacao { get; set; }

    [Column("fk_tipo_id")] public int TipoContaId { get; set; }
    public TipoConta? TipoConta { get; set; }
    
    [JsonIgnore]
    public List<Conta>? Contas { get; set; }
}
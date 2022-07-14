using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemasCorporativos.Models;

[Table("situacoes")]
public class Situacao
{
    [Column("id")] public int SituacaoId { get; set; }

    [Column("nome")] public string Nome { get; set; }

    [Column("cod_situacao")] public string CodSituacao { get; set; }

    [JsonIgnore]
    public List<Contrato>? Contratos { get; set; }
    
    [JsonIgnore]
    public List<Conta>? Contas { get; set; }
}
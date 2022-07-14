using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemasCorporativos.Models;

[Table("tipo_conta")]
public class TipoConta
{
    [Column("id")] public int TipoContaId { get; set; }

    [Column("nome")] public string Nome { get; set; }

    [JsonIgnore]
    public List<Contrato>? Contratos { get; set; }
}
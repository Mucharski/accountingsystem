using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemasCorporativos.Models;

[Table("contas")]
public class Conta
{
    [Column("id")] public int ContaId { get; set; }

    [Column("valor", TypeName = "decimal(10,2)")] public decimal Valor { get; set; }

    [Column("parcela_referencia")] public int ParcelaReferencia { get; set; }

    [Column("codigo_barras")] public string CodigoBarras { get; set; }

    [Column("data_pagamento")] public DateTime? DataPagamento { get; set; }

    [Column("data_vencimento")] public DateTime DataVencimento { get; set; }

    [Column("multa_devida")] public decimal? MultaDevida { get; set; }

    [Column("fk_contrato_id")] public int ContratoId { get; set; }
    [JsonIgnore]
    public Contrato Contrato { get; set; }
    
    [Column("fk_situacao_id")] public int SituacaoId { get; set; }
    [JsonIgnore]
    public Situacao Situacao { get; set; }
    
    [JsonIgnore]
    public List<Movimentacao>? Movimentacoes { get; set; }

}
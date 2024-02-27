using System.ComponentModel.DataAnnotations.Schema;

namespace crm.webapi.Models;

public class Contrato
{
    public required int Id { get; set; }

    [ForeignKey("Pessoa")]
    public int? PessoaId { get; set; }

    public virtual Pessoa? Pessoa { get; set; }

    [ForeignKey("Banco")]
    public int? BancoId { get; set; }

    public virtual Banco? Banco { get; set; }

    public string? Num_Contrato { get; set; }

    public decimal? Valor_Bem { get; set; }

    public decimal? Valor_Entrada { get; set; }

    public decimal? Valor_Financiar { get; set; }

    public int? Parcelas { get; set; }

    public decimal? Valor_Parcela { get; set; }

    public decimal? Juros_Mensal { get; set; }

    public decimal? Juros_Anual { get; set; }

    public decimal? Cet_Mensal { get; set; }

    public decimal? Cet_Anual { get; set; }

    public decimal? Iof { get; set; }

    public decimal? Saldo_Financiar { get; set; }

    public decimal? Total_Clausulas_Abusivas_Iof { get; set; }

    public decimal? Total_Acao { get; set; }

    public decimal? Taxa_Media_Juros { get; set; }

    public decimal? Total_Financiamento { get; set; }

    public decimal? Valor_Tutela { get; set; }

    public DateTime? Dt_Ins { get; set; }

    public DateTime? Dt_Upd { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace crm.webapi.Models;

public class Clausula_Abusiva
{
    public required int Id { get; set; }

    [ForeignKey("Clausula")]
    public int? ClausulaId { get; set; }

    public virtual Clausula? Clausula { get; set; }

    [ForeignKey("Contrato")]
    public int? ContratoId { get; set; }

    public virtual Contrato? Contrato { get; set; }

    public Decimal? Valor_Clausula { get; set; }
}

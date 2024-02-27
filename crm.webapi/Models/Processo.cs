namespace crm.webapi.Models;

public class Processo
{
    public required int Id { get; set; }

    public required string Comarca { get; set; }

    public required string Forum { get; set; }

    public required string Status_Financiamento { get; set; }

    public bool Justica_Gratuita { get; set; }

    public int Id_Contrato { get; set; }

    public string? Numero_Processo { get; set; }
}

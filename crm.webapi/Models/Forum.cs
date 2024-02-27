namespace crm.webapi.Models;

public class Forum
{
    public required int Id { get; set; }

    public required string Foro { get; set; }

    public string? Cidade { get; set; }

    public required string Uf { get; set; }
}
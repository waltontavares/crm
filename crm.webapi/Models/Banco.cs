namespace crm.webapi.Models;

public class Banco
{
    public required int Id { get; set; }

    public string? Fantasia { get; set; }

    public string? Razao { get; set; }

    public string? Cnpj { get; set; }

    public string? Endereco { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Uf { get; set; }

    public string? Cep { get; set; }

    public string? email { get; set; }

    public string? telefone { get; set; }
}
namespace crm.webapi.Models;

public class Endereco
{
    //public required int Id { get; set; }

    public required string Cep { get; set; }

    public required string Logradouro { get; set; }

    public required string Bairro { get; set; }

    public required string Cidade { get; set; }

    public required string Uf { get; set; }
}

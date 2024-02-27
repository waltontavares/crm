using System.ComponentModel.DataAnnotations.Schema;

namespace crm.webapi.Models;

public class Pessoa
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Rg { get; set; }

    public string? Exp { get; set; }

    public string? Cpf { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public string? Cep { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Uf { get; set; }

    public string? Nacionalidade { get; set; }

    public string? Profissao { get; set; }

    [ForeignKey("Estado_Civil")]
    public int? Estado_CivilId { get; set; }

    public virtual Estado_Civil? Estado_Civil { get; set; }
}
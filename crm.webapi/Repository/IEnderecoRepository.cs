using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IEnderecoRepository
{
    Task<Endereco> BuscaEndereco(string cep);
}

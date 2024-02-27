using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IPessoaRepository
{
    Task<IEnumerable<Pessoa>> BuscaPessoas();

    Task<Pessoa> BuscaPessoa(string cpf);

    Task<Pessoa> BuscaPessoa(int id);

    void InserePessoa(Pessoa pessoa);

    void AlteraPessoa(Pessoa pessoa);

    Task<bool> SaveChangesAsyc();
}

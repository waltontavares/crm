using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IProcessoRepository
{
    Task<Processo> BuscaProcesso(int contrato);

    Task<Processo> BuscaProcessoById(int id);

    void InsereProcesso(Processo processo);

    void AlteraProcesso(Processo processo);

    Task<bool> SaveChangesAsyc();
}

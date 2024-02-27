using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IContratoRepository
{
    Task<Contrato> BuscaContato(string contrato, int pessoa, int banco);

    Task<Contrato> BuscaContrato(int id);

    void InsereContrato(Contrato contrato);

    void AlteraContrato(Contrato contrato);

    Task<bool> SaveChangesAsyc();
}

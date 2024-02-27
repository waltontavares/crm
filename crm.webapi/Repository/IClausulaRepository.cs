using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IClausulaRepository
{
    Task<IEnumerable<Clausula>> BuscaClausulas();
    Task<Clausula> BuscaClausula(int id);
}

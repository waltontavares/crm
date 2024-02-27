using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IBancoRepository
{
    Task<IEnumerable<Banco>> BuscaBancos();
    Task<Banco> BuscaBanco(int id);
}

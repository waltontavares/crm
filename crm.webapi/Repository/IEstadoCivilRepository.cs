using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IEstadoCivilRepository
{
    Task<IEnumerable<Estado_Civil>> BuscaEstadosCivis();
    Task<Estado_Civil> BuscaEstadoCivil(int id);
}

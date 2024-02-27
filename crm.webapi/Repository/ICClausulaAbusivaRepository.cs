using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IClausulaAbusivaRepository
{
    Task<Clausula_Abusiva> BuscaClAbusiva(int contrato);

    Task<Clausula_Abusiva> BuscaClAbusivaById(int id);

    void InsereClAbusiva(Clausula_Abusiva clabusiva);

    void AlteraClAbusiva(Clausula_Abusiva clabusiva);

    Task<bool> SaveChangesAsyc();
}

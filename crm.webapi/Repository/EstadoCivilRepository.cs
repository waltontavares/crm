using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class EstadoCivilRepository : IEstadoCivilRepository
{
    private readonly CrmContext _context;

    public EstadoCivilRepository(CrmContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Estado_Civil>> BuscaEstadosCivis()
    {
        return await _context.EstadosCivis.ToListAsync();
    }
    public async Task<Estado_Civil> BuscaEstadoCivil(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.EstadosCivis.Where(x => x.Id == id).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }
}

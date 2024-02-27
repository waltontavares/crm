using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class ClausulaRepository : IClausulaRepository
{
    private readonly CrmContext _context;

    public ClausulaRepository(CrmContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Clausula>> BuscaClausulas()
    {
        return await _context.Clausulas.ToListAsync();
    }
    public async Task<Clausula> BuscaClausula(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Clausulas.Where(x => x.Id == id).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }
}

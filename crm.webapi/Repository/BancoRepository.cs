using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class BancoRepository : IBancoRepository
{
    private readonly CrmContext _context;

    public BancoRepository(CrmContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Banco>> BuscaBancos()
    {
        return await _context.Bancos.ToListAsync();
    }
    public async Task<Banco> BuscaBanco(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Bancos.Where(x => x.Id == id).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }
}

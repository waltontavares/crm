using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class ClausulaAbusivaRepository : IClausulaAbusivaRepository
{
    private readonly CrmContext _context;

    public ClausulaAbusivaRepository(CrmContext context)
    {
        _context = context;
    }

    public async Task<Clausula_Abusiva> BuscaClAbusiva(int contrato)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.ClAbusivas.Where(x => x.ContratoId == contrato)
        .Include(x => x.Contrato)
        .Include(x => x.Clausula)
        .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<Clausula_Abusiva> BuscaClAbusivaById(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.ClAbusivas.Where(x => x.Id == id)
        .Include(x => x.Contrato)
        .Include(x => x.Clausula)
        .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void InsereClAbusiva(Clausula_Abusiva clabusiva)
    {
        _context.Add(clabusiva);
    }

    public async Task<bool> SaveChangesAsyc()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    void IClausulaAbusivaRepository.AlteraClAbusiva(Clausula_Abusiva clabusiva)
    {
        _context.Update(clabusiva);
    }
}
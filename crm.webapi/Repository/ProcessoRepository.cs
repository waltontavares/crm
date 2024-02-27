using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class ProcessoRepository : IProcessoRepository
{
    private readonly CrmContext _context;

    public ProcessoRepository(CrmContext context)
    {
        _context = context;
    }

    public async Task<Processo> BuscaProcesso(int contrato)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Processos.Where(x => x.Id_Contrato == contrato).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<Processo> BuscaProcessoById(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Processos.Where(x => x.Id == id).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void InsereProcesso(Processo processo)
    {
        _context.Add(processo);
    }

    public void AlteraProcesso(Processo processo)
    {
        _context.Update(processo);
    }

    public async Task<bool> SaveChangesAsyc()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}

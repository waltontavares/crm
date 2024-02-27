using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class ContratoRepository : IContratoRepository
{
    private readonly CrmContext _context;

    public ContratoRepository(CrmContext context)
    {
        _context = context;
    }

    public async Task<Contrato> BuscaContato(string contrato, int pessoa, int banco)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Contratos.Where(x => x.Num_Contrato == contrato
                                                && x.PessoaId == pessoa
                                                && x.BancoId == banco)
                                                .Include(x => x.Pessoa)
                                                .Include(x => x.Banco)
                                                .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<Contrato> BuscaContrato(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Contratos.Where(x => x.Id == id)
        .Include(x => x.Pessoa)
        .Include(x => x.Banco)
        .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void InsereContrato(Contrato contrato)
    {
        _context.Add(contrato);
    }

    public void AlteraContrato(Contrato contrato)
    {
        _context.Update(contrato);
    }

    public async Task<bool> SaveChangesAsyc()
    {
        return await _context.SaveChangesAsync() > 0;
    }

}

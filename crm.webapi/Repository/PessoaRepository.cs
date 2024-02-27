using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly CrmContext _context;

    public PessoaRepository(CrmContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pessoa>> BuscaPessoas()
    {
        return await _context.Pessoas
        .Include(x => x.Estado_Civil)
        .ToListAsync();
    }

    public async Task<Pessoa> BuscaPessoa(string cpf)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Pessoas.Where(x => x.Cpf == cpf)
        .Include(x => x.Estado_Civil)
        .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task<Pessoa> BuscaPessoa(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Pessoas.Where(x => x.Id == id)
        .Include(x => x.Estado_Civil)
        .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void InserePessoa(Pessoa pessoa)
    {
        _context.Add(pessoa);
    }

    public void AlteraPessoa(Pessoa pessoa)
    {
        _context.Update(pessoa);
    }

    public async Task<bool> SaveChangesAsyc()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}

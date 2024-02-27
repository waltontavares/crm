using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly CrmContext _context;

    public EnderecoRepository(CrmContext context)
    {
        _context = context;
    }

    public async Task<Endereco> BuscaEndereco(string cep)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Enderecos.Where(x => x.Cep == cep).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }
}

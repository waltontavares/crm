using crm.webapi.Data;
using crm.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crm.webapi.Repository;

public class ForumRepository : IForumRepository
{
    private readonly CrmContext _context;

    public ForumRepository(CrmContext context)
    {
        _context = context;

    }

    public async Task<IEnumerable<Forum>> BuscaForuns()
    {
        return await _context.Foruns.ToListAsync();
    }
    public async Task<Forum> BuscaForum(int id)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Foruns.Where(x => x.Id == id).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
    }
}

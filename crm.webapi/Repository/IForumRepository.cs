using crm.webapi.Models;

namespace crm.webapi.Repository;

public interface IForumRepository
{
    Task<IEnumerable<Forum>> BuscaForuns();
    Task<Forum> BuscaForum(int id);
}

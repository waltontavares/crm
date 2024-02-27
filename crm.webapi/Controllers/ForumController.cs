using crm.webapi.Models;
using crm.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crm.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ForumController : ControllerBase
{
    private readonly IForumRepository _repository;

    public ForumController(IForumRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var forum = await _repository.BuscaForuns();
        return forum.Any()
                ? Ok(forum)
                : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscaForum(int id)
    {
        var forum = await _repository.BuscaForum(id);
        return forum != null
                ? Ok(forum)
                : NotFound();
    }
}

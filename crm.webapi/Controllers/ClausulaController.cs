using crm.webapi.Models;
using crm.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crm.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClausulaController : ControllerBase
{
    private readonly IClausulaRepository _repository;

    public ClausulaController(IClausulaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clausula = await _repository.BuscaClausulas();
        return clausula.Any()
                ? Ok(clausula)
                : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscaClausula(int id)
    {
        var clausula = await _repository.BuscaClausula(id);
        return clausula != null
                ? Ok(clausula)
                : NotFound();
    }
}

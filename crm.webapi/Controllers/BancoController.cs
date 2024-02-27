using crm.webapi.Models;
using crm.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crm.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BancoController : ControllerBase
{
    private readonly IBancoRepository _repository;

    public BancoController(IBancoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var banco = await _repository.BuscaBancos();
        return banco.Any()
                ? Ok(banco)
                : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscaBanco(int id)
    {
        var banco = await _repository.BuscaBanco(id);
        return banco != null
                ? Ok(banco)
                : NotFound();
    }
}

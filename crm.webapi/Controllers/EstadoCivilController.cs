using crm.webapi.Models;
using crm.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crm.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstadoCivilController : ControllerBase
{
    private readonly IEstadoCivilRepository _repository;

    public EstadoCivilController(IEstadoCivilRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clausula = await _repository.BuscaEstadosCivis();
        return clausula.Any()
                ? Ok(clausula)
                : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscaEstadoCivil(int id)
    {
        var clausula = await _repository.BuscaEstadoCivil(id);
        return clausula != null
                ? Ok(clausula)
                : NotFound();
    }
}

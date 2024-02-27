using crm.webapi.Models;
using crm.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crm.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClausulaAbusivaController : ControllerBase
{
    private readonly IClausulaAbusivaRepository _repository;

    public ClausulaAbusivaController(IClausulaAbusivaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{contrato}")]
    public async Task<IActionResult> BuscaClAbusiva(int contrato)
    {
        var clAbusiva = await _repository.BuscaClAbusiva(contrato);
        return clAbusiva != null
                ? Ok(clAbusiva)
                : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscaClAbusivaById(int id)
    {
        var contrato = await _repository.BuscaClAbusivaById(id);
        return contrato != null
                ? Ok(contrato)
                : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Clausula_Abusiva clAbusiva)
    {
        _repository.InsereClAbusiva(clAbusiva);
        return await _repository.SaveChangesAsyc()
                ? Ok("Clausula inserida com sucesso!!!")
                : BadRequest("Erro ao inserir clausula!");
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int id, Clausula_Abusiva clAbusiva)
    {
        var clAbusivaBanco = await _repository.BuscaClAbusivaById(id);
        if (clAbusivaBanco == null) return NotFound();

        clAbusivaBanco.ClausulaId = clAbusiva.ClausulaId;
        clAbusivaBanco.Valor_Clausula = clAbusiva.Valor_Clausula;

        _repository.AlteraClAbusiva(clAbusivaBanco);
        return await _repository.SaveChangesAsyc()
                ? Ok("Clausula alterada com sucesso!!!")
                : BadRequest("Erro ao alterada Clausula!");
    }
}

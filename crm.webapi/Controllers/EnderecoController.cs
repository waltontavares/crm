using crm.webapi.Models;
using crm.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crm.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoRepository _repository;

    public EnderecoController(IEnderecoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{cep}")]
    public async Task<IActionResult> BuscaEndereco(string cep)
    {
        var endereco = await _repository.BuscaEndereco(cep);
        return endereco != null
                ? Ok(endereco)
                : NotFound();
    }
}

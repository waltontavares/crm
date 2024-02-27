using crm.webapi.Models;
using crm.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crm.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _repository;

    public PessoaController(IPessoaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pessoa = await _repository.BuscaPessoas();
        return pessoa.Any()
                ? Ok(pessoa)
                : NotFound();
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> BuscaPessoa(string cpf)
    {
        var pessoa = await _repository.BuscaPessoa(cpf);
        return pessoa != null
                ? Ok(pessoa)
                : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Pessoa pessoa)
    {
        _repository.InserePessoa(pessoa);
        return await _repository.SaveChangesAsyc()
                ? Ok("Pessoa inserida com sucesso!!!")
                : BadRequest("Erro ao inserir pessoa!");
    }

    [HttpPut]
    public async Task<IActionResult> Put(Pessoa pessoa)
    {
        var pessoaBanco = await _repository.BuscaPessoa(pessoa.Id);
        if (pessoaBanco == null) return NotFound();

        pessoaBanco.Nome = pessoa.Nome;
        pessoaBanco.Rg = pessoa.Rg;
        pessoaBanco.Exp = pessoa.Exp;
        pessoaBanco.Email = pessoa.Email;
        pessoaBanco.Telefone = pessoa.Telefone;
        pessoaBanco.Cep = pessoa.Cep;
        pessoaBanco.Logradouro = pessoa.Logradouro;
        pessoaBanco.Numero = pessoa.Numero;
        pessoaBanco.Complemento = pessoa.Complemento;
        pessoaBanco.Bairro = pessoa.Bairro;
        pessoaBanco.Cidade = pessoa.Cidade;
        pessoaBanco.Uf = pessoa.Uf;
        pessoaBanco.Nacionalidade = pessoa.Nacionalidade;
        pessoaBanco.Profissao = pessoa.Profissao;
        pessoaBanco.Estado_CivilId = pessoa.Estado_CivilId;

        _repository.AlteraPessoa(pessoaBanco);
        return await _repository.SaveChangesAsyc()
                ? Ok("Pessoa alterada com sucesso!!!")
                : BadRequest("Erro ao alterada pessoa!");
    }
}

using crm.webapi.Models;
using crm.webapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace crm.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContratoController : ControllerBase
{
    private readonly IContratoRepository _repository;

    public ContratoController(IContratoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var contrato = await _repository.BuscaContratos();
        return contrato.Any()
                ? Ok(contrato)
                : NotFound();
    }

    [HttpGet("{contrato, pessoa, banco}")]
    public async Task<IActionResult> BuscaContrato(string num, int pessoa, int banco)
    {
        var contrato = await _repository.BuscaContato(num, pessoa, banco);
        return contrato != null
                ? Ok(contrato)
                : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Contrato contrato)
    {
        _repository.InsereContrato(contrato);
        return await _repository.SaveChangesAsyc()
                ? Ok("Contrato inserida com sucesso!!!")
                : BadRequest("Erro ao inserir contrato!");
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int id, Contrato contrato)
    {
        var contratoBanco = await _repository.BuscaContrato(id);
        if (contratoBanco == null) return NotFound();

        contratoBanco.BancoId = contrato.BancoId;
        contratoBanco.Valor_Bem = contrato.Valor_Bem;
        contratoBanco.Valor_Entrada = contrato.Valor_Entrada;
        contratoBanco.Valor_Financiar = contrato.Valor_Financiar;
        contratoBanco.Parcelas = contrato.Parcelas;
        contratoBanco.Valor_Parcela = contrato.Valor_Parcela;
        contratoBanco.Juros_Mensal = contrato.Juros_Mensal;
        contratoBanco.Juros_Anual = contrato.Juros_Anual;
        contratoBanco.Cet_Mensal = contrato.Cet_Mensal;
        contratoBanco.Cet_Anual = contrato.Cet_Anual;
        contratoBanco.Iof = contrato.Iof;
        contratoBanco.Saldo_Financiar = contrato.Saldo_Financiar;
        contratoBanco.Total_Clausulas_Abusivas_Iof = contrato.Total_Clausulas_Abusivas_Iof;
        contratoBanco.Total_Acao = contrato.Total_Acao;
        contratoBanco.Taxa_Media_Juros = contrato.Taxa_Media_Juros;
        contratoBanco.Total_Financiamento = contrato.Total_Financiamento;
        contratoBanco.Valor_Tutela = contrato.Valor_Tutela;

        _repository.AlteraContrato(contratoBanco);
        return await _repository.SaveChangesAsyc()
                ? Ok("Contrato alterada com sucesso!!!")
                : BadRequest("Erro ao alterada contrato!");
    }
}
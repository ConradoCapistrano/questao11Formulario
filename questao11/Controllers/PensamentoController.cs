using Microsoft.AspNetCore.Mvc;
using questao11.Application.Interface;
using questao11.DTOs;

namespace questao11.Controllers;

[Route("api/pensamentos")]
[ApiController]
public class PensamentoController: ControllerBase
{
    private readonly IPensamentoService _service;

    public PensamentoController(IPensamentoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodos()
    {
        var response = await _service.ListarTodos();
        if (!response.Sucess)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var response = await _service.ObterPorId(id);

        return Ok(new {
            sucess = true,
            message = "",
            data = response
        });
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] CreatePensamentoDTO pensamentoDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _service.Inserir(pensamentoDTO);
        if (!response.Sucess)
            return BadRequest(response);

        return CreatedAtAction(nameof(ObterPorId), new { id = response.Data }, response);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] UpdatePensamentoDTO pensamentoDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _service.Atualizar(pensamentoDTO);
        if (!response.Sucess)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        var response = await _service.Excluir(id);
        if (!response.Sucess)
            return BadRequest(response);

        return Ok(response);
    }
}

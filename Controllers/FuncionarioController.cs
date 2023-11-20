using DomainServices.Exceptions;
using DomainServices.Services.Interfaces;
using Infraestructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using TrilhaNetAzureDesafio.Models;

namespace trilha_net_azure_desafio.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(RHContext context, IConfiguration configuration, IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService ?? throw new ArgumentNullException(nameof(funcionarioService));
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        try
        {
            var funcionario = _funcionarioService.ObterPorId(id);

            return Ok(funcionario);
        } catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Criar(Funcionario funcionario)
    {
        try
        {
            var funcionarioId = _funcionarioService.Criar(funcionario);

            return Created("Id: ", funcionarioId);
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Funcionario funcionario)
    {
        try
        {
            _funcionarioService.Atualizar(id, funcionario);
            return Ok();
        } catch(NotFoundException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        try
        {
            _funcionarioService.Deletar(id);

            return NoContent();

        } catch(NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasCorporativos.Database;
using SistemasCorporativos.Models;

namespace SistemasCorporativos.Controllers;

[ApiController]
[Route("api/conta")]
public class ContaController : ControllerBase
{
    private readonly DataContext _context;

    public ContaController(DataContext context) => _context = context;

    [HttpPut]
    [Route("pagar/{id}/{valor}")]
    public async Task<IActionResult> Pay([FromRoute] int id, decimal valor)
    {
        Conta conta = await _context.Contas.FirstOrDefaultAsync(x => x.ContaId == id);

        if (conta == null)
        {
            return NotFound();
        }

        conta.Valor -= valor;
        
        Movimentacao movimentacao = new();
        movimentacao.ContaId = id;
        movimentacao.DataMovimento = DateTime.Now;
        movimentacao.TipoMovimentacaoId = 2;
        movimentacao.ValorMovimentacao = valor;
        
        if (conta.Valor == 0)
        {
            conta.DataPagamento = DateTime.Now;
            conta.SituacaoId = 2;
        } else if (conta.Valor < 0)
        {
            conta.DataPagamento = DateTime.Now;
            conta.SituacaoId = 2;
            movimentacao.TipoMovimentacaoId = 3;
        }

        await _context.Movimentacoes.AddAsync(movimentacao);
        _context.Contas.Update(conta);
        await _context.SaveChangesAsync();

        return Ok(conta);
    }
}
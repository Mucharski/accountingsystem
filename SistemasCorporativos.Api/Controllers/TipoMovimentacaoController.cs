using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasCorporativos.Database;
using SistemasCorporativos.Models;

namespace SistemasCorporativos.Controllers;

[ApiController]
[Route("api/tipoMovimentacao")]
public class TipoMovimentacaoController : ControllerBase
{
    private readonly DataContext _context;

    public TipoMovimentacaoController(DataContext context) => _context = context;

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] TipoMovimentacao movimentacao)
    {
        await _context.TipoMovimentacoes.AddAsync(movimentacao);
        await _context.SaveChangesAsync();

        return Created("Criado com sucesso!", movimentacao);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.TipoMovimentacoes.ToListAsync());
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasCorporativos.Database;
using SistemasCorporativos.Models;

namespace SistemasCorporativos.Controllers;

[ApiController]
[Route("api/situacao")]
public class SituacaoController : ControllerBase
{
    private readonly DataContext _context;

    public SituacaoController(DataContext context) => _context = context;
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] Situacao situacao)
    {
        await _context.Situacoes.AddAsync(situacao);
        await _context.SaveChangesAsync();

        return Created("Criado com sucesso!", situacao);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Situacoes.ToListAsync());
}
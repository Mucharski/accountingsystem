using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasCorporativos.Database;
using SistemasCorporativos.Models;

namespace SistemasCorporativos.Controllers;

[ApiController]
[Route("api/tipoConta")]
public class TipoContaController : ControllerBase
{
    private readonly DataContext _context;

    public TipoContaController(DataContext context) => _context = context;

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] TipoConta tipoConta)
    {
        await _context.TipoConta.AddAsync(tipoConta);
        await _context.SaveChangesAsync();

        return Created("Criado com sucesso!", tipoConta);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.TipoConta.ToListAsync());
}
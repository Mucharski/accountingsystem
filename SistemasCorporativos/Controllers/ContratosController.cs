using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasCorporativos.Database;
using SistemasCorporativos.Models;

namespace SistemasCorporativos.Controllers;

[ApiController]
[Route("api/contrato")]
public class ContratosController : ControllerBase
{
    private readonly DataContext _context;

    public ContratosController(DataContext context) => _context = context;

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] Contrato contrato)
    {
        await _context.Contratos.AddAsync(contrato);
        await _context.SaveChangesAsync();

        List<Conta> contas = new();

        for (int i = 1; i < contrato.QuantidadeParcelas + 1; i++)
        {
            Conta conta = new();
            conta.Valor = (contrato.ValorTotal / contrato.QuantidadeParcelas);
            conta.ParcelaReferencia = i;
            conta.CodigoBarras = Guid.NewGuid().ToString("N");
            conta.DataPagamento = null;
            conta.DataVencimento = DateTime.Today.AddMonths(i);
            conta.MultaDevida = null;
            conta.SituacaoId = 1;
            conta.ContratoId = contrato.ContratoId;

            contas.Add(conta);
        }
        
        await _context.Contas.AddRangeAsync(contas);
        await _context.SaveChangesAsync();
        
        contas.ForEach(async x =>
        {
            Movimentacao movimentacao = new();
            movimentacao.ContaId = x.ContaId;
            movimentacao.DataMovimento = DateTime.Now;
            movimentacao.TipoMovimentacaoId = 1;
            movimentacao.ValorMovimentacao = 0;

            await _context.Movimentacoes.AddAsync(movimentacao);
        });

        await _context.SaveChangesAsync();

        return Created("Criado com sucesso!", contrato);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Contratos
        .Include(contrato => contrato.Situacao)
        .Include(contrato => contrato.TipoConta)
        .ToListAsync());

    [HttpPut]
    [Route("cancelar/{id}")]
    public async Task<IActionResult> ContractCancel([FromRoute] int id)
    {
        Contrato contrato = await _context.Contratos.FindAsync(id);

        contrato.SituacaoId = 2;
        contrato.ValorTotal = 0;

        _context.Contratos.Update(contrato);

        List<Conta> contas = _context.Contas.Where(x => x.ContratoId == contrato.ContratoId).ToList();
        List<Conta> contasTable = new();
        List<Movimentacao> movimentacoesTable = new();
        
        foreach (var conta in contas)
        {
            conta.Valor = 0;
            conta.DataPagamento = DateTime.Now;
            conta.SituacaoId = 2;
            
            contasTable.Add(conta);

            var movimentacao = _context.Movimentacoes.FirstOrDefault(x => x.ContaId == conta.ContaId);
            movimentacao.TipoMovimentacaoId = 4;
            movimentacao.ValorMovimentacao = 0;
            movimentacao.DataMovimento = DateTime.Now;

            movimentacoesTable.Add(movimentacao);
        }
        
        _context.Movimentacoes.UpdateRange(movimentacoesTable);
        _context.Contas.UpdateRange(contasTable);
        await _context.SaveChangesAsync();

        return Ok(contrato);
    } 
}
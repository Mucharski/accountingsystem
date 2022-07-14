using Microsoft.EntityFrameworkCore;
using SistemasCorporativos.Models;

namespace SistemasCorporativos.Database;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = Configuration.GetConnectionString("MySql");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    
    public DbSet<TipoConta> TipoConta { get; set; }
    public DbSet<Situacao> Situacoes { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Movimentacao> Movimentacoes { get; set; }
    public DbSet<TipoMovimentacao> TipoMovimentacoes { get; set; }
}

using Accounting.Domain.Handlers;
using Accounting.Domain.Handlers.Interfaces;
using Accounting.Domain.Repositories.Interfaces;
using Accounting.Infra.Queries;
using Accounting.Infra.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependências
builder.Services.AddScoped<IAccountingHandler, AccountingHandler>();
builder.Services.AddScoped<IAccountingRepository, AccountingRepository>();
builder.Services.AddScoped<AccountingQueries, AccountingQueries>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
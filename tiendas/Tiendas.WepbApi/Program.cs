using Fases.Infrastructure;
using Fases.Infrastructure.Persistence;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RasteresExternos.Application;
using Tiendas.Aplication.ArticulosStocks.Agregar;
using Tiendas.Aplication.ArticulosVendido.Agregar;
using Tiendas.Aplication.ArticulosVendidoss.Agregar;
using Tiendas.Aplication.ArticulosVentass.Agregar;
using Tiendas.Aplication.TiendaFisica.Agregar;
using Tiendas.Aplication.TiendasFisiscas.Agregar;
using Tiendas.Infrastructure.Persistence;
using Tiendas.WepbApi.Dto;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(); 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Services.AddHealthChecks()
    .AddCheck("self", () =>
        HealthCheckResult.Healthy(builder.Environment.EnvironmentName))
    .AddDbContextCheck<ApplicationDbContext>();

//Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 2_800_000_000;
});

var app = builder.Build();

var pathBase = app.Configuration["PATH_BASE"];

if (!string.IsNullOrEmpty(pathBase))
{
    app.Logger.LogInformation("Using PATH BASE '{pathBase}'", pathBase);
    app.UsePathBase(pathBase);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors();

app.Map("error-development",
    ([FromServices] IHostEnvironment hostEnvironment, HttpContext context) =>
    {
        if (!hostEnvironment.IsDevelopment())
            return Results.NotFound();

        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>()!;

        return Results.Problem(
            detail: exceptionHandlerFeature.Error.StackTrace,
            title: exceptionHandlerFeature.Error.Message);
    }).ExcludeFromDescription();


app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecks("/liveness", new HealthCheckOptions
{
    Predicate = r => r.Name.Contains("self")
});
app.Map("error", () => Results.Problem()).ExcludeFromDescription();
          
app.MapPost("tiendas/ArticulosStock/", async ([FromForm] ArticulosDto command, IMediator mediator) =>
{
   
        var result = await mediator.Send(new AgregarArticulosStockCommand(
             command.Name,
            command.Description,
            command.Category,
            command.UrlImgs,
            command.Price,
            command.Weight,
            command.Tallas,
            command.Tipos,
            command.IdShein,
            command.SKU,
              command.image.OpenReadStream()));

    return 200;
}).WithOpenApi().DisableAntiforgery().WithFormOptions().Accepts<ArticulosDto>("multipart/form-data");

app.MapPost("tiendas", async (AgregarTiendaCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    return Results.Ok(result);
});
app.MapPost("tiendas/ArticulosVendidos", async (AgregarArticulosVendidoCommand command, IMediator mediator) =>
{
    var result = await mediator.Send(command);
    return Results.Ok(result);
});


app.MapGet("tiendas/ArticulosStock", async ( IMediator mediator) =>
{
    var result = await mediator.Send(new ObtenerArticulosStockCommand());
    return Results.Ok(result);
});

app.MapGet("tiendas/ArticulosVentas", async (IMediator mediator) =>
{
    var result = await mediator.Send(new ObtenerArticulosVentasCommand());
    return Results.Ok(result);
});

app.MapGet("tiendas/TiendasFisicas", async (IMediator mediator) =>
{
    var result = await mediator.Send(new ObtenerTiendasFisiscaCommand());
    return Results.Ok(result);
});

app.MapGet("tiendas/ArticulosVendidos", async (IMediator mediator) =>
{
    var result = await mediator.Send(new ObtenerArticulosVendidosCommand());
    return Results.Ok(result);
});

app.Run();

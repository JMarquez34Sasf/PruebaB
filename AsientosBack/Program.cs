using AsientosBack.Data;
using AsientosBack.Interfaces;
using AsientosBack.Middleware;
using AsientosBack.Models;
using AsientosBack.Repositories;
using AsientosBack.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("Front", p =>
    p.WithOrigins("http://localhost:5173")
     .AllowAnyHeader()
     .AllowAnyMethod()
     )
);
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AsientosDbContext>();
builder.Services.AddScoped<IMovimiento, MovimientoRepository>();
builder.Services.AddScoped<IMovimientoService, MovimientoService>();
builder.Services.AddScoped<IDepartamento, DepartamentoRepository>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<ITipoMovimiento, TipoRepository>();
builder.Services.AddScoped<ITipoService, TipoService>();


builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseCors("Front");

app.UseAuthorization();

app.MapControllers();

app.Run();

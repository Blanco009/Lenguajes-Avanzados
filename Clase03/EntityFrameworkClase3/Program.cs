using EntityFrameworkClase3.Data;
using EntityFrameworkClase3.Models;
using EntityFrameworkClase3.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context
builder.Services.AddDbContext<UsuarioDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBClase2")));

// DI
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EntityFrameworkClase3 API v1");
        c.RoutePrefix = string.Empty;
        c.DocumentTitle = "EntityFrameworkClase3 API Documentation";
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
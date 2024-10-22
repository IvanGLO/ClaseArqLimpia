using EjercicioCapas.Business.Services;
using EjercicioCapas.Data;
using EjercicioCapas.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectar contexto de BD (Crear el objeto en tiempo de ejecuci�n)
builder.Services.AddDbContext<AppDBContext>(
    context => {
        context.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

//Inyectar Repositorios
builder.Services.AddScoped<AutorRepository>();
builder.Services.AddScoped<BookRepository>();

//Inyectar service 
builder.Services.AddScoped<IBookService, BookServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

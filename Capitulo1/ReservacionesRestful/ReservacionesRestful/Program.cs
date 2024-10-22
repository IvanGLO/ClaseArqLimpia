using Microsoft.EntityFrameworkCore;
using ReservacionesRestful.Business.Services;
using ReservacionesRestful.Data;
using ReservacionesRestful.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectar contexto de BD (Crear el objeto en tiempo de ejecución)
builder.Services.AddDbContext<AppDBContext>(
    context => {
        context.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

//Inyectar Repositorios
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<ReservationRepository>();

//Inyectar service 
builder.Services.AddScoped<IReservationService,ReservationServiceImpl>();

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

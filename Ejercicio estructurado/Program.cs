using Ejercicio_estructurado.Bll.Classroom;
using Ejercicio_estructurado.Bll.Team;
using Ejercicio_estructurado.Repository.Team;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// ::: Interfaces - Inicio
// Bll
builder.Services.AddScoped<IClassroomBll, ClassroomBll>();
builder.Services.AddScoped<ITeamBll, TeamBll>();
// Repository
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
// ::: Interfaces - Fin


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

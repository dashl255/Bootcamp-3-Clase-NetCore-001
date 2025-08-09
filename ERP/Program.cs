using ERP.Bll.Security.Authentication;
using ERP.Bll.Security.Profile;
using ERP.Bll.User;
using ERP.CoreDB;
using ERP.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Interface DB
builder.Services.AddDbContext<BaseErpContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionDB").Get<string>());
});
// :: Interfaces - aplicativo (inicio)
// Bll
builder.Services.AddScoped<IAuthenticationBll, AuthenticationBll>();
builder.Services.AddScoped<IProfileBll, ProfileBll>();
builder.Services.AddScoped<IUserBll, UserBll>();
// :: Interfaces - aplicativo (fin)


builder.Services.AddHttpContextAccessor();

// Filter
builder.Services.AddScoped<SessionUserFilter>();

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

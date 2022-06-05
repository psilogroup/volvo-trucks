using Microsoft.EntityFrameworkCore;
using Volvo.Trucks.Businesss;
using Volvo.Trucks.Domain.Contracts.Repositories;
using Volvo.Trucks.Domain.Contracts.Services;
using Volvo.Trucks.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
// Add services to the container.

builder.Services.AddDbContext<TruckDBContext>(options => options.UseSqlite("Data Source=trucks.db"));
builder.Services.AddTransient<ITruckRepository, TruckRepository>();
builder.Services.AddTransient<ITruckService, TruckService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
app.UseAuthorization();

app.MapControllers();

app.Run();

using Apexa.Api;
using Apexa.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("Apexa")).ToList();
builder.Services.AddAutoMapper(assemblies);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApexaDbContext>(options => options.UseInMemoryDatabase("ApexaTest"));
builder.Services.AddScoped<IAdvisorRepository, AdvisorRepository>();


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

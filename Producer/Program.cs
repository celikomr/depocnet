using Microsoft.EntityFrameworkCore;
using Producer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OraDbContext>(options =>
        options.UseOracle(builder.Configuration.GetConnectionString("OraDbStr")));

builder.Services.AddDbContext<PgDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PgDbStr")));

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

using ApiLojaEletronicos.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ProdutosCs");

builder.Services.AddDbContext<ProdutosDbContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddDbContext<LoginDbContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddControllers();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use HTTPS redirection
app.UseHttpsRedirection();

// Use CORS
app.UseCors();

// Use Authorization
app.UseAuthorization();

// Map Controllers
app.MapControllers();

// Run the application
app.Run();
using System.Data;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using questao11.Application.Interface;
using questao11.Application.Service;
using questao11.Infra.Interface;
using questao11.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Dapper
builder.Services.AddScoped<IDbConnection>(provider =>
{
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    return connection;
});
#endregion

#region Services
builder.Services.AddScoped<IPensamentoService, PensamentoService>();
#endregion

#region Repositories
builder.Services.AddScoped<IPensamentoRepository, PensamentoRepository>();
#endregion

#region Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

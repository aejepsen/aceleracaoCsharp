using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Description = "Descrição do projeto", Version = "v0" });
    string file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string path = Path.Combine(AppContext.BaseDirectory, file);
    options.IncludeXmlComments(path);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }

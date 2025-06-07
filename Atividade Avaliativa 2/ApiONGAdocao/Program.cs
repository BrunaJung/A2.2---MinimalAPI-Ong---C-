using Microsoft.EntityFrameworkCore;
using ApiOngAdocaoMinimal.Endpoints;
using ApiONGAdocao.Data;
using ApiONGAdocao.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=animais.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGetEndpoints();
app.MapPostEndpoints();
app.MapDeleteEndpoints();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.Migrate();

    if (!db.Animais.Any())
    {
        db.Animais.AddRange(
            new Animal { Nome = "Luna", Especie = "Cachorro", Raca = "SRD", Idade = 2, Peso = 5.5},
            new Animal { Nome = "Mia", Especie = "Gato", Raca = "Siamês", Idade = 3, Peso = 3.8},
            new Animal { Nome = "Thor", Especie = "Cachorro", Raca = "Pitbull", Idade = 5, Peso = 12},
            new Animal { Nome = "Nina", Especie = "Gato", Raca = "Persa", Idade = 1, Peso = 6.2},
            new Animal { Nome = "Rex", Especie = "Cachorro", Raca = "Labrador", Idade = 6, Peso = 13.5},
            new Animal { Nome = "Tom", Especie = "Gato", Raca = "Maine Coon", Idade = 4, Peso = 5.6},
            new Animal { Nome = "Mel", Especie = "Cachorro", Raca = "Beagle", Idade = 3, Peso = 7.1},
            new Animal { Nome = "Bidu", Especie = "Cachorro", Raca = "Poodle", Idade = 4, Peso = 4.9},
            new Animal { Nome = "Max", Especie = "Cachorro", Raca = "Golden", Idade = 7, Peso = 15},
            new Animal { Nome = "Lili", Especie = "Gato", Raca = "SRD", Idade = 2, Peso = 5.9}
        );
        db.SaveChanges();
    }
}

app.Run();
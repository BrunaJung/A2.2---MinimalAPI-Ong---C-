using Microsoft.EntityFrameworkCore;
using ApiOngAdocaoMinimal.Endpoints;
using ApiONGAdocao.Data;
using ApiONGAdocao.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=animais.db"));

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// 🐶 Importando os endpoints organizados por pastas
app.MapGetEndpoints();
app.MapPostEndpoints();
app.MapDeleteEndpoints();

// Gerar banco e dados iniciais
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.Migrate();

    if (!db.Animais.Any())
    {
        db.Animais.AddRange(
            new Animal { Nome = "Luna", Especie = "Cachorro", Raca = "SRD", Idade = 2 },
            new Animal { Nome = "Mia", Especie = "Gato", Raca = "Siamês", Idade = 3 },
            new Animal { Nome = "Thor", Especie = "Cachorro", Raca = "Pitbull", Idade = 5 },
            new Animal { Nome = "Nina", Especie = "Gato", Raca = "Persa", Idade = 1 },
            new Animal { Nome = "Rex", Especie = "Cachorro", Raca = "Labrador", Idade = 6 },
            new Animal { Nome = "Tom", Especie = "Gato", Raca = "Maine Coon", Idade = 4 },
            new Animal { Nome = "Mel", Especie = "Cachorro", Raca = "Beagle", Idade = 3 },
            new Animal { Nome = "Bidu", Especie = "Cachorro", Raca = "Poodle", Idade = 4 },
            new Animal { Nome = "Max", Especie = "Cachorro", Raca = "Golden", Idade = 7 },
            new Animal { Nome = "Lili", Especie = "Gato", Raca = "SRD", Idade = 2 }
        );
        db.SaveChanges();
    }
}

app.Run();
using ApiONGAdocao.Data;
using ApiONGAdocao.Models;

namespace ApiOngAdocaoMinimal.Endpoints;

public static class PostEndpoints
{
    public static void MapPostEndpoints(this WebApplication app)
    {
        app.MapPost("/api/animais", async (Animal animal, AppDbContext db) =>
        {
            db.Animais.Add(animal);
            await db.SaveChangesAsync();

            return Results.Created($"/api/animais/{animal.Id}", animal);
        });
    }
}
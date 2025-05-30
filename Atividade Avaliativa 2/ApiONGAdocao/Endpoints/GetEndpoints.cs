using ApiONGAdocao.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiOngAdocaoMinimal.Endpoints;

public static class GetEndpoints
{
    public static void MapGetEndpoints(this WebApplication app)
    {
        app.MapGet("/api/animais", async (AppDbContext db) =>
            await db.Animais.ToListAsync()
        );

        app.MapGet("/api/animais/{id}", async (int id, AppDbContext db) =>
        {
            var animal = await db.Animais.FindAsync(id);
            return animal is not null ? Results.Ok(animal) : Results.NotFound();
        });
    }
}
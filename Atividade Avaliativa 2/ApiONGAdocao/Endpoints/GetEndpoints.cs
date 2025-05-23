using ApiONGAdocao.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiOngAdocaoMinimal.Endpoints;

public static class GetEndpoints
{
    public static void MapGetEndpoints(this WebApplication app)
    {
        // GET: listar todos os animais
        app.MapGet("/api/animais", async (AppDbContext db) =>
            await db.Animais.ToListAsync()
        );

        // GET: buscar animal por ID
        app.MapGet("/api/animais/{id}", async (int id, AppDbContext db) =>
        {
            var animal = await db.Animais.FindAsync(id);
            return animal is not null ? Results.Ok(animal) : Results.NotFound();
        });
    }
}
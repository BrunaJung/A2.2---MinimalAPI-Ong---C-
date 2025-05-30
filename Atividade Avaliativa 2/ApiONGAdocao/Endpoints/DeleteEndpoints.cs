using ApiONGAdocao.Data;

namespace ApiOngAdocaoMinimal.Endpoints;

public static class DeleteEndpoints
{
    public static void MapDeleteEndpoints(this WebApplication app)
    {
        app.MapDelete("/api/animais/{id}", async (int id, AppDbContext db) =>
        {
            var animal = await db.Animais.FindAsync(id);
            if (animal is null)
            {
                return Results.NotFound();
            }

            db.Animais.Remove(animal);
            await db.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}
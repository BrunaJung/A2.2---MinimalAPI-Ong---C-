using ApiONGAdocao.Data;
using ApiONGAdocao.Models;

namespace ApiOngAdocaoMinimal.Endpoints;

public static class PutEndpoints
{
    public static void MapPutEndpoints(this WebApplication app)
    {
        app.MapPut("/api/animais/{id}", async (int id, Animal animalAtualizado, AppDbContext db) =>
        {
            var animalExistente = await db.Animais.FindAsync(id);
            if (animalExistente is null)
                return Results.NotFound();

            animalExistente.Nome = animalAtualizado.Nome;
            animalExistente.Especie = animalAtualizado.Especie;
            animalExistente.Raca = animalAtualizado.Raca;
            animalExistente.Idade = animalAtualizado.Idade;
            animalExistente.Peso = animalAtualizado.Peso;

            await db.SaveChangesAsync();
            return Results.Ok(animalExistente);
        });
    }
}
using Microsoft.EntityFrameworkCore;
using ApiONGAdocao.Models;

namespace ApiONGAdocao.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
    }

    public DbSet<Animal> Animais { get; set; }
}
namespace ApiONGAdocao.Models;

public class Animal
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Raca { get; set; } = string.Empty;
    public int Idade { get; set; }
    public double Peso { get; set; }
}
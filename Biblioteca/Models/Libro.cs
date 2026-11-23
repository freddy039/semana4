namespace Biblioteca.Models;
public class Libro
{
    public int LibroId { get; set; }
    public string Titulo { get; set; } = "";
    public int AutorId { get; set; }
    public int CategoriaId { get; set; }
    public bool Disponible { get; set; }
}

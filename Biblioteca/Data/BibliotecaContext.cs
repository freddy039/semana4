using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Data;
public class BibliotecaContext(DbContextOptions<BibliotecaContext> options) : DbContext(options)
{
    public DbSet<Autor> Autores => Set<Autor>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Libro> Libros => Set<Libro>();
    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Prestamo> Prestamos => Set<Prestamo>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>().HasOne<Autor>().WithMany().HasForeignKey(x => x.AutorId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Libro>().HasOne<Categoria>().WithMany().HasForeignKey(x => x.CategoriaId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Prestamo>().HasOne<Libro>().WithMany().HasForeignKey(x => x.LibroId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Prestamo>().HasOne<Estudiante>().WithMany().HasForeignKey(x => x.EstudianteId).OnDelete(DeleteBehavior.Restrict);
    }
}
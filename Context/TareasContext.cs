using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class TareasContext:DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria =>{
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion);
        });


        modelBuilder.Entity<Tarea>(Tarea => {

            Tarea.ToTable("Tarea");
            Tarea.HasKey(t => t.TareaId);
            Tarea.HasOne(p => p.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);
            Tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            Tarea.Property(t => t.descripcion).HasMaxLength(500);
            Tarea.Property(t => t.PrioridadTarea);
            Tarea.Property(t => t.FechaCreacion);
            Tarea.Ignore(t => t.Resume);
        });
    }
}

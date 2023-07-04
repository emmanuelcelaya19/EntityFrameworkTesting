using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class TareasContext:DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options):base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
        optionsBuilder.UseMySQL(configuration.GetConnectionString("MyLocalServer"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> CategoriaInit = new List<Categoria>();
        CategoriaInit.Add(new Categoria{CategoriaId = Guid.Parse("adb3e939-67a7-4823-bed3-00825062de30"), Nombre = "Personales",Peso = 20});
        CategoriaInit.Add(new Categoria{CategoriaId = Guid.Parse("adb3e939-67a7-4823-bed3-00825062de31"), Nombre = "Trabajo",Peso = 50});

        modelBuilder.Entity<Categoria>(categoria =>{
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(CategoriaInit);
        });


        modelBuilder.Entity<Tarea>(Tarea => {

            List<Tarea> TareasInit = new List<Tarea>();
            TareasInit.Add(new Tarea{TareaId = Guid.Parse("adb3e939-67a7-4823-bed3-00825062de01"),CategoriaId = Guid.Parse("adb3e939-67a7-4823-bed3-00825062de30"),Titulo = "Revision Cadera", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now});
            TareasInit.Add(new Tarea{TareaId = Guid.Parse("adb3e939-67a7-4823-bed3-00825062de02"),CategoriaId = Guid.Parse("adb3e939-67a7-4823-bed3-00825062de31"),Titulo = "Terminar Presentacion Flx", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now });

            Tarea.ToTable("Tarea");
            Tarea.HasKey(t => t.TareaId);
            Tarea.HasOne(p => p.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);
            Tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            Tarea.Property(t => t.descripcion).HasMaxLength(500).IsRequired(false);
            Tarea.Property(t => t.PrioridadTarea);
            Tarea.Property(t => t.FechaCreacion);
            Tarea.Ignore(t => t.Resume);

            Tarea.HasData(TareasInit);
        });
    }
}

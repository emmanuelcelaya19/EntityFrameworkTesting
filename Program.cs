using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef.Models;
using projectef;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TareasContext>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

// app.MapGet("/liwhdcis",() => "Hello joto");

app.MapGet("/dbconection", async([FromServices] TareasContext dbContext)=>{
    dbContext.Database.EnsureCreated();
    return Results.Ok("base de datos en memoria: " + dbContext.Database.IsInMemory());
});


app.MapGet("/api/tareas", async([FromServices] TareasContext dbContext)=>{
    return Results.Ok(
        dbContext.Tareas.Include(c => c.Categoria));
});

app.MapPost("/api/tareas", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>{

    tarea.TareaId =  Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;

    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok("Succesfully inserted data");
});

app.MapDelete("/api/tareas/{Id}", async([FromServices] TareasContext dbContext, [FromRoute]Guid Id)=>{

    var PreviousTareaData = dbContext.Tareas.Find(Id);
    if(PreviousTareaData!=null){
        await dbContext.Tareas.Where(p=> p.TareaId == PreviousTareaData.TareaId).ExecuteDeleteAsync();
        await dbContext.SaveChangesAsync();
        return Results.Ok("Succesfully Deleted data");
    }
    else{
        return Results.NotFound();
    }
    
});

app.MapPut("/api/tareas/{Id}", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute]Guid Id)=>{

    var PreviousTareaData = dbContext.Tareas.Find(Id);

    if(PreviousTareaData!=null){
        PreviousTareaData.CategoriaId = tarea.CategoriaId;
        PreviousTareaData.descripcion = tarea.descripcion;
        PreviousTareaData.PrioridadTarea = tarea.PrioridadTarea;
        PreviousTareaData.Titulo = tarea.Titulo;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    else{
        return Results.NotFound();
    }
});



app.Run();

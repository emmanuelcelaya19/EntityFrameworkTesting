using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TareasContext>(p => p.UseMySQL(builder.Configuration.GetConnectionString("cnTareas")));

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

// app.MapGet("/liwhdcis",() => "Hello joto");

app.MapGet("/dbconection", async([FromServices] TareasContext dbContext)=>{
    dbContext.Database.EnsureCreated();
    return Results.Ok("base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();

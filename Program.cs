using Microsoft.EntityFrameworkCore;
using SoyAgaci.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// ENV (ConnectionStrings__Default) > appsettings.json öncelik
var cs = builder.Configuration.GetConnectionString("Default")
         ?? Environment.GetEnvironmentVariable("ConnectionStrings__Default")
         ?? throw new InvalidOperationException("Connection string missing.");

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(cs, ServerVersion.AutoDetect(cs)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Auto-migrate (ilk açılışta tablo oluşturur/günceller)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", () => "ok");

// Basit People uçları
app.MapGet("/people", async (AppDbContext db) => await db.People.ToListAsync());
app.MapGet("/people/{id:int}", async (AppDbContext db, int id) =>
    await db.People.FindAsync(id) is { } p ? Results.Ok(p) : Results.NotFound());
app.MapPost("/people", async (AppDbContext db, Person p) =>
{
    db.People.Add(p);
    await db.SaveChangesAsync();
    return Results.Created($"/people/{p.Id}", p);
});
app.MapDelete("/people/{id:int}", async (AppDbContext db, int id) =>
{
    var p = await db.People.FindAsync(id);
    if (p is null) return Results.NotFound();
    db.People.Remove(p);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

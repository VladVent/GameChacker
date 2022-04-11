using GameChacker.Data;
using GameChacker.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGameRepository ,GameRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddDbContext<GameLibraryContext>(options =>
{
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GamesDB;Trusted_Connection=True;");
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var servise = scope.ServiceProvider;
    var loggerFactory = servise.GetService<ILoggerFactory>();
    try
    {
        var context = servise.GetRequiredService<GameLibraryContext>();
        await GameSeedContext.SeedAsync(context, loggerFactory);

    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An Error the Migration");
    }
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

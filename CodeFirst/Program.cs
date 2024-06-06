using CodeFirst.Models;
using CodeFirst.Services.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibreriaContext>();
builder.Services.AddScoped<IAutorRepositorio, FakeAutorRepositorio>();
builder.Services.AddScoped<ILibroRepositorio, FakeLibroRepositorio>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

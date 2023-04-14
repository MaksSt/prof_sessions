using PassOrderKPro.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<MainDbContext, MainDbContext>();
builder.Services.AddRazorPages();
var app = builder.Build();

app.MapRazorPages();
app.UseStaticFiles();
app.Run();
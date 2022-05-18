using MessageSenderMVC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IRepository<Person>, InRamRepo>();

var connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<MSSQLLocalDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository<Person>, MSSQLLocalRepository>();

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

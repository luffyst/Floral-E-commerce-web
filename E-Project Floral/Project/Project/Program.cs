using Project.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<myContext>(options => options.UseSqlServer(
   builder.Configuration.GetConnectionString("myconnection")));
builder.Services.AddMvc();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(100);
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Home}"
    );
app.UseSession();
app.UseStaticFiles();
app.Run();

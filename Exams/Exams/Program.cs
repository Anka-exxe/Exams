using Microsoft.EntityFrameworkCore;
using Exams.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExamsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ExamsContext>();
    ExamsDbInitializer.Initialize(context); // Инициализация данных
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Exam}/{action=Index}");

app.Run();

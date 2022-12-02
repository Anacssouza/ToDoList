using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Repositorio;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IAtividadeRepositorio, AtividadeRepositorio>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
        }
    }
}
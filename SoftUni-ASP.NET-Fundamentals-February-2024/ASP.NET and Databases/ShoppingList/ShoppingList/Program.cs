using Microsoft.EntityFrameworkCore;
using ShoppingList.Core.Contracts;
using ShoppingList.Core.Services;
using ShoppingList.Infrastructure.Context;

namespace ShoppingList
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var app = InitializeAppAndServices(args);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static WebApplication InitializeAppAndServices(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("MsSqlServer");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ShoppingListDbContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IProductService, ProductService>();

            return builder.Build();

        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext< BazarDbContext>(options =>
    options.UseSqlServer(connectionString));//NameDbContext
builder.Services.AddDatabaseDeveloperPageExceptionFilter();




//Copy/Paste 2.Identity Requirements into the skeleton
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    // Password settings.
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    //options.Password.RequiredLength = 6;
    //options.Password.RequiredUniqueChars = 1;

    //// Lockout settings.
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //options.Lockout.MaxFailedAccessAttempts = 5;
    //options.Lockout.AllowedForNewUsers = true;

    //// User settings.
    //options.User.AllowedUserNameCharacters =
    //     "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    //options.User.RequireUniqueEmail = false;
})

    .AddEntityFrameworkStores<BazarDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
});//!

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

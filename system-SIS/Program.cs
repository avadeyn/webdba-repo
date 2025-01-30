using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using system_SIS.Services;
using system_SIS.Services.NewFolder;
using system_SIS.Services.AdminBackEnd;
using system_SIS.Controllers.AdminBackEnd;
using AutoMapper;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        // Register services
        builder.Services.AddScoped<AdminClassController>();
        builder.Services.AddScoped<IAdminClassService, AdminClassService>();
        builder.Services.AddScoped<IAdminScheduleService, AdminScheduleService>();
        builder.Services.AddScoped<IFacultyService, FacultyService>();

        // Add AutoMapper
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        // Update DbContext registration using the full namespace
        builder.Services.AddDbContext<system_SIS.Services.ApplicationDBContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        // Update Identity to use the full namespace
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<system_SIS.Services.ApplicationDBContext>();

        // Add CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .WithExposedHeaders("Content-Disposition");
            });
        });

        // Add Logging
        builder.Services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddDebug();
        });

        // Add Session
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("AllowAll");
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Signin}/{id?}");

        // Initialize Roles
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = new[] { "Admin", "Faculty", "Student", "Applicant" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        // Initialize Admin User
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var adminEmail = "nadinexschool@gmail.com";
            var adminPassword = "@Admin123";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var user = new IdentityUser
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        // Initialize Faculty User
        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var facultyEmail = "altheaamorasis@gmail.com";
            var facultyPassword = "Faculty-01";

            if (await userManager.FindByEmailAsync(facultyEmail) == null)
            {
                var user = new IdentityUser
                {
                    Email = facultyEmail,
                    UserName = facultyEmail
                };
                await userManager.CreateAsync(user, facultyPassword);
                await userManager.AddToRoleAsync(user, "Faculty");
            }
        }

        app.Run();
    }
}
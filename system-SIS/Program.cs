using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using system_SIS.Services;
using system_SIS.Services.NewFolder;
using system_SIS.Services.AdminBackEnd;
using system_SIS.Controllers.AdminBackEnd;
using system_SIS.Data;


public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<AdminClassController>();
        builder.Services.AddScoped<IAdminClassService, AdminClassService>();
        builder.Services.AddScoped<IAdminScheduleService, AdminScheduleService>();
        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddScoped<IAdminClassService, AdminClassService>();

        builder.Services.AddDbContext<ApplicationDBContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            // Configure identity options here
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDBContext>();


        // Register IFacultyService and its implementation
        builder.Services.AddScoped<IFacultyService, FacultyService>();

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

        builder.Services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddDebug();
        });

        var app = builder.Build();

        // Add session services
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

		//var TwilioAccountSid = builder.Configuration["Twilio:AccountSid"];
		//var TwilioAuthToken = builder.Configuration["Twilio:AuthToken"];
		//var TwilioPhoneNumber = builder.Configuration["Twilio:PhoneNumber"];

		//builder.Services.AddSingleton<ISmsService>(new TwilioSmsService(TwilioAccountSid, TwilioAuthToken, TwilioPhoneNumber));


        var app = builder.Build();

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
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Signin}/{id?}");


        app.UseRouting(); // Already stated in the AdminBackend code

        app.UseSession(); // Ensure this line is present and before UseAuthorization

        app.UseAuthorization(); // Already stated in the AdminBackend code

        app.MapStaticAssets();

        app.MapControllerRoute( // Already stated in the AdminBackend code
            name: "default",
            pattern: "{controller=Account}/{action=Signin}/{id?}")
            .WithStaticAssets();


        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new string[] { "Admin", "Faculty", "Student", "Applicant" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string email = "nadinexschool@gmail.com";
            string password = "@Admin123";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser();
                user.Email = email;
                user.UserName = email;

                Console.WriteLine("Creating user: " + email);
                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string email = "altheaamorasis@gmail.com";
            string password = "Faculty-01";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser();
                user.Email = email;
                user.UserName = email;

                Console.WriteLine("Creating user: " + email);
                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Faculty");
            }
        }

        app.Run();
    }


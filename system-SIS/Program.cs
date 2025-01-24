using system_SIS.Services;
using Microsoft.EntityFrameworkCore;    

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
	var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
	options.UseSqlServer(connectionString);
});

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});
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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Account}/{action=Signin}/{id?}")
    //pattern: "{controller=Account}/{action=Signup}/{id?}")
    //PORTALS
    //pattern: "{controller=FacultyPortal}/{action=Index}/{id?}")
    pattern: "{controller=AdminPortal}/{action=Index}/{id?}")
    //pattern: "{controller=AdmissionPortal}/{action=Home}/{id?}")
    //pattern: "{controller=StudentsPortal}/{action=Home}/{id?}")

    .WithStaticAssets();

app.Run();

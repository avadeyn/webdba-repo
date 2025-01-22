using system_SIS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();

		builder.Services.AddDbContext<ApplicationDBContext>(options =>
		{
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			options.UseSqlServer(connectionString);
		});

		//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
		//{
		//	// Configure identity options here
		//})
		//	.AddRoles<IdentityRole>()
		//	.AddEntityFrameworkStores<ApplicationDBContext>();


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

		app.MapStaticAssets();

		app.MapControllerRoute(
			name: "default",
			//pattern: "{controller=Students}/{action=Index}/{id?}")
			pattern: "{controller=Account}/{action=Signin}/{id?}")
			//pattern: "{controller=Account}/{action=Signup}/{id?}")
			//PORTALS
			//pattern: "{controller=FacultyPortal}/{action=Index}/{id?}")
			//pattern: "{controller=AdminPortal}/{action=Index}/{id?}")
			//pattern: "{controller=StudentsPortal}/{action=Home}/{id?}")
			//pattern: "{controller=AdmissionPortal}/{action=Index}/{id?}")
			.WithStaticAssets();

		//using (var scope = app.Services.CreateScope())
		//{
		//	var services = scope.ServiceProvider;
		//	var context = services.GetRequiredService<ApplicationDBContext>();
		//	context.Database.Migrate();
		//}













		app.Run();




	}

}
       


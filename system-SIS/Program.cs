using system_SIS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllersWithViews();

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
			pattern: "{controller=Account}/{action=Signin}/{id?}")
			.WithStaticAssets();



		//using (var scope = app.Services.CreateScope())
		//{
		//	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

		//	var roles = new string[] { "Admin", "Faculty", "Student", "Applicant" };

		//	foreach (var role in roles)
		//	{
		//		if (!await roleManager.RoleExistsAsync(role))
		//		{
		//			await roleManager.CreateAsync(new IdentityRole(role));
		//		}
		//	}
		//}

		//using (var scope = app.Services.CreateScope())
		//{
		//	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

		//	string email = "nadinexschool@gmail.com";
		//	string password = "@Admin123";

		//	if(await userManager.FindByEmailAsync(email) == null)
		//	{
		//		var user = new IdentityUser();
		//		user.Email = email;
		//		user.UserName = email;

		//		Console.WriteLine("Creating user: " + email);
		//		await userManager.CreateAsync(user, password);

		//		await userManager.AddToRoleAsync(user, "Admin");
		//	}

		
			 
		//}







		app.Run();
	}
}
       


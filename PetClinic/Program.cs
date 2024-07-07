using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICageService, CageService>();
builder.Services.AddScoped<IHospitalizeService, HospitalizeService>();

//Explicitly register db context
builder.Services.AddDbContext<PetClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetClinic")));



// Add authentication services
builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
	.AddCookie()
	.AddGoogle(options =>
	{
		options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
		options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
	});


// Add authorization, routing, and Razor Pages
builder.Services.AddAuthorization();
builder.Services.AddRouting();

builder.Services.AddSession();
builder.Services.AddRazorPages();

builder.Services.AddLogging(logging =>
{
	logging.ClearProviders();
	logging.AddConsole();
	logging.AddDebug();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();


app.Run();

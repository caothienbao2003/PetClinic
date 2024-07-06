using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICageService, CageService>();
builder.Services.AddScoped<IHospitalizeService, HospitalizeService>();

//Explicitly register db context
builder.Services.AddDbContext<PetClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetClinic")));


/*
// Add authentication services
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddGoogle(options =>
{
	options.ClientId = "851158419909-3sdgr7v1se9jfv421fgfi03llmokniia.apps.googleusercontent.com";
	options.ClientSecret = "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";
});
*/

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

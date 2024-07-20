using System.Net;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PetClinic.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICageService, CageService>();
builder.Services.AddScoped<IHospitalizeService, HospitalizeService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IMedicineService, MedicineService>();

//builder.Services.AddScoped<IVaccinationDetailService, VaccinationDetailService>();
builder.Services.AddScoped<IVaccinationRecordService, VaccinationRecordService>();

builder.Services.AddScoped<IEmailService>(provider => 
        new EmailService("smtp.your-email-provider.com", 587, "your-email@example.com", "your-email-password"));



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
		 options.ClientId = builder.Configuration.GetSection("Authentication:Google:ClientId").Value;
		 options.ClientSecret = builder.Configuration.GetSection("Authentication:Google:ClientSecret").Value;
	});
	/*
	.AddGoogle(options =>
	{
		options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
		options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
	});
	*/

// Add authorization, routing, and Razor Pages
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Customer", policy =>
        policy.Requirements.Add(new RoleRequirement(0)));
    options.AddPolicy("Staff", policy =>
        policy.Requirements.Add(new RoleRequirement(1)));
	options.AddPolicy("Doctor", policy =>
        policy.Requirements.Add(new RoleRequirement(2)));
    options.AddPolicy("Admin", policy =>
        policy.Requirements.Add(new RoleRequirement(3)));
});
builder.Services.AddSingleton<IAuthorizationHandler, RoleAuthorizationHandler>();

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

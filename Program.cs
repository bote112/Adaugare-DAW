using DAW.Models;
using DAW.Data; // Asigură-te că namespace-ul este corect pentru StiriDbContext
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Azure.Messaging.ServiceBus;
using DAW.Repositories;
using DAW.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Folosește șirul de conexiune pentru "StiriDB" și înregistrează StiriDbContext
var connectionString = builder.Configuration.GetConnectionString("StiriDBConnection") ?? throw new InvalidOperationException("Connection string 'StiriDBConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => 
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Actualizează aici dacă StiriDbContext va fi utilizat pentru Identity, altfel va trebui să păstrezi ApplicationDbContext pentru Identity sau să configurezi Identity să utilizeze StiriDbContext
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>(); // Asigură-te că StiriDbContext include suportul pentru Identity, dacă este utilizat aici

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(s =>
{
    var connectionString = builder.Configuration["ServiceBus:ConnectionString"];
    return new ServiceBusClient(connectionString);
});

builder.Services.AddScoped<IStiriRepository, StiriRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ICategoriiRepository, CategoriiRepository>();


builder.Services.AddScoped<IStiriService, StiriService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<ICategoriiService, CategoriiService>();

builder.Services.AddSignalR();


var app = builder.Build();

app.MapHub<ChatHub>("/chatHub");

// Configurează SignalR în pipeline-ul de request-uri



using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub"); // Asociază hub-ul cu o rută accesibilă de la client
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapFallbackToFile("index.html");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configurare rute specifice pentru fiecare controller

app.MapControllerRoute(
    name: "categorii_index",
    pattern: "Categorii",
    defaults: new { controller = "Categorii", action = "Index" });

app.MapControllerRoute(
    name: "categorii_details",
    pattern: "Categorii/Details/{id?}",
    defaults: new { controller = "Categorii", action = "Details" });

app.MapControllerRoute(
    name: "categorii_create_get",
    pattern: "Categorii/Create",
    defaults: new { controller = "Categorii", action = "Create" });

app.MapControllerRoute(
    name: "categorii_edit",
    pattern: "Categorii/Edit/{id?}",
    defaults: new { controller = "Categorii", action = "Edit" });

app.MapControllerRoute(
    name: "categorii_delete",
    pattern: "Categorii/Delete/{id?}",
    defaults: new { controller = "Categorii", action = "Delete" });

app.MapControllerRoute(
    name: "stiri_index",
    pattern: "Stiri",
    defaults: new { controller = "Stiri", action = "Index" });

app.MapControllerRoute(
    name: "stiri_details",
    pattern: "Stiri/Details/{id?}",
    defaults: new { controller = "Stiri", action = "Details" });

app.MapControllerRoute(
    name: "stiri_create_get",
    pattern: "Stiri/Create",
    defaults: new { controller = "Stiri", action = "Create" });

app.MapControllerRoute(
    name: "stiri_edit_get",
    pattern: "Stiri/Edit/{id?}",
    defaults: new { controller = "Stiri", action = "Edit" });

app.MapControllerRoute(
    name: "stiri_delete_get",
    pattern: "Stiri/Delete/{id?}",
    defaults: new { controller = "Stiri", action = "Delete" });

app.MapControllerRoute(
    name: "feedback_index",
    pattern: "Feedback",
    defaults: new { controller = "Feedback", action = "Index" });

app.MapControllerRoute(
    name: "feedback_create_get",
    pattern: "Feedback/Create",
    defaults: new { controller = "Feedback", action = "Create" });



app.Run();

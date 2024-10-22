using Microsoft.AspNetCore.Identity; // Importing Identity namespace for user authentication and authorization
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core for database operations
using Microsoft.Extensions.DependencyInjection; // Importing for dependency injection

var builder = WebApplication.CreateBuilder(args); // Creating a builder for the web application

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configuring the application to use SQL Server database

// Configuring Identity services with default settings
builder.Services.AddDefaultIdentity<ApplicationUser >(options => {
    options.SignIn.RequireConfirmedAccount = false; // Disabling requirement for confirmed account for sign-in
    
    // Simplified password requirements for user registration
    options.Password.RequireDigit = false; // No requirement for digits in password
    options.Password.RequireUppercase = false; // No requirement for uppercase letters in password
    options.Password.RequireLowercase = true; // At least one lowercase letter is required
    options.Password.RequireNonAlphanumeric = false; // No requirement for non-alphanumeric characters
    options.Password.RequiredLength = 6; // Minimum length of password is 6 characters
})
.AddEntityFrameworkStores<ApplicationDbContext>(); // Configuring Identity to use Entity Framework for data storage

builder.Services.AddRazorPages(); // Adding Razor Pages services to the application

var app = builder.Build(); // Building the web application

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // Check if the environment is not Development
{
    app.UseExceptionHandler("/Error"); // Use a custom error handling page
    app.UseHsts(); // Enable HTTP Strict Transport Security (HSTS)
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Enable serving static files (e.g., CSS, JS, images)

app.UseRouting(); // Enable routing for incoming requests
app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization(); // Enable authorization middleware

app.MapRazorPages(); // Map Razor Pages to the request pipeline

app.Run(); // Run the web application
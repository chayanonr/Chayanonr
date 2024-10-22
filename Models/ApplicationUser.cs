// Import the necessary namespace for ASP.NET Core Identity
using Microsoft.AspNetCore.Identity;

// Define a custom user class that inherits from IdentityUser
// This allows you to add custom properties and methods to the user class
public class ApplicationUser : IdentityUser
{
    // By default, IdentityUser includes properties for the user's username, email, and password
    // You can add custom properties here if needed
}
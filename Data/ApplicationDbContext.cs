using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Importing Identity.EntityFrameworkCore namespace for Identity-related functionality
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core namespace for database operations

// This class represents the application's database context
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    // Constructor that takes DbContextOptions as a parameter
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) // Calling the base class constructor with the provided options
    {
    }
}
using Microsoft.AspNetCore.Identity; // Importing Identity namespace for user authentication and management
using Microsoft.AspNetCore.Mvc; // Importing MVC framework for building web applications
using Microsoft.AspNetCore.Mvc.RazorPages; // Importing Razor Pages for page-based programming
using System.Threading.Tasks; // Importing Task for asynchronous programming

namespace chayanonr.Pages // Namespace for the current page
{
    // This class represents the user profile page model
    public class UserProfileModel : PageModel
    {
        // Private fields to hold instances of UserManager and SignInManager
        private readonly UserManager<ApplicationUser > _userManager; // Manages user accounts
        private readonly SignInManager<ApplicationUser > _signInManager; // Manages user sign-in

        // Public property to hold the currently logged-in user's information
        public ApplicationUser ? CurrentUser  { get; set; }

        // Constructor that injects UserManager and SignInManager
        public UserProfileModel(UserManager<ApplicationUser > userManager, SignInManager<ApplicationUser > signInManager)
        {
            _userManager = userManager; // Assigning UserManager instance
            _signInManager = signInManager; // Assigning SignInManager instance
        }

        // This method is called when the page is accessed via GET request
        public async Task<IActionResult> OnGetAsync()
        {
            // Fetch the currently logged-in user using UserManager
            CurrentUser  = await _userManager.GetUserAsync(User);

            // Check if the user is not logged in
            if (CurrentUser  == null)
            {
                // Log for debugging purposes
                Console.WriteLine("No user is logged in. Redirecting to login.");
                return RedirectToPage("/Login"); // Redirect to the login page
            }

            // Log to check if user info is retrieved successfully
            Console.WriteLine($"User  Info: Email = {CurrentUser .Email}, Username = {CurrentUser .UserName}");

            return Page(); // Return the current page with user information
        }

        // This method is called when the logout action is triggered (POST request)
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync(); // Sign out the current user
            return RedirectToPage("/Login"); // Redirect to the login page after logout
        }
    }
}
using Microsoft.AspNetCore.Identity; // Importing Identity namespace for user management
using Microsoft.AspNetCore.Mvc; // Importing MVC framework for building web applications
using Microsoft.AspNetCore.Mvc.RazorPages; // Importing Razor Pages for page-based programming
using System.Threading.Tasks; // Importing Task for asynchronous programming

namespace chayanonr.Pages // Namespace for the current page
{
    // This class represents the registration page model
    public class RegisterModel : PageModel
    {
        // Private fields to hold instances of UserManager and SignInManager
        private readonly UserManager<ApplicationUser > _userManager; // Manages user accounts
        private readonly SignInManager<ApplicationUser > _signInManager; // Manages user sign-in

        // This property holds the input data for registration
        [BindProperty]
        public RegisterInputModel Input { get; set; }

        // Constructor that injects UserManager and SignInManager
        public RegisterModel(UserManager<ApplicationUser > userManager, SignInManager<ApplicationUser > signInManager)
        {
            _userManager = userManager; // Assigning UserManager instance
            _signInManager = signInManager; // Assigning SignInManager instance
        }

        // This method is called when the page is accessed via GET request
        public void OnGet()
        {
            // No specific action on GET, just displaying the registration page
        }

        // This method is called when the registration form is submitted (POST request)
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model state is valid (form data is valid)
            if (ModelState.IsValid)
            {
                // Create a new user object with the provided email and password
                var user = new ApplicationUser  { UserName = Input.Email, Email = Input.Email };
                
                // Attempt to create the user asynchronously
                var result = await _userManager.CreateAsync(user, Input.Password);

                // Log to console for debugging
                if (result.Succeeded) // Check if user creation was successful
                {
                    // Log success message
                    Console.WriteLine("User  registered successfully.");
                    
                    // Sign in the user without making the session persistent
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                    // Redirect to the Login page after successful registration
                    return RedirectToPage("/Login");
                }
                else
                {
                    // Log failure message and show error messages
                    Console.WriteLine("User  registration failed.");
                    
                    // Loop through the errors and add them to the ModelState for display
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}"); // Log the error description
                        ModelState.AddModelError(string.Empty, error.Description); // Add error to ModelState
                    }
                }
            }
            else
            {
                // Log that the model state is not valid
                Console.WriteLine("Model state is not valid.");
            }

            // Return the page with the current ModelState (errors will be displayed)
            return Page();
        }

        // This nested class represents the input model for registration
        public class RegisterInputModel
        {
            public string Email { get; set; } // Property for user email
            public string Password { get; set; } // Property for user password
            public string ConfirmPassword { get; set; } // Property for confirming user password
        }
    }
}
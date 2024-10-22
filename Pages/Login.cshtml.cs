// This is the namespace for the current page
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// This is the namespace for the current page
namespace chayanonr.Pages
{
    // This class represents the Login page model
    public class LoginModel : PageModel
    {
        // This is a private field that holds an instance of SignInManager
        // SignInManager is used to manage the sign-in process for users
        private readonly SignInManager<ApplicationUser> _signInManager;

        // This is a public property that holds the input data for the login form
        // It is decorated with the [BindProperty] attribute, which allows it to be bound to the form data
        [BindProperty]
        public LoginInputModel Input { get; set; }

        // This is the constructor for the LoginModel class
        // It takes an instance of SignInManager as a parameter and assigns it to the _signInManager field
        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        // This is the OnGet method, which is called when the page is first loaded
        // It does not perform any actions in this case, but it could be used to initialize the page or load data
        public void OnGet()
        {
        }

        // This is the OnPostAsync method, which is called when the login form is submitted
        // It is an asynchronous method, which means it can perform long-running operations without blocking the thread
        public async Task<IActionResult> OnPostAsync()
        {
            // This checks if the ModelState is valid, which means that the form data has been validated successfully
            if (ModelState.IsValid)
            {
                // This calls the PasswordSignInAsync method on the _signInManager instance
                // It attempts to sign in the user with the provided email and password
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, false);

                // This checks if the sign-in was successful
                if (result.Succeeded)
                {
                    // If the sign-in was successful, this redirects the user to the UserProfile page
                    return RedirectToPage("/UserProfile");
                }
                else
                {
                    // If the sign-in was not successful, this adds an error message to the ModelState
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // This returns the current page, which will display any error messages that have been added to the ModelState
            return Page();
        }

        // This is a nested class that represents the input data for the login form
        public class LoginInputModel
        {
            // This is a public property that holds the email address entered by the user
            public string Email { get; set; }

            // This is a public property that holds the password entered by the user
            public string Password { get; set; }
        }
    }
}
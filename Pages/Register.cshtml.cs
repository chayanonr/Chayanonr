using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace chayanonr.Pages{
public class RegisterModel : PageModel
{
  private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    [BindProperty]
    public RegisterInputModel Input { get; set; }

    public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
            var result = await _userManager.CreateAsync(user, Input.Password);

            // Log to console for debugging
            if (result.Succeeded)
            {
                // Log success
                Console.WriteLine("User registered successfully.");
                
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Login");
            }
            else
            {
                // Log failure and show error messages
                Console.WriteLine("User registration failed.");
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Error: {error.Description}");
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        else
        {
            Console.WriteLine("Model state is not valid.");
        }

        return Page();
    }

    public class RegisterInputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
}
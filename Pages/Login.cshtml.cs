using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace chayanonr.Pages{
public class LoginModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    [BindProperty]
    public LoginInputModel Input { get; set; }

    public LoginModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToPage("/UserProfile");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        return Page();
    }

    public class LoginInputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
}
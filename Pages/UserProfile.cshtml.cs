using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
namespace chayanonr.Pages{
public class UserProfileModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public ApplicationUser ? CurrentUser { get; set; }

    public UserProfileModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        // Fetch the currently logged-in user
        CurrentUser = await _userManager.GetUserAsync(User);
        
        if (CurrentUser == null)
        {
            // Log for debugging purposes
            Console.WriteLine("No user is logged in. Redirecting to login.");
            return RedirectToPage("/Login");
        }

        // Log to check if user info is retrieved
        Console.WriteLine($"User Info: Email = {CurrentUser.Email}, Username = {CurrentUser.UserName}");

        return Page();
    }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await _signInManager.SignOutAsync();
        return RedirectToPage("/Login");
    }
}
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace chayanonr.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = string.Empty;
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle form submission logic here (e.g., send an email)

            return RedirectToPage("/ThankYou"); // Redirect to a thank-you page or similar
        }
    }
}

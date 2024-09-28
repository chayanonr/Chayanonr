using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MimeKit;

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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if Name or Email is null or empty
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                ModelState.AddModelError(string.Empty, "Name and Email are required.");
                return Page();
            }

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Chayanon", "chayanon.career@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(Name, Email)); // Use the Email from the form
            emailMessage.Subject = "New Contact Form Submission";
            emailMessage.Body = new TextPart("plain")
            {
                Text = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}"
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("chayanon.career@gmail.com", "leyx vqnu zqyh zuzs"); // Use your app password

                client.Send(emailMessage);
                client.Disconnect(true);
            }

            TempData["Message"] = "Your message has been sent successfully!";
            return RedirectToPage();
        }
    }
}

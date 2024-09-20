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

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Chayanon", "chayanon.career@gmail.com")); // Your email
            emailMessage.To.Add(new MailboxAddress(Name, "chayanon.career@gmail.com")); // Recipient email (your email)
            emailMessage.Subject = "New Contact Form Submission";
            emailMessage.Body = new TextPart("plain")
            {
                Text = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}"
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true; // Bypass SSL validation (for testing only)
                
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("chayanon.career@gmail.com", "leyx vqnu zqyh zuzs"); // Replace with your actual app password

                client.Send(emailMessage);
                client.Disconnect(true);
            }

            TempData["Message"] = "Your message has been sent successfully!";
            return RedirectToPage();
        }
    }
}

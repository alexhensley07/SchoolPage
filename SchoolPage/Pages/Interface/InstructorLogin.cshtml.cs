using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPage.Pages.DB;
using SchoolPage.Pages.DBClasses;

namespace SchoolPage.Pages.Interface
{
    public class InstructorLoginModel : PageModel
    {
        public String Username { get; set; }
        public Credentials AddCredentials { get; set; }

        public String Password { get; set; }
        public String LoginMessage { get; set; }
        public void OnGet(String Logout)
        {
            if (Logout != null)
            {
                HttpContext.Session.Clear();
                LoginMessage = "Log out successful!";
            }
        }

        public IActionResult OnPost()
        {
            if (DBClass.SecureLogin(Username, Password) > 0)
            {
                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Password", Password);
               
                ViewData["LoginMessage"] = "Login Successful";
                DBClass.SchoolDBConnection.Close();
                return RedirectToPage("InstructorFront");
            }
            else
            {
                ViewData["LoginMessage"] = "Incorrect Username or password";
            }
            return Page();

        }
    }
}

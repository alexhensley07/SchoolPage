using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPage.Pages.DB;
using SchoolPage.Pages.DBClasses;



namespace SchoolPage.Pages.Interface
{

    public class StudentPageModel : PageModel
    {
        [BindProperty]
        public Student AddStudent { get; set; }
        [BindProperty]
        public String? FirstName { get; set; }
        [BindProperty]
        public String? LastName { get; set; }
        [BindProperty]
        public String? Email { get; set; }
        [BindProperty]
        public String? Phone { get; set; }
        [BindProperty]
        public int PartnerID { get; set; }


        public void OnGet()
        {
        }




        public IActionResult OnPost()
        {
            DBClass.InsertStudent(AddStudent);

            DBClass.SchoolDBConnection.Close();

            return Page();



        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            FirstName = "Test Name";

            return Page();
        }
    }
}

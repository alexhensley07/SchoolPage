using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPage.Pages.DB;
using SchoolPage.Pages.DBClasses;
using System.Data.SqlClient;

namespace SchoolPage.Pages.Interface
{
    public class MeetingPageModel : PageModel
    {
        [BindProperty]
        public Meeting addMeeting { get; set; }


        public void OnGet()
        {
           
        }



        public IActionResult OnPost()
        {
            DBClass.InsertMeeting(addMeeting);

            DBClass.SchoolDBConnection.Close();

            return Page();



        }

    }
}

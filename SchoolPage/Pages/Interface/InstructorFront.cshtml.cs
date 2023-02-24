using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPage.Pages.DB;
using SchoolPage.Pages.DBClasses;
using System.Data.SqlClient;

namespace SchoolPage.Pages.Interface
{
    public class InstructorFrontModel : PageModel
    {
        public List<Student> StudentList { get; set; }
        public InstructorFrontModel() 
        {
            StudentList = new List<Student>();
        }
        [BindProperty]
        public OfficeHours AddOfficeHours { get; set; }
        
        public void OnGet()
        {
            SqlDataReader studentReader = DBClass.StudentReader();
            while (studentReader.Read())
            {
                StudentList.Add(new Student
                {
                    studentID = int.Parse(studentReader["studentID"].ToString()),
                    studentFirstName = studentReader["studentFirstName"].ToString(),
                    studentLastName = studentReader["studentLastName"].ToString(),
                    studentEmail = studentReader["studentEmail"].ToString(),
                    studentPhone = studentReader["studentPhone"].ToString(),
              


                });
            }
            DBClass.SchoolDBConnection.Close();
        }
        public IActionResult OnPost()
        {
            DBClass.InsertOfficeHours(AddOfficeHours);

            DBClass.SchoolDBConnection.Close();

            return Page();



        }
    }
}

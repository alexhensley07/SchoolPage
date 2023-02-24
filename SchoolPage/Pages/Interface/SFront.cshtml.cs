using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolPage.Pages.DB;
using SchoolPage.Pages.DBClasses;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolPage.Pages.Interface
{
    public class SFrontModel : PageModel
    {

        public List<SelectListItem> InstructorList { get; set; }
        public List<OfficeHours> OHList { get; set; }
        public List<Meeting> MeetingList { get; set; }

        public List<Class> ClassList { get; set; }  
        [BindProperty]
        public int SelectInstructor { get; set; }
        public String SelectProfessor { get; set; }

        public SFrontModel() 
        {
            
            OHList = new List<OfficeHours>();
            ClassList = new List<Class>();
            MeetingList = new List<Meeting>();
        }

        public void OnGet()
        {

            SqlDataReader instructorReader = DBClass.InstructorReader();
            InstructorList = new List<SelectListItem>();
            while (instructorReader.Read())
            {
                InstructorList.Add(
                    new SelectListItem(
                         instructorReader["instructorFirstName"].ToString() + " " + instructorReader["instructorLastName"].ToString(),
                         instructorReader["instructorID"].ToString()));
             
            }
            DBClass.SchoolDBConnection.Close();
            SqlDataReader ohReader = DBClass.OfficeHoursReader();
            while (ohReader.Read())
            {
                OHList.Add(new OfficeHours
                {
                    officeHoursID = int.Parse(ohReader["officeHoursID"].ToString()),
                    ohDate = ohReader["ohDate"].ToString(),
                    ohTimes = ohReader["ohTimes"].ToString(),
                    ohLocation = ohReader["ohLocation"].ToString(),
                    ohWaitLocation = ohReader["ohWaitLocation"].ToString(),
                    instructorID = int.Parse(ohReader["instructorID"].ToString()),
                });
            }
            DBClass.SchoolDBConnection.Close();
            
            SqlDataReader mReader = DBClass.meetingReader();
            while (mReader.Read())
            {
                MeetingList.Add(new Meeting
                {
                  meetingName = mReader["meetingName"].ToString(),
                  scheduleMeetingDate = mReader["scheduleMeetingDate"].ToString(),
                  scheduledMeetingTime = mReader["scheduledMeetingTime"].ToString(),
                  meetingPurpose = mReader["meetingPurpose"].ToString(),
                  
                });
            }
            DBClass.SchoolDBConnection.Close();


            SqlDataReader ClassReader = DBClass.ClassReader();
            while (ClassReader.Read())
            {
                ClassList.Add(new Class
                {
                    classID = int.Parse(ClassReader["classID"].ToString()),
                    className = ClassReader["className"].ToString(),
                    classDescription = ClassReader["classDescription"].ToString(),
                    classLocation = ClassReader["classLocation"].ToString(),

                    //instructorID = int.Parse(ClassReader["instructorID"].ToString()),
                });
            }
            DBClass.SchoolDBConnection.Close();
        }

        public void OnPostSingleSelect(){
            SelectProfessor = "Selected Instructor was: " + SelectInstructor;
        }
    }
}

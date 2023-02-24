using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPage.Pages.DBClasses
{
    public class Meeting
    {
        //DataClasses for a Meeting that can take place with a Student and Instructor
        public int meetingID { get; set; } 
        public String? meetingName { get; set; }
        public String? scheduleMeetingDate { get; set; }
        public String? scheduledMeetingTime { get; set; }
        public String? meetingPurpose { get; set; }

        
        public int instructorID { get; set; }

        
        public int studentID { get; set; }





    }
}

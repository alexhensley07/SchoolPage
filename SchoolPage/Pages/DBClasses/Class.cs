using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPage.Pages.DBClasses
{
    //DataClasses for an actual class
    public class Class
    {
        public int classID { get; set; }
        public String? className { get; set; }
        public String? classDescription { get; set; }

        public String? classLocation { get; set; }

        
        public Instructor instructorID { get; set;}



    }
}

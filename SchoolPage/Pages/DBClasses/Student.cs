using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPage.Pages.DBClasses
{
    public class Student
    {
        //DataClasses for a Student

        public int studentID {get; set;}
        public String? studentFirstName { get;set; }
        public String? studentLastName { get;set; }
        public String? studentEmail { get;set; }
        public String? studentPhone { get;set; }


        public int studentPartnerID { get; set; }



    }
}

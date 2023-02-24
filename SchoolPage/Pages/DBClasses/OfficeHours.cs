using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolPage.Pages.DBClasses
{
    public class OfficeHours
    {
        //DataClasses for an OfficeHours
        public int officeHoursID { get; set; }
        public String? ohDate { get; set; }
        public String? ohTimes { get; set; }
        public String? ohLocation { get; set; }
        public String? ohWaitLocation { get; set; }

        
        public int instructorID { get; set;}



    }
}

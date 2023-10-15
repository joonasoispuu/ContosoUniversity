using ContoseUniversity.Models;
using ContosoUniversityTARpe21.Models;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityTARpe21.Models
{
    public class CourseAssignment
    {
        [Key]
        public int ID { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
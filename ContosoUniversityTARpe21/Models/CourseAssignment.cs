namespace ContosoUniversityTARpe21.Models
{
    public class CourseAssignment
    {
        public int CourseID { get; set; }

        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
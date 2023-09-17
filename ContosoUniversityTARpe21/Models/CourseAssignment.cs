using ContosoUniversityTARpe21.Models;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityTARpe21.Models
{
    public class CourseAssignment
    {
        [Key]
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
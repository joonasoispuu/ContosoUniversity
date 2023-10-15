﻿using ContoseUniversity.Models;
using ContosoUniversityTARpe21.Models;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityTARpe21.Models
{

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

}
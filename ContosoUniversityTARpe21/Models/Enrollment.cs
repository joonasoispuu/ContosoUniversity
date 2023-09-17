﻿using ContosoUniversityTARpe21.Models;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityTARpe21.Models
{

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

}
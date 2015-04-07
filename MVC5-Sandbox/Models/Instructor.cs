using System;
using System.Collections.Generic;

namespace MVC5_Sandbox.Models
{
    public class Instructor
    {
        public Instructor()
        {
            this.Courses = new List<Course>();
        }

        // Primary Key
        public int InstructorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }

        // Navigation Properties
        public virtual ICollection<Course> Courses { get; private set; }
    }
}
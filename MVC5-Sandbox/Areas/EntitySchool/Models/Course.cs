using System.Collections.Generic;

namespace MVC5_Sandbox.Areas.EntitySchool.Models
{
    public class Course
    {
        /// <summary>
        /// Course constructor sets Instructors navigation property
        /// </summary>
        public Course()
        {
            this.Instructors = new HashSet<Instructor>();
        }

        // Primary key
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation Properties
        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; } 
    }

    public partial class OnlineCourse : Course
    {
        public string Url { get; set; }
    }

    public partial class OnsiteClass : Course
    {
        public OnsiteClass()
        {
            Details = new Details();
        }

        public Details Details { get; set; }
    }
}
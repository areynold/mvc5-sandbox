using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_Sandbox.Models
{
    public class Department
    {
        /// <summary>
        /// Department constructor sets up Courses navigation property
        /// </summary>
        public Department()
        {
            this.Courses = new HashSet<Course>();
        }

        // Primary key
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }
        public int? Administrator { get; set; }

        // Navigation Property
        public virtual ICollection<Course> Courses { get; private set; } 
    }
}
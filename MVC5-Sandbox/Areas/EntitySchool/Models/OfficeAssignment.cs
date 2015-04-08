using System;
using System.ComponentModel.DataAnnotations;


namespace MVC5_Sandbox.Models
{
    public class OfficeAssignment
    {
        [Key()]
        public Int32 InstructorId { get; set; }
        public string Location { get; set; }

        // When the Entity Framework sees Timestamp attribute 
        // it configures ConcurrencyCheck and DatabaseGeneratedPattern=Computed.
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        // Navigation property
        public virtual Instructor Instructor { get; set; }
    }
}
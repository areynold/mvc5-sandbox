using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC5_Sandbox.Models
{
    using System.Data.Entity;

    public class SchoolEntities : DbContext
    {
        public SchoolEntities()
            : base("name=SchoolEntities")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            // Set a primary key on OfficeAssignment
            modelBuilder.Entity<OfficeAssignment>().HasKey(t => t.InstructorId);

            // Set a composite primary key on Department
            modelBuilder.Entity<Department>().HasKey(t => new { t.DepartmentId, t.Name });

            // Do not generate Department's DepartmentId from the database
            modelBuilder.Entity<Department>()
                .Property(t => t.DepartmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Set property max length
            modelBuilder.Entity<Department>().Property(t => t.Name).HasMaxLength(50);

            // Do not map property to DB
            modelBuilder.Entity<Department>().Ignore(t => t.Budget);
        }
    }
}
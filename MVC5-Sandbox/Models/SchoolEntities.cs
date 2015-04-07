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

            // Map property to differently named db column
            modelBuilder.Entity<Department>().Property(t => t.Name).HasColumnName("DepartmentName");

            //// Required-to-Optional Relationship (one-to-zero-or-one)
            // Set primary key on OfficeAssignment
            modelBuilder.Entity<OfficeAssignment>()
                .HasKey(t => t.InstructorId);

            //// Set one-to-zero-or-one relationship
            //// Incompatible with one-to-one, below
            //modelBuilder.Entity<OfficeAssignment>()
            //    .HasRequired(t => t.Instructor)
            //    .WithOptional(t => t.OfficeAssignment);

            //// Set one-to-one relationship
            // Set Office Assignment primary key (completed above)
            modelBuilder.Entity<Instructor>()
                .HasRequired(t => t.OfficeAssignment)
                .WithRequiredPrincipal(t => t.Instructor);

            //// Set many-to-many relationship
            modelBuilder.Entity<Course>()
                .HasMany(t => t.Instructors)
                .WithMany(t => t.Courses)
                
                // Join tables/columns
                .Map(m =>
                {
                    m.ToTable("CourseInstructor");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("InstructorId");
                });
        }
    }
}
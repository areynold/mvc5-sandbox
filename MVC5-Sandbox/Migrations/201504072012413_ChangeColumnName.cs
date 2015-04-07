namespace MVC5_Sandbox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Url = c.String(),
                        Details_Time = c.DateTime(),
                        Details_Location = c.String(),
                        Details_Days = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Department_DepartmentId = c.Int(),
                        Department_Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => new { t.Department_DepartmentId, t.Department_Name })
                .Index(t => new { t.Department_DepartmentId, t.Department_Name });
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        Administrator = c.Int(),
                    })
                .PrimaryKey(t => new { t.DepartmentId, t.DepartmentName });
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InstructorId);
            
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        InstructorId = c.Int(nullable: false),
                        Location = c.String(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.InstructorId)
                .ForeignKey("dbo.Instructors", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_InstructorId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_InstructorId, t.Course_CourseId })
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Instructor_InstructorId)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeAssignments", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.InstructorCourses", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.Courses", new[] { "Department_DepartmentId", "Department_Name" }, "dbo.Departments");
            DropIndex("dbo.InstructorCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_InstructorId" });
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorId" });
            DropIndex("dbo.Courses", new[] { "Department_DepartmentId", "Department_Name" });
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.OfficeAssignments");
            DropTable("dbo.Instructors");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}

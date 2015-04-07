namespace MVC5_Sandbox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseInstructorTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InstructorCourses", newName: "CourseInstructor");
            RenameColumn(table: "dbo.CourseInstructor", name: "Instructor_InstructorId", newName: "InstructorId");
            RenameColumn(table: "dbo.CourseInstructor", name: "Course_CourseId", newName: "CourseId");
            RenameIndex(table: "dbo.CourseInstructor", name: "IX_Course_CourseId", newName: "IX_CourseId");
            RenameIndex(table: "dbo.CourseInstructor", name: "IX_Instructor_InstructorId", newName: "IX_InstructorId");
            DropPrimaryKey("dbo.CourseInstructor");
            AddPrimaryKey("dbo.CourseInstructor", new[] { "CourseId", "InstructorId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CourseInstructor");
            AddPrimaryKey("dbo.CourseInstructor", new[] { "Instructor_InstructorId", "Course_CourseId" });
            RenameIndex(table: "dbo.CourseInstructor", name: "IX_InstructorId", newName: "IX_Instructor_InstructorId");
            RenameIndex(table: "dbo.CourseInstructor", name: "IX_CourseId", newName: "IX_Course_CourseId");
            RenameColumn(table: "dbo.CourseInstructor", name: "CourseId", newName: "Course_CourseId");
            RenameColumn(table: "dbo.CourseInstructor", name: "InstructorId", newName: "Instructor_InstructorId");
            RenameTable(name: "dbo.CourseInstructor", newName: "InstructorCourses");
        }
    }
}

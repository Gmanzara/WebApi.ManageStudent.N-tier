namespace ManageStudent.Core.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int CourseId1 { get; set; }
        public int StudentId2 { get; set; }
        public Student1 Student1 { get; set; }
        public Course1 Course1 { get; set; }
    }
}
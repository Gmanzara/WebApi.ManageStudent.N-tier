namespace ManageStudent.Core.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int CourseId1 { get; set; }
        public int StudentId2 { get; set; }
        public Student Student1 { get; set; }
        public Course Course1 { get; set; }
    }
}
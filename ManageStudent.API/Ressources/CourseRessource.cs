namespace ManageStudent.API.Ressources
{
    public class CourseRessource
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public double Score {  get; set; }
        public StudentRessource Student {  get; set; }

    }
}

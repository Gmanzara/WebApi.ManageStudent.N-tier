using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManageStudent.Core.Models
{
    public class Course
    {
        public Course()
        {
            Enrollments = new Collection<Enrollment>();
        }
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<Enrollment> Enrollments  { get; set; }
    }
}

    
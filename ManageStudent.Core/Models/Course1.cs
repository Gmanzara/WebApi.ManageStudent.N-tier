using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManageStudent.Core.Models
{
    public class Course1
    {
        public Course1()
        {
            Enrollments = new Collection<Enrollment>();
        }
        public int Id { get; set; }
        public string CourseName { get; set; }
        public double Score { get; set; }
        public ICollection<Enrollment> Enrollments  { get; set; }
    }
}

    
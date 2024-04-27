using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManageStudent.Core.Models
{
    public class Student
    {
        public Student() 
        {
            Enrollments = new Collection<Enrollment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

    
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManageStudent.Core.Models
{
    public class Student
    {
        public Student() 
        {
            Courses = new Collection<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}

    
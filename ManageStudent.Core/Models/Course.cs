using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ManageStudent.Core.Models
{
    public class Course
    {
        public Course()
        {
            Students = new Collection<Student>();
        }
        public int Id { get; set; }
        public string CourseName { get; set; }
        public double Score { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

    
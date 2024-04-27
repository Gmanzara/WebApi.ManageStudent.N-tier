﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ManageStudent.Core.Models
{
    public class Student1
    {
        public Student1() 
        {
            Enrollments = new Collection<Enrollment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

    
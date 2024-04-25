using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ManageStudent.Core.Models
{
    public class Course
    {

        public int Id { get; set; }
        public string CourseName { get; set; }
        public double Score { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}

    
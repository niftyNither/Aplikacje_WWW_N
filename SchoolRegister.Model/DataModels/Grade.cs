using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        public DateTime DateOfIssue { get; set; }
        public GradeScale GradeValue { get; set; }
        public Student? Student { get; set; }
        public int StudentId { get; set; }
        public Subject? Subject { get; set;}
        public int SubjectId { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuddyMap.Models
{
    public class Student
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }
        //public int StudentGroupId { get; set; }
        public string Email { get; set; }

        //public List<XXAnswerStudent> AnswerStudents { get; set; }

        public Student(int studentId, string name, string email)
        {
            Id = studentId;
            Name = name;
            //StudentGroupId = studentGroupId;
            Email = email;
        }

        public Student()
        {
        }
    }
}


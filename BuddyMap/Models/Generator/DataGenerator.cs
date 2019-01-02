using System.Collections.Generic;

namespace BuddyMap.Models.Generator
{
    public sealed class DataGenerator
    {
        public List<Student> Students { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }

        public void AddStudents(Student studentToAdd)
        {
            Students.Add(new Student(12, "b", 12, "e"));
        }
    }
}
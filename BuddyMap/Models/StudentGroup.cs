using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuddyMap.Models
{
    public class StudentGroup
    {
        [Key]
        public int Id { get; set; }

        public string StudentGroupName { get; set; }
        public List<Student> Students { get; set; }
    }
}

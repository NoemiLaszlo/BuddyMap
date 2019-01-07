using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuddyMap.Models
{
    public class AnswerElement
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int AnswerId { get; set; }
        //public Answer Answer { get; set; }
    }
}

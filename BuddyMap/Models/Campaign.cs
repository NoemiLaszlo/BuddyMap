using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuddyMap.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        public QuestionGroup QuestionGroup { get; set; }
        public StudentGroup StudentGroup { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

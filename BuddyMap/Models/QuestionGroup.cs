using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuddyMap.Models
{
    public class QuestionGroup
    {
        [Key]
        public int Id { get; set; }

        //public int QuestionGroupId { get; set; }
        public string QuestionGroupName { get; set; }
        public List<Question> Questions { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuddyMap.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public int AnswerGroupId { get; set; }
        public AnswerGroup AnswerGroup { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        
        public List<AnswerElement> AnswerElements { get; set; }

        public Answer()
        {
        }
    }
}
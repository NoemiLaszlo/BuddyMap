using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuddyMap.Models
{
    public class QuestionGroup
    {
        [Key]
        public int Id { get; set; }
        public string QuestionGroupName { get; set; }
        public List<QQGConnection> QQGConnection { get; set; }
        public List<Question> Questions { get; internal set; }

        public QuestionGroup()
        {
        }
    }
}
